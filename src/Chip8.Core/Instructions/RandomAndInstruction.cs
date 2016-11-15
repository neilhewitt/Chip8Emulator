using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class RandomAndInstruction : RegisterInstructionWithValue
    {
        private static Random _random = new Random(DateTime.Now.Millisecond);

        public override void Execute(VirtualMachine vm)
        {
            byte product = (byte)(((byte)_random.Next(0, 255)) & Value);
            vm.V[RegisterIndex].Assign(product);
        }

        public override string ToString()
        {
            return "C" + RegisterIndexAsHex + ValueAsHex;
        }

        public override string ToAssembler()
        {
            return "ADDRAND\tV" + RegisterIndexAsHex + ", " + ValueAsHex;
        }

        public RandomAndInstruction(char registerIndexAsHex, byte value) 
            : base(registerIndexAsHex, value)
        {
        }
    }
}
