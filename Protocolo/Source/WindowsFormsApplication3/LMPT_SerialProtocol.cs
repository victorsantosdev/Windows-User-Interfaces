using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMPT_Protocolo
{
    class LMPT_SerialProtocol
    {
        private byte[] KNOCK = { 0xAF, 0xB2, 0x01, 0x01, 0x0C, 0x01, 0x00, 0x0A, 0x0B, 0x0C, 0x0D, 0x10 };

        public byte[] knock_cmd() {
            return this.KNOCK;
        }

        public LMPT_SerialProtocol()
        {
        }

        public int maxLenght() {
            return KNOCK.Length;
        }
    }
}
