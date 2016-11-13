using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class AddInstruction : RegisterInstructionWithValue
    {
        public AddInstruction(char registerIndexAsHex, byte value)
            : base(registerIndexAsHex, value)
        { }
    }
}
