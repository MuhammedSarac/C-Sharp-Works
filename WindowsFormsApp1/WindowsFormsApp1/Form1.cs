using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BClick();
        }

        private static bool OpControl(char x)
        {
            return x != '/' && x != '*' && x != '-' && x != '+';
        }

        static double Calc(double num, char input, double num1)
        {
            double sum = 0;
            if (input == '+') sum = num + num1;
            if (input == '*') sum = num * num1;
            if (input == '-') sum = num - num1;
            if (input == '/') sum = num / num1;
            return sum;
        }
        private static int SetLength(string input)
        {
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (!OpControl(input[i]))
                    counter++;
            }
            return counter;
        }

        private void BClick()
        {
            if (Tbnum1.Text != "" && Tbnum1.Text != null && Tbnum1.Text.Length > 3)
            {
                string input = Tbnum1.Text;
                input = ParanCalc(input);
                double[] numbers = new double[SetLength(input) + 1];
                char[] operators = new char[SetLength(input)];
                Sorting(input, ref numbers, ref operators);
                Calculate(ref numbers, ref operators);
                Tbnum1.Text = numbers[0].ToString();
            }
        }

        private static string ParanCalc(string input)
        {
            while (input.Contains("("))
            {


                int startPara = 0, slutPara = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '(')
                    {
                        startPara = i;
                        if (int.TryParse(input.Substring(i - 1, 1), out int testTal))
                            input = input.Substring(0, startPara) + '*' + input.Substring(startPara);

                    }

                    else if (input[i] == ')')
                    {
                        slutPara = i;
                        break;
                    }
                }
                if (slutPara > 0)
                {

                    double melCalc = Calcbracket(input.Substring(startPara + 1, slutPara - startPara - 1));
                    input = input.Substring(0, startPara) + melCalc + input.Substring(slutPara + 1);
                }
            }
            return input;
        }

        private static void Calculate(ref double[] numbers, ref char[] operators)
        {
            double sum = 0;
            int position = 0;
            foreach (char finderMultiple in operators)
            {

                if (OpControl(finderMultiple)) break;

                switch (finderMultiple)
                {
                    case '*':
                        sum = Calc(numbers[position], '*', numbers[position + 1]);
                        numbers = ShortingAray(numbers, position);
                        operators = ShortingOperat(operators, position);
                        numbers[position] = sum;
                        break;
                    case '/':
                        sum = Calc(numbers[position], '/', numbers[position + 1]);
                        numbers = ShortingAray(numbers, position);
                        operators = ShortingOperat(operators, position);
                        numbers[position] = sum;
                        break;
                    default:
                        position++;
                        break;
                }
            }
            position = 0;
            foreach (char finderPlus in operators)
            {
                if (OpControl(finderPlus)) break;
                switch (finderPlus)
                {
                    case '+':
                        sum = Calc(numbers[position], '+', numbers[position + 1]);
                        numbers = ShortingAray(numbers, position);
                        operators = ShortingOperat(operators, position);
                        numbers[position] = sum;
                        break;
                    case '-':
                        sum = Calc(numbers[position], '-', numbers[position + 1]);
                        numbers = ShortingAray(numbers, position);
                        operators = ShortingOperat(operators, position);
                        numbers[position] = sum;
                        break;
                    default:
                        break;
                }
            }
        }

        private static double[] ShortingAray(double[] numbers, int position)
        {
            double[] tempArray = new double[numbers.Length - 1];
            int pos = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!(position == i))
                {
                    tempArray[pos] = numbers[i];
                    pos++;
                }
            }
            return tempArray;
        }
        private static char[] ShortingOperat(char[] operat, int position)
        {
            char[] tempOperat = new char[operat.Length - 1];
            int pos = 0;
            for (int i = 0; i < operat.Length; i++)
            {
                if (!(position == i))
                {
                    tempOperat[pos] = operat[i];
                    pos++;
                }
            }
            return tempOperat;
        }

        private static void Sorting(string input, ref double[] numbers, ref char[] operators)
        {
            string rest;
            int operatorPos = FindOpPos(input);

            numbers[0] = Convert.ToInt32(input.Substring(0, operatorPos));
            operators[0] = Convert.ToChar(input.Substring(operatorPos, 1));
            rest = input.Substring(operatorPos + 1);
            operatorPos = FindOpPos(rest);
            for (int i = 1; i < input.Length; i++)
            {
                numbers[i] = Convert.ToInt32(rest.Substring(0, operatorPos));
                try
                {
                    operators[i] = Convert.ToChar(rest.Substring(operatorPos, 1));
                }
                catch (Exception)
                {
                    break;
                }

                rest = rest.Substring(operatorPos + 1);
                operatorPos = FindOpPos(rest);
            }
        }

        private static int FindOpPos(string input)
        {
            int operatorPos = 0;
            foreach (char x in input)
            {
                if (OpControl(x)) operatorPos++;
                else break;
            }
            return operatorPos;
        }
        private static double Calcbracket(string input)
        {

            input = ParanCalc(input);
            char[] operators = new char[input.Length];
            double[] numbers = new double[input.Length];
            double sum = 0;

            int operatorPos = FindOpPos(input);
            if (operatorPos != input.Length)
            {

                numbers[0] = Convert.ToInt32(input.Substring(0, operatorPos));
                operators[0] = Convert.ToChar(input.Substring(operatorPos, 1));
                string rest = input.Substring(operatorPos + 1);
                operatorPos = FindOpPos(rest);
                for (int i = 1; i < input.Length; i++)
                {
                    numbers[i] = Convert.ToInt32(rest.Substring(0, operatorPos));
                    try
                    {
                        operators[i] = Convert.ToChar(rest.Substring(operatorPos, 1));
                    }
                    catch (Exception)
                    {
                        break;
                    }

                    rest = rest.Substring(operatorPos + 1);
                    operatorPos = FindOpPos(rest);
                }
                int position = 0;
                foreach (char finderMultiple in operators)
                {

                    if (OpControl(finderMultiple)) break;

                    switch (finderMultiple)
                    {
                        case '*':
                            sum = Calc(numbers[position], '*', numbers[position + 1]);
                            numbers = ShortingAray(numbers, position);
                            operators = ShortingOperat(operators, position);
                            numbers[position] = sum;
                            break;
                        case '/':
                            sum = Calc(numbers[position], '/', numbers[position + 1]);
                            numbers = ShortingAray(numbers, position);
                            operators = ShortingOperat(operators, position);
                            numbers[position] = sum;
                            break;
                        default:
                            position++;
                            break;
                    }
                }
                position = 0;
                foreach (char finderPlus in operators)
                {
                    if (OpControl(finderPlus)) break;
                    switch (finderPlus)
                    {
                        case '+':
                            sum = Calc(numbers[position], '+', numbers[position + 1]);
                            numbers = ShortingAray(numbers, position);
                            operators = ShortingOperat(operators, position);
                            numbers[position] = sum;
                            break;
                        case '-':
                            sum = Calc(numbers[position], '-', numbers[position + 1]);
                            numbers = ShortingAray(numbers, position);
                            operators = ShortingOperat(operators, position);
                            numbers[position] = sum;
                            break;
                        default:
                            break;
                    }
                }
            }
            else sum = Convert.ToDouble(input);
            return sum;


        }
        private void Error()
        {
            Tbnum1.Text = "Error";
        }

        private void Tbnum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char a = e.KeyChar;
            if (!(Char.IsDigit(a) || a == '/' || a == '*' || a == '-' || a == '+' || a == '\r' || a == '\b' || a == '(' || a == ')') || (a == ')' && !Tbnum1.Text.Contains("(")))
                e.Handled = true;
            if (a == '\r') BClick();
        }
    }
}
