using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    /// <summary>
    /// A class that represents a operand
    /// </summary>
    public class Operand : Token
    {
        /// <summary>
        /// The operands number/value
        /// </summary>
        public double Number
        {
            get; set;
        }

        /// <summary>
        /// Constructor that sets the number of the operand
        /// </summary>
        /// <param name="value"> The operands value </param>
        public Operand(double value)
        {
            Number = value;
        }

        /// <summary>
        /// This method changes the operands number into a string
        /// </summary>
        /// <returns> The operands number in string form </returns>
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}   
