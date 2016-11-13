using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class AssignInstruction : RegisterInstructionWithValue
    {
        public AssignInstruction(char registerIndexAsHex, byte value)
            : base(registerIndexAsHex, value)
        { }
    }
}
