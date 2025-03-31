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
        private readonly IServiceProvider _service;
        public Program()
        {
            _service = BuildServiceProvider();
        }
        private IServiceProvider BuildServiceProvider()
        {
            Log.Logger = new LoggerConfiguration()
           .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();
            return new ServiceCollection()
            .AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog();
            })
            .AddSingleton<IScore, Score>()
            .AddSingleton<IPlayer, Player>()
            .AddSingleton<ITime, Time>()
            .AddSingleton<IGameService, GameService>()
            .AddSingleton<IScoreFactory, ScoreFactory>()
            .AddSingleton<ITimeFactory,TimeFactory>()
            .BuildServiceProvider();
        }
        private void Run()
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
                        if (Console.ReadKey(intercept: true).Key == ConsoleKey.Enter)
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
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
    }
}