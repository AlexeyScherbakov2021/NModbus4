using Modbus.Data;
using Modbus.Message;
using Modbus.Unme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NModbus4.Message
{
    internal class ReadFuncRegistersResponse : AbstractModbusMessageWithData<RegisterCollection>, IModbusMessage
    {
        public ReadFuncRegistersResponse()
        {
        }

        public ReadFuncRegistersResponse(byte functionCode, byte slaveAddress, RegisterCollection data) : base(slaveAddress, functionCode)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            ByteCount = data.ByteCount;
            Data = data;

        }

        public byte ByteCount
        {
            get { return MessageImpl.ByteCount.Value; }
            set { MessageImpl.ByteCount = value; }
        }


        public override int MinimumFrameSize => 3;


    protected override void InitializeUnique(byte[] frame)
        {
            if (frame.Length < MinimumFrameSize + frame[2])
            {
                throw new FormatException("Message frame does not contain enough bytes.");
            }
            ByteCount = frame[2];
            Data = new RegisterCollection(frame.Slice(3, ByteCount).ToArray());
        }
    }
}
