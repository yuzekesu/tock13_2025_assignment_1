using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class RPNCalc
    {
        //RPNCalc innehåller 2 stacks. Main och second.
        internal Stack<string> stackMain = new Stack<string>();
        internal Stack<string> stackSecond = new Stack<string>();

        //Properties till stackMain
        public Stack<string> StackMain
        {
            get { return stackMain; }
            set { stackMain = value; }
        }

        //Properties till stackSecond
        public Stack<string> StackSecond
        {
            get { return stackSecond; }
            set { stackSecond = value; }
        }

        public RPNCalc()
        {
        }

        public void pushStack(string input)
        {
            var tokens = input.Split(' ');

            //push alla tokens till main stacken
            //Kan göra om tokensen till egna classer (Operands och Operators)
            foreach (var token in tokens)
            {
                this.stackMain.Push(token);
            }
        }

    }
}
