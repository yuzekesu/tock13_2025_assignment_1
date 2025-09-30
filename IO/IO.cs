using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.View
{
    /// <summary>
    /// C style static methods that can be shared between Console_IO and File_IO.
    /// </summary>
    public class IO
    {

        public enum Status
        {
            VALID,
            INVALID,
            EMPTY
        }
        protected LineFormatter InputLine { get; set; } = new();
    }
}
