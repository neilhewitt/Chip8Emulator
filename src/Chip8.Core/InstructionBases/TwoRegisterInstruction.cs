using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public abstract class TwoRegisterInstruction : RegisterInstruction
    {
        public int Register2Index { get; }
        public char Register2IndexAsHex { get; }

        public TwoRegisterInstruction(char registerIndexAsHex, char register2IndexAsHex)
            : base(registerIndexAsHex)
        {
            Register2IndexAsHex = char.ToUpper(register2IndexAsHex); 
            Register2Index = int.Parse(register2IndexAsHex.ToString(), System.Globalization.NumberStyles.HexNumber);
        }
    }
}
