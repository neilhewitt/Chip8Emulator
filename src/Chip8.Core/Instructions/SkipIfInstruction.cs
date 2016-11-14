using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class SkipIfInstruction : RegisterInstructionWithValue
    {
        public override string ToString()
        {
            return "3" + RegisterIndexAsHex + ValueAsHex;
        }

        public override string ToAssembler()
        {
            return "SKIPIF\tV" + RegisterIndexAsHex + ", " + ValueAsHex;
        }


        public SkipIfInstruction(char registerIndexAsHex, byte value)
            : base(registerIndexAsHex, value)
        { }
    }
}
