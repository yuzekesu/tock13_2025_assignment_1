using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class CalcMath
    {
        public double Calculate(RPNCalc r)
        {
            double result = 0;

            while (r.stackMain.Count() != 0)
            {
                //Pop first in stack
                var first = r.stackMain.Pop();

                switch (first)
                {
                    //Push to operator stack if pop yealds a operator
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "%":
                        r.stackSecond.Push(first);
                        break;

                    default:

                        //lägg till try parse - klar
                        //Exception case ifall det är t.ex. A, B eller fel operator

                        double a = Convert.ToDouble(first);
                        double b = 0;
                        var second = r.stackMain.Pop();
                        bool bothOperand = Double.TryParse(second, out b);

                        if (bothOperand)
                        {
                            var ourOperator = r.stackSecond.Pop();

                            switch (ourOperator)
                            {
                                case "+":
                                    r.stackMain.Push(Convert.ToString(b + a));
                                    break;

                                case "-":
                                    r.stackMain.Push(Convert.ToString(b - a));
                                    break;

                                case "*":
                                    r.stackMain.Push(Convert.ToString(b * a));
                                    break;

                                case "/":
                                    //måste ha exception case
                                    r.stackMain.Push(Convert.ToString(b / a));
                                    break;

                                case "%":
                                    //måste ha exception case
                                    r.stackMain.Push(Convert.ToString(b % a));
                                    break;
                            }

                            if (r.stackMain.Count() == 1 && r.stackSecond.Count() == 0)
                            {
                                result = Convert.ToDouble(r.stackMain.Pop());
                            }
                            else
                            {
                                while (r.stackSecond.Count != 0)
                                {
                                    r.stackMain.Push(r.stackSecond.Pop());
                                }
                            }
                        }
                        else
                        {
                            r.stackSecond.Push(Convert.ToString(a));
                            r.stackMain.Push(second);
                        }


                        break;
                }
            }
            return result;
        }
    }
}
