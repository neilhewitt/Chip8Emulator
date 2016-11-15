using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class Register
    {
        public bool this[short index]
        {
            get
            {
                if (index > 7) throw new ArgumentOutOfRangeException("Must specify an index between 0 and 8");

                return (Value & (1 << index - 1)) == 1;
            }
        }
        public byte Value { get; private set; }
        
        public void Assign(byte value)
        {
            Value = value;
        }

        public void Add(byte value)
        {
            int valueAsInt = (int)Value;
            valueAsInt += (int)value;
            Value = valueAsInt > 255 ? (byte)255 : (byte)valueAsInt;
        }

        public void Subtract(byte value)
        {
            int valueAsInt = (int)Value;
            valueAsInt -= (int)value;
            Value = valueAsInt < 0 ? (byte)0 : (byte)valueAsInt;
        }

        public void ShiftRight()
        {
            Value = (byte)(Value >> 1);
        }

        public void ShiftLeft()
        {
            Value = (byte)(Value << 1);
        }
    }
}
