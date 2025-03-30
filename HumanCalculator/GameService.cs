using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public GameService(ILogger<GameService> logger, ILogger<Score> scoreLogger, ILogger<Time> timeLogger)
        {
            _logger = logger;
            this.scoreLogger = scoreLogger;
            this.timeLogger = timeLogger;
        }
        public void RepeatGame()
        {
            using (StreamWriter streamWriter = new StreamWriter(@"..\..\score.txt", true))
            {
                try
                {
                    IScore score = StartGame();
                    Console.WriteLine("Please type your nickname: ");
                    streamWriter.WriteLine($"{new Player(Console.ReadLine() ?? "N/A", score).GetStats()} at {DateTime.UtcNow}");
                    Console.WriteLine("If you want to play again press ENTER");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }
            }
        }
        public IScore StartGame()
        {
            IScore score = new Score(scoreLogger,timeLogger);
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
            return 0;
        }
    }
}
