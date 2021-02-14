using System;

namespace VicsGarageEx5
{
    public class ConsoleUI : UI
    {
        public override void Output(string message)
        {
            Console.WriteLine($"{message}");   
        }

        public override string Input()
        {
            return Console.ReadLine();
        }

        public override double InputDouble()
        {
            throw new NotImplementedException();
        }

        public override int InputInt()
        {
            throw new NotImplementedException();
        }

        public override bool InputYN()
        {
            throw new NotImplementedException();
        }

        
    }
}