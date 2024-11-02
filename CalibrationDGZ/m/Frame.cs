
namespace CalibrationDGZ.m
{
    public class Frame
    {
        public byte[] Header { get; } = { 0x55, 0x00 };
        public byte Length { get; private set; }
        public byte Type { get; set; }
        public byte FirstAddress { get; set; }
        public byte[] Data { get; set; }
        public byte Checksum { get; private set; }
        public byte[] Tail { get; } = { 0x00, 0xAA };

        public Frame(byte type, byte firstAddress, byte[] data)
        {
            Type = type;
            FirstAddress = firstAddress;
            Data = data;
            Length = CLength();
            Checksum = CChecksum();
        }
        private byte CLength()
        {
            // Length = Data.Length + (Header(2), Length(1), Type(1), FirstAddress(1), Checksum(1), Tail(2))
            return (byte)(Data.Length + 8);
        }
        private byte CChecksum()
        {
            int sum = Length + Type + FirstAddress + Data.Sum(x => x);
            return (byte)(~(sum & 0xFF));
        }
        public byte[] ToArrayByte()
        {
            byte[] array = new byte[Length];
            array[0] = Header[0];
            array[1] = Header[1];
            array[2] = Length;
            array[3] = Type;
            array[4] = FirstAddress;
            Data.CopyTo(array, 5);
            array[Length - 3] = Checksum;
            array[Length - 2] = Tail[0];
            array[Length - 1] = Tail[1];
            return array;
        }
    }
}
