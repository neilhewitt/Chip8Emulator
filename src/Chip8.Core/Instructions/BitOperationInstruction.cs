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

        public override void Execute(VirtualMachine vm)
        {
            Register VX = vm.V[RegisterIndex];
            Register VY = vm.V[Register2Index];

            int total; 
            switch (OperationIndex)
            {
                case 0:
                    VX.Assign(VY.Value);
                    break;
                case 1:
                    VX.Assign((byte)((byte)VX.Value | (byte)VY.Value));
                    break;
                case 2:
                    VX.Assign((byte)((byte)VX.Value & (byte)VY.Value));
                    break;
                case 3:
                    VX.Assign((byte)((byte)VX.Value ^ (byte)VY.Value));
                    break;
                case 4:
                    total = VX.Value + VY.Value;
                    vm.VF.Assign((byte)(total > 255 ? 1 : 0));
                    break;
                case 5:
                    total = VX.Value - VY.Value;
                    vm.VF.Assign((byte)(total < 0 ? 1 : 0));
                    break;
                case 6:
                    vm.VF.Assign(Convert.ToByte(VX[0]));
                    VX.ShiftRight();
                    break;
                case 7:
                    total = VY.Value - VX.Value;
                    vm.VF.Assign((byte)(total < 0 ? 1 : 0));
                    break;
                case 14:
                    vm.VF.Assign(Convert.ToByte(VX[7]));
                    VX.ShiftLeft();
                    break;
            }
        }

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

            if (OperationIndex == 7) return opcode + "\tV" + Register2IndexAsHex + ", V" + RegisterIndexAsHex; // special case
            return opcode + "\tV" + RegisterIndexAsHex + ", V" + Register2IndexAsHex;
        }


        public BitOperationInstruction(char register1IndexAsHex, char register2IndexAsHex, char operationIndexAsHex)
            : base(register1IndexAsHex, register2IndexAsHex)
        {
            OperationIndexAsHex = char.ToUpper(operationIndexAsHex);
            OperationIndex = int.Parse(OperationIndexAsHex.ToString(), System.Globalization.NumberStyles.HexNumber);
        }
    }
}
