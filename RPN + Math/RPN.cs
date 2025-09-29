using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class TokenStack : ITokenStack
    {
        //RPNCalc 
        private Stack<Token> stack = new Stack<Token>();



        public TokenStack(string input)
        {
            this.stack = pushStack(input);
        }

        public Stack<Token> pushStack(string input)
        {
            Stack<Token> tempStack = new Stack<Token>();
            var tokens = input.Split(' ');

            foreach (var token in tokens)
            {
                switch (token)
                {
                    case "+":
                        SumOperator opSum = new SumOperator();
                        tempStack.Push(opSum);
                        break;
                    case "-":
                        SubtractOperator opSub = new SubtractOperator();
                        tempStack.Push(opSub);
                        break;
                    case "*":
                        MultiplyOperator opMul = new MultiplyOperator();
                        tempStack.Push(opMul);
                        break;
                    case "/":
                        DivideOperator opDiv = new DivideOperator();
                        tempStack.Push(opDiv);
                        break;
                    case "%":
                        ModulusOperator opMod = new ModulusOperator();
                        tempStack.Push(opMod);
                        break;
                    default:
                        Operand operand = new Operand(Convert.ToDouble(token));
                        tempStack.Push(operand);
                        break;
                }
            }
            return tempStack;

        }

        public void Push(Token token)
        {
            this.stack.Push(token);
        }

        public Token Pop()
        {
            return this.stack.Pop();
        }

        public int Count()
        {
            return this.stack.Count;
        }
    }
}