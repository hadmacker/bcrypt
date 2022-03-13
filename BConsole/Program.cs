using System;
using b = BCrypt.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var workFactor = 4;

            var firstHash = "";

            string valueToHash;
            do
            {
                Console.Write("Phrase to hash: ");
                valueToHash = Console.ReadLine();
                var bc = b.BCrypt.HashPassword(valueToHash, workFactor);
                if (string.IsNullOrWhiteSpace(firstHash))
                    firstHash = bc;
                Console.WriteLine(bc);

                if(b.BCrypt.Verify(valueToHash, firstHash))
                    Console.WriteLine("Matches first hash!");

                workFactor++;

            } while (!string.IsNullOrWhiteSpace(valueToHash));

        }
    }
}
