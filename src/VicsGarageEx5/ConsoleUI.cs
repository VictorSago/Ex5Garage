using System;

namespace VicsGarageEx5
{
    public class ConsoleUI : UI
    {
        public override void Output(string message)
        {
            Console.WriteLine($"{message}");   
        }

        public override string GetString()
        {
            return Console.ReadLine();
        }

        public override double GetDouble()
        {
            throw new NotImplementedException();
        }

        public override int GetInt()
        {
            var input = Console.ReadLine();
            int result;
            while (!Int32.TryParse(input, out result))
            {
                Output($"Couldn't parse {input}. Try again:");
                input = Console.ReadLine();
            }
            return result;
        }

        public override int GetValidatedInt(int min, int max)
        {
            throw new NotImplementedException();
        }
        
        public override bool GetYN()
        {
            throw new NotImplementedException();
        }

        
    }
}