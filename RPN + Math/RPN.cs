using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    /// <summary>
    /// Represents a class that can stack a stack of tokens
    /// </summary>
    public class TokenStack : ITokenStack
    {
        /// <summary>
        /// The stack which stores Operators and Operands.
        /// </summary>        
        private Stack<Token> stack = new Stack<Token>();


        /// <summary>
        /// Constructor for TokenStack which accepts a string as a parameter.
        /// The construtor splits the input string and pushes a Operator or Operand on to the stack
        /// </summary>
        /// <param name="input"> A string containing numbers and operators </param>
        public TokenStack(string input)
        {
            var tokens = input.Split(' ');

            foreach (var token in tokens)
            {
                switch (token)
                {
                    case "+":
                        stack.Push(new SumOperator());
                        break;
                    case "-":
                        stack.Push(new SubtractOperator());
                        break;
                    case "*":
                        stack.Push(new MultiplyOperator());
                        break;
                    case "/":
                        stack.Push(new DivideOperator());
                        break;
                    case "%":
                        stack.Push(new ModulusOperator());
                        break;
                    default:
                        stack.Push(new Operand(Convert.ToDouble(token)));
                        break;
                }
            }
        }

        /// <summary>
        /// Method to push a token on to the stack
        /// </summary>
        /// <param name="token"> Token to be pushed on to the stack </param>
        public void Push(Token token)
        {
            stack.Push(token);
        }

        /// <summary>
        /// Method to pop the topmost token in the stack
        /// </summary>
        /// <returns> Token which is popped </returns>
        public Token Pop()
        {
            return stack.Pop();
        }

        /// <summary>
        /// Method to get the count of total elements in the stack
        /// </summary>
        /// <returns> Int value of the count of tokens </returns>
        public int Count()
        {
            return stack.Count();
        }

    }
}