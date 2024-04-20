
namespace Encoder.Convert;

internal class Encoding
{
    internal readonly ushort FixedPackSize = 5;
    
    // Composition
    private Bin _bin = new();

    private string Base32Table = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
    private string Base64Table = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    
    internal void Base32Encoder(int[] inBuff, char[] outBuff)
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
            
            // mapear para tabela base32
            outBuff[i] = Base32Table[unpackedByte];
            
        }

        
    }
    
    internal void Base64Encoder(int[] inBuff, char[] outBuff)
    {
        throw new NotImplementedException();
        
    }
    
    
}