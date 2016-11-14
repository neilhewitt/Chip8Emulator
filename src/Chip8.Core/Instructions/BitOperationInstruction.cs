using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class BitOperationInstruction : TwoRegisterInstruction
    {
        public int OperationIndex { get; }
        public char OperationIndexAsHex { get; }

        public override string ToString()
        {
            return "8" + RegisterIndexAsHex + (OperationIndex == 6 || OperationIndex == 15 ? '0' : Register2IndexAsHex) + OperationIndexAsHex;
        }

        public override string ToAssembler()
        {
            string opcode = "";
            switch (OperationIndex)
            {
                case 0: opcode = "COPY"; break;
                case 1: opcode = "OR"; break;
                case 2: opcode = "AND"; break;
                case 3: opcode = "XOR"; break;
                case 4: opcode = "ADDWC"; break;
                case 5: opcode = "SUBWC"; break;
                case 6: opcode = "SHIFTR"; break;
                case 7: opcode = "SUBWC"; break;
                case 14: opcode = "SHIFTL"; break;
                default: opcode = "UNKNOWN"; break;
            }

            if (OperationIndex == 7) return opcode + " V" + Register2IndexAsHex + ", V" + RegisterIndexAsHex; // special case
            return opcode + " V" + RegisterIndexAsHex + ", V" + Register2IndexAsHex;
        }


        public BitOperationInstruction(char register1IndexAsHex, char register2IndexAsHex, char operationIndexAsHex)
            : base(register1IndexAsHex, register2IndexAsHex)
        {
            OperationIndexAsHex = char.ToUpper(operationIndexAsHex);
            OperationIndex = int.Parse(OperationIndexAsHex.ToString(), System.Globalization.NumberStyles.HexNumber);
        }
    }
}
