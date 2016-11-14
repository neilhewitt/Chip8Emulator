using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class AssignInstruction : RegisterInstructionWithValue
    {
        public override string ToString()
        {
            return "6" + RegisterIndexAsHex + ValueAsHex;
        }

        public override string ToAssembler()
        {
            return "LD\tV" + RegisterIndexAsHex + ", " + ValueAsHex;
        }

        public AssignInstruction(char registerIndexAsHex, byte value)
            : base(registerIndexAsHex, value)
        { }
    }
}
