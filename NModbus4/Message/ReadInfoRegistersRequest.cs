using Modbus.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NModbus4.Message
{
    internal class ReadInfoRegistersRequest : AbstractModbusMessage, IModbusRequest
    {
        public ReadInfoRegistersRequest()
        {
        }

        public ReadInfoRegistersRequest(byte functionCode, byte slaveAddress, ushort numberOfPoints)
            : base(slaveAddress, functionCode)
        {
            NumberOfPoints = numberOfPoints;
        }

        public ushort NumberOfPoints
        {
            get
            {
                return MessageImpl.NumberOfPoints.Value;
            }

            set
            {
                //if (value > Modbus.MaximumRegisterRequestResponseSize)
                //{
                //    string msg = $"Maximum amount of data {Modbus.MaximumRegisterRequestResponseSize} registers.";
                //    throw new ArgumentOutOfRangeException(nameof(NumberOfPoints), msg);
                //}

                MessageImpl.NumberOfPoints = value;
            }
        }




        public override int MinimumFrameSize
        {
            get { return 6; }
        }

        public override string ToString()
        {
            string msg = $"Read Code Function {FunctionCode}.";
            return msg;
        }

        public void ValidateResponse(IModbusMessage response)
        {
            var typedResponse = response as ReadFuncRegistersResponse;
            Debug.Assert(typedResponse != null, "Argument response should be of type ReadFuncRegistersResponse.");
            //var expectedByteCount = NumberOfPoints * 2;

            //if (expectedByteCount != typedResponse.ByteCount)
            //{
            //    string msg = $"Unexpected byte count. Expected {expectedByteCount}, received {typedResponse.ByteCount}.";
            //    throw new IOException(msg);
            //}
        }

        protected override void InitializeUnique(byte[] frame)
        {
            //StartAddress = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 2));
            //NumberOfPoints = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 4));
        }

    }
}
