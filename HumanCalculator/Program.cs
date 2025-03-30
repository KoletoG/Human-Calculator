using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata.Ecma335;
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
            try
            {
                Console.WriteLine("Welcome to Human Calculator Game! \nPress Any Key to Start");
                CancellationTokenSource cancellationToken = new CancellationTokenSource();
                if (Console.ReadKey(intercept: true).Key >= 0)
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        RepeatGame();
                        if (Console.ReadKey(intercept: true).Key != ConsoleKey.Enter)
                        {
                            cancellationToken.Cancel();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Thanks for playing!");
            }
        }
        private static void RepeatGame()
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
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }
            }
        }
        private static IScore StartGame()
        {
            IScore score = new Score();
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
                Console.WriteLine(ex.Message);
            }
            return score;
        }
        private static int GenerateNumbers()
        {
            try
            {
                int a = rnd.Next(10, 100);
                int b = rnd.Next(10, 100);
                Console.WriteLine($"{a} * {b}");
                return a * b;
            }
            catch (Exception e) { 
                
            }
            return 0;
        }
    }


}