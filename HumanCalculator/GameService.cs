using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HumanCalculator
{
    internal class GameService : IGameService
    {
        private Random rnd = new Random();
        private Stopwatch stopwatch = new Stopwatch();
        private ILogger<GameService> _logger;
        private ILogger<Score> scoreLogger;
        private ILogger<Time> timeLogger;
        private readonly string fullPath = Path.GetFullPath("score.txt");
        private readonly IScoreFactory _factory;
        public GameService(ILogger<GameService> logger, ILogger<Score> scoreLogger, ILogger<Time> timeLogger, IScoreFactory factory)
        {
            _logger = logger;
            this.scoreLogger = scoreLogger;
            this.timeLogger = timeLogger;
            _factory = factory;
        }
        public void RepeatGame()
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(fullPath, true))
                {
                    IScore score = StartGame();
                    Console.WriteLine("Please type your nickname: ");
                    streamWriter.WriteLine($"{new Player(Console.ReadLine() ?? "N/A", score).GetStats()} at {DateTime.UtcNow}");
                    Console.WriteLine("If you want to play again press ENTER");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
        private IScore StartGame()
        {
            IScore score = _factory.Create();
            try
            {
                for (int i = 1; i <= Score.MaximumScore; i++)
                {
                    int result = GenerateNumbers();
                    stopwatch.Restart();
                    if (int.TryParse(Console.ReadLine(), out int playerAnswer) && playerAnswer == result)
                    {
                        stopwatch.Stop();
                        score.AddTime((int)stopwatch.Elapsed.TotalSeconds);
                        score.AddScore();
                        Console.WriteLine("Right!");
                    }
                    else
                    {
                        stopwatch.Stop();
                        score.AddTime((int)stopwatch.Elapsed.TotalSeconds);
                        Console.WriteLine("Wrong!");
                    }
                }
                score.Time.CalcAverageTime();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return score;
        }
        private int GenerateNumbers()
        {
            try
            {
                int a = rnd.Next(10, 100);
                int b = rnd.Next(10, 100);
                Console.WriteLine($"{a} * {b}");
                return a * b;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
            finally
            {
                throw new Exception();
            }
        }
    }
}
