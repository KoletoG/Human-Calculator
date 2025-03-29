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
                using (StreamWriter streamWriter = new StreamWriter(@"..\..\score.txt", true))
                {
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
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Thanks for playing!");
        }
        private static IScore StartGame()
        {
            IScore score = new Score();
            for (int i = 1; i <= Score.MaximumScore; i++)
            {
                int result = GenerateNumbers();
                stopwatch.Restart();
                if (int.TryParse(Console.ReadLine(),out int playerAnswer) &&  playerAnswer == result)
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
            return score;
        }
        private static int GenerateNumbers()
        {
            int a = rnd.Next(10, 100);
            int b = rnd.Next(10, 100);
            Console.WriteLine($"{a} * {b}");
            return a * b;
        }
    }
    
   
}