using System;

namespace Denormalizer.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            WriteLine($"{DateTime.Now.ToShortTimeString()}: {message}");
        }

        public void Warn(string message)
        {
            var previousColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;

            WriteLine($"{DateTime.Now.ToShortTimeString()}: {message}");

            Console.ForegroundColor = previousColor;
        }

        public void Error(string message)
        {
            var previousColor = Console.ForegroundColor;

            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;

            WriteLine($"{DateTime.Now.ToShortTimeString()}: {message}");

            Console.ForegroundColor = previousColor;
        }

        private void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}