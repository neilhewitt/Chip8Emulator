using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class AddInstruction : RegisterInstructionWithValue
    {
        public override string ToString()
        {
            return "7" + RegisterIndexAsHex + ValueAsHex;
        }

        public override string ToAssembler()
        {
            return "ADD V" + RegisterIndexAsHex + ", " + ValueAsHex;
        }

        public AddInstruction(char registerIndexAsHex, byte value)
            : base(registerIndexAsHex, value)
        { }
    }
}
