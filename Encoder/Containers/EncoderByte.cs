namespace Encoder.Containers;

public class EncoderByte
{
    public static ushort FixedSizeBits = 8;
    
    int[] PackedBits;

    public EncoderByte(int size)
    {
        this.PackedBits = new int[size * FixedSizeBits];
    }
    
}