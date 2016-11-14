using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public abstract class RegisterInstructionWithValue : RegisterInstruction
    {
        public byte Value { get; }
        public string ValueAsHex => Convert.ToString(Value, 16).ToUpper().PadLeft(2, '0');

        public RegisterInstructionWithValue(char registerIndexAsHex, byte value)
            : base(registerIndexAsHex)
        {
            Value = value;
        }
    }
}
