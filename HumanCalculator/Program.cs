using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using static System.Formats.Asn1.AsnWriter;
namespace HumanCalculator
{
    internal class Program
    {
        private static IServiceProvider _service;
        static Program()
        {
            Log.Logger = new LoggerConfiguration()
           .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();
            var collection = new ServiceCollection();
            collection.AddLogging(loggingBuilder => 
            {
                loggingBuilder.AddSerilog();
            });
            collection.AddSingleton<IScore, Score>();
            collection.AddSingleton<IPlayer, Player>();
            collection.AddSingleton<ITime, Time>();
            collection.AddSingleton<IGameService, GameService>();
            collection.AddSingleton<IScoreFactory,ScoreFactory>();
            _service = collection.BuildServiceProvider();
        }
        static void Main(string[] args)
        {
            var logger = _service.GetRequiredService<ILogger<Program>>();
            var gameService = _service.GetRequiredService<IGameService>();
            try
            {
                logger.LogInformation("App has started.");
                Console.WriteLine("Welcome to Human Calculator Game! \nPress Any Key to Start");
                CancellationTokenSource cancellationToken = new CancellationTokenSource();
                if (Console.ReadKey(intercept: true).Key >= 0)
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        gameService.RepeatGame();
                        if (Console.ReadKey(intercept: true).Key != ConsoleKey.Enter)
                        {
                            cancellationToken.Cancel();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
            }
            finally
            {
                Console.WriteLine("Thanks for playing!");
                logger.LogInformation("App has stopped.");
                Log.CloseAndFlush();
            }
        }
    }
}