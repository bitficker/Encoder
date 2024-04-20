
namespace Encoder.Convert;

internal class Encoding
{
    internal readonly ushort FixedPackSize = 5;
    
    // Composition
    private Bin _bin = new();

    internal void Base32Encoder(string[] inBuff, char[] outBuff)
    {
        // needed?
        if (inBuff.Length == 0)
            throw new ArgumentException("Char chain is invalid");

        var outBuffSize = outBuff.Length;
        if (outBuffSize != (inBuff.Length / FixedPackSize))
            throw new IndexOutOfRangeException("Out buffer must have fixed size");
        
        
        // Unrolling technique
        for (var i = 0; i < inBuff.Length; i += FixedPackSize)
        {
            // avoid abstractions
            var unpackedByte = _bin.ToByte(inBuff[new Range(i, i + FixedPackSize)]);
            
            unpackedByte.CopyTo(outBuff, i);
        }

        
    }
    
    
}