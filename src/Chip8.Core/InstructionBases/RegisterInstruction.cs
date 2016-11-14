using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public abstract class RegisterInstruction : Instruction
    {
        public int RegisterIndex { get; }
        public char RegisterIndexAsHex { get; }

        public RegisterInstruction(char registerIndexAsHex)
        {
            RegisterIndexAsHex = char.ToUpper(registerIndexAsHex);
            RegisterIndex = int.Parse(registerIndexAsHex.ToString(), System.Globalization.NumberStyles.HexNumber);
        }
    }
}
