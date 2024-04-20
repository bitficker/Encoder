
namespace Encoder.Convert;

internal class Encoding
{
    internal readonly ushort Fixed32PackSize = 5;
    
    // Composition
    private BinConverter _binConverter = new();

    private string Base32Table = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
    private string Base64Table = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    
    internal void Base32Encoder(int[] inBuff, char[] outBuff)
    {
        // needed?
        if (inBuff.Length == 0)
            throw new ArgumentException("Char chain is invalid");

        var outBuffSize = outBuff.Length;
        if (outBuffSize != (inBuff.Length / Fixed32PackSize))
            throw new IndexOutOfRangeException("Out buffer must have fixed size");
        
        
        // Unrolling technique
        for (var i = 0; i < inBuff.Length; i += Fixed32PackSize)
        {
            // avoid abstractions
            var unpackedByte = _binConverter.ToByte(inBuff[new Range(i, i + Fixed32PackSize)]);
            
            // mapear para tabela base32
            outBuff[i] = Base32Table[unpackedByte];
            
        }

        
    }
    
    internal void Base64Encoder(int[] inBuff, char[] outBuff)
    {
        throw new NotImplementedException();
        
    }
    
    
}