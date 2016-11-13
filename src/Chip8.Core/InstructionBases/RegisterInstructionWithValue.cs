using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public abstract class RegisterInstructionWithValue : RegisterInstruction
    {
        public byte Value { get; }

        public RegisterInstructionWithValue(char registerIndexAsHex, byte value)
            : base(registerIndexAsHex)
        {
            Value = value;
        }
    }
}
