using System.Text;
using Encoder.Containers;

namespace Encoder.Convert;


public class Binary
{
    private const ushort FixedSizeArr = 8; 
    internal string[] Bin(byte[] chain, EncodingType encodingType)
    { 
        string[] packedBits = new string[chain.Length * 8];
        
        if (encodingType is EncodingType.Base_32)
        {
            for (var i = 1; i <= chain.Length * 8; i++)
            {
                var fromByte = FromByte(chain[i]);

                fromByte.CopyTo(packedBits, i * FixedSizeArr);
            }

            return packedBits;

        }
        else if (encodingType is EncodingType.Base_64)
            throw new NotImplementedException();


        return packedBits;
    }

    // Aplicar recursion
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
}