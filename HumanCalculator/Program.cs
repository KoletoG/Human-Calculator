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
                    char[] playerName = Console.ReadLine().ToCharArray();
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
        private static IScore StartGame()
        {
            IScore score = new Score();
            for (byte i = 1; i <= Score.MaximumScore; i++)
            {
                short result = GenerateNumbers();
                stopwatch.Restart();
                if (short.Parse(Console.ReadLine()) == result)
                {
                    stopwatch.Stop();
                    score.AddTime((byte)stopwatch.Elapsed.TotalSeconds);
                    score.AddScore();
                    Console.WriteLine("Right!");
                }
                else
                {
                    stopwatch.Stop();
                    score.AddTime((byte)stopwatch.Elapsed.TotalSeconds);
                    Console.WriteLine("Wrong!");
                }
            }
            score.Time.CalcAverageTime();
            return score;
        }
        private static short GenerateNumbers()
        {
            byte a = (byte)rnd.Next(10, 100);
            byte b = (byte)rnd.Next(10, 100);
            Console.WriteLine($"{a} * {b}");
            return (short)(a * b);
        }
    }
    
   
}