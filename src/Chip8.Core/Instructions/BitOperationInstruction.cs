using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class BitOperationInstruction : TwoRegisterInstruction
    {
        public int OperationIndex { get; }

        public BitOperationInstruction(char register1IndexAsHex, char register2IndexAsHex, int operationIndex)
            : base(register1IndexAsHex, register2IndexAsHex)
        {
            OperationIndex = operationIndex;
        }
    }
}
