

namespace Encoder.Convert;


public class Bin
{
    private static ushort _fixedSizeArr = 8; 
    internal string[] FromBytes(byte[] chain)
    { 
        
        string[] packedBits = new string[chain.Length * 8];
        for (var i = 1; i <= chain.Length * 8; i++)
        {
            var fromByte = FromByte(chain[i]);

            fromByte.CopyTo(packedBits, i * _fixedSizeArr);
        }

        return packedBits;
    }
    
    // Implement recursion
    public string[] FromByte(byte b, bool padding = false) 
    {
        
        string[] bits = new[] { "0", "0", "0", "0", "0", "0", "0", "0" };
        
        string remainder = (b % 2).ToString(); 
        UInt16 currQuotient = (ushort)(b / 2); 
        
        var ptr = 7;
        while (ptr >= 0)
        {
            remainder = (currQuotient % 2).ToString();
            currQuotient = (ushort)(currQuotient / 2); 

            bits[ptr] = remainder; ptr--;
            
        }

        return bits;

    }

    public string[] ToByte(string[] chain) => new string[] { };
    
}