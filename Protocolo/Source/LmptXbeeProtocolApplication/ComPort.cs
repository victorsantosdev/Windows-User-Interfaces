using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Timers;

namespace LmptProtocol
{

    public class ComPort : SerialPort
    {
        SerialPort comPort;

        public ComPort() {
            comPort = new SerialPort();

            //default COM port Arduino configuration
            comPort.BaudRate = 115200;
            comPort.Parity = Parity.None;
            comPort.DataBits = 8;
            comPort.StopBits = StopBits.One;
        }

        public List<string> UpdateComPorts()
        {
            List<string> comPortList = new List<string>();

            foreach (string s in ComPort.GetPortNames())
            {
                comPortList.Add(s);
            }
            return comPortList;
        }


    }
}
