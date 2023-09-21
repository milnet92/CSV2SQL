using DQSAutomateInterpreter.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVS2SQL.Core.Scripting
{
    public class InterpretEventArgs : EventArgs
    {
        public bool OnlyParsed { get; set; }
        public IInterpreterResult Result { get; set; }
        public InterpretEventArgs(IInterpreterResult result, bool onlyParsed)
        {
            Result = result;
            OnlyParsed = onlyParsed;
        }
    }
}
