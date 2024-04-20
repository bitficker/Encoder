using Encoder.Convert;

namespace Encoder;

internal class Base32Manager
{
    private const ushort FixedPackSize = 5;

    private Bin _bin = new();

    internal void Unpack(string[] chain, char[] outBuff)
    {
        // needed?
        if (chain.Length == 0)
            throw new ArgumentException("Char chain is invalid");

        var outBuffSize = outBuff.Length;
        if (outBuffSize != (chain.Length / FixedPackSize))
            throw new IndexOutOfRangeException("Out buffer must have fixed size");
        
   
        for (var i = 0; i < chain.Length; i += FixedPackSize)
        {
            // avoid abstractions
            var unpackedByte = _bin.ToByte(chain[new Range(i, i + FixedPackSize)]);
            
            unpackedByte.CopyTo(outBuff, i);
        }
        
        
    }

    
}