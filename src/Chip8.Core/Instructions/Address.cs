using System;
using System.Linq;
using System.Collections;

namespace Chip8.Core
{
    public class Address
    {
        private short _offset;

        public Nybble First { get; }
        public Nybble Second { get; }
        public Nybble Third { get; }

        public short Offset => _offset;
        public string OffsetAsHex => Convert.ToString(Offset, 16).ToUpper().PadLeft(3, '0');

        public Address(string addressOffsetAsHex)
            : this(short.Parse(addressOffsetAsHex, System.Globalization.NumberStyles.HexNumber))
        {
        }

        public Address(short addressOffset)
        {
            if (addressOffset > 4095)
            {
                throw new ArgumentOutOfRangeException("Address offset must be < 4096 (FFFF).");
            }

            _offset = addressOffset;

            string addressAsBinaryString = Convert.ToString(addressOffset, 2).PadLeft(12, '0');
            First = new Nybble(addressAsBinaryString.Substring(0, 4));
            Second = new Nybble(addressAsBinaryString.Substring(4, 4));
            Third = new Nybble(addressAsBinaryString.Substring(8, 4));
        }
    }
}