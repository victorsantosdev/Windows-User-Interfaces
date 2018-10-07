using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LmptProtocol
{
    class LmptSerialProtocol
    {
        private byte[] KNOCK = { 0xAF, 0xB2, 0x01, 0x01, 0x0C, 0x01, 0x00, 0x0A, 0x0B, 0x0C, 0x0D, 0x10 };

        public byte[] Knock() {
            return this.KNOCK;
        }

        public LmptSerialProtocol()
        {
        }

        public int MaxLenght() {
            return KNOCK.Length;
        }
    }
}
