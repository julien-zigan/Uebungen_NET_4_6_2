using System;

namespace Uebungen
{
    internal class Taschenrechenr
    {
        static void Main(string[] args)
        {
            Loop(RunCalculator);
        }

        private static void Loop(Action action)
        {
            while (true) action();
        }

        private static void RunCalculator()
        {
            try
            {
                string[] expressionParts = ParseExpression();
                double[] operands = ParseOperandsFrom(expressionParts);
                string oparator = expressionParts[1];

                Console.WriteLine(Calculate(oparator, operands));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string[] ParseExpression()
        {
            Console.WriteLine("Geben Sie Ihre Rechnung ein (z.B. 2 + 3) oder drücken Sie Enter um das Programm zu verlassen:");
            return ExitIfEmpty(Console.ReadLine()).Split(' ');
        }

        private static string ExitIfEmpty(string input)
        {
            if (string.IsNullOrEmpty(input)) Environment.Exit(0);

            return input;
        }

        private static double[] ParseOperandsFrom(string[] expressionParts)
        {
            return new double[] {
                double.Parse(expressionParts[0]),
                double.Parse(expressionParts[2])
            };
        }

        private static double Calculate(string oparator, double[] operands)
        {
            switch (oparator)
            {
                case "+":
                    return Add(operands);
                case "-":
                    return Subtract(operands);
                case "*":
                    return Multiply(operands);
                case "/":
                    return Divide(operands);
                default:
                    throw new InvalidOperationException($"Ungültiger Operator: {oparator}. Zugelassen: +, -, *, /");
            }
        }

        private static double Add(double[] operands)
        {
            return operands[0] + operands[1];
        }

        private static double Subtract(double[] operands)
        {
            return operands[0] - operands[1];
        }

        private static double Multiply(double[] operands)
        {
            return operands[0] * operands[1];
        }

        private static double Divide(double[] operands)
        {
            if (operands[1] == 0)
            {
                throw new DivideByZeroException("Division durch Null ist nicht erlaubt.");
            }
            return operands[0] / operands[1];
        }

    }
}
