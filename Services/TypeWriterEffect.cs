using System;
using System.Threading;

namespace TypeWriter.Services
{
    public class TypeWriterEffect
    {
        private static readonly Random rnd = new Random();

        public void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < message.Length; i++)
            {


                Console.Write(message[i]);
                Thread.Sleep(rnd.Next(10, 50));
            }


        }
    }
}
