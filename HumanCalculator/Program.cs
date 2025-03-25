using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Formats.Asn1.AsnWriter;
namespace HumanCalculator
{
    
    internal class Program
    {
       private static Random rnd = new Random();
       private static Stopwatch stopwatch = new Stopwatch();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Human Calculator Game! \nPress Any Key to Start");
            if (Console.ReadKey(intercept: true).Key >= 0)
            {
                StreamWriter streamWriter = new StreamWriter(@"..\..\score.txt", true);
                while (true)
                {
                    IScore score = StartGame();
                    Console.WriteLine("Please type your nickname: ");
                    string playerName = Console.ReadLine();
                    IPlayer player = new Player(playerName, score);
                    streamWriter.WriteLine($"{player.GetStats()} at {DateTime.UtcNow}");
                    Console.WriteLine("If you want to play again press ENTER");
                    if (Console.ReadKey(intercept: true).Key != ConsoleKey.Enter)
                    {
                        streamWriter.Close();
                        break;
                    }
                }
            }
            Console.WriteLine("Thanks for playing!");
        }
        public static IScore StartGame()
        {
            IScore score = new Score();
            for (int i = 1; i <= Score.MaximumScore; i++)
            {
                int result = GenerateNumbers();
                stopwatch.Restart();
                if (int.Parse(Console.ReadLine()) == result)
                {
                    stopwatch.Stop();
                    score.AddTime(stopwatch.Elapsed.TotalSeconds);
                    score.AddScore();
                    Console.WriteLine("Right!");
                }
                else
                {
                    stopwatch.Stop();
                    score.AddTime(stopwatch.Elapsed.TotalSeconds);
                    Console.WriteLine("Wrong!");
                }
            }
            score.Time.CalcAverageTime();
            return score;
        }
        public static int GenerateNumbers()
        {
            int a = rnd.Next(10, 100);
            int b = rnd.Next(10, 100);
            Console.WriteLine($"{a} * {b}");
            return a * b;
        }
    }
    internal class Score : IScore
    {
        public readonly static byte MaximumScore = 5;
        public byte CurrentScore { get; set; } = 0;
        public ITime Time { get; private set; }
        public Score()
        {
            this.Time = new Time();
        }
        public void AddTime(double seconds)
        {
            this.Time.Times.Add(seconds);
        }
        public void AddScore()
        {
            this.CurrentScore++;
        }
    }
    class Player : IPlayer
    {
        public string Name { get; private set; }
        public IScore PlayerScore { get; private set; }
        public Player(string name, IScore score)
        {
            this.Name = name;
            this.PlayerScore = score;
        }
        public string GetStats()
        {
            return $"{Name}'s score is {PlayerScore.CurrentScore} out of {Score.MaximumScore} with Average time of {PlayerScore.Time.ShowAverageTime()}";
        }
    }
    class Time : ITime
    {
        public List<double> Times { get; private set; }
        public double AverageTime { get; private set; }
        public Time()
        {
            Times = new List<double>();
        }
        public void CalcAverageTime()
        {
            double allTime = 0;
            foreach (double t in Times)
            {
                allTime += t;
            }
            this.AverageTime = allTime / Score.MaximumScore;
        }
        public string ShowAverageTime()
        {
            return TimeSpan.FromSeconds(AverageTime).ToString(@"mm\:ss");
        }
    }
}