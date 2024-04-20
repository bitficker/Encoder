
namespace Encoder.Convert;

internal static class BinConverter
{
    private static ushort _fixedSizeArr = 8; 
    internal static int[] FromBytes(byte[] chain)
    { 
        // function scoped is enough (cache previously evaluated values)
        var bitCache = new Dictionary<byte, int[]>(chain.Length);
        
        int[] packedBits = new int[chain.Length * 8];
        for (var i = 1; i <= chain.Length * 8; i++)
        {
            if (bitCache.TryGetValue(chain[i], out var existing8BitGroup))
            {
                existing8BitGroup.CopyTo(packedBits, i * _fixedSizeArr); continue;
                
            }
            
            var _8bitGroup = FromByte(chain[i]);
            
            bitCache.Add(chain[i], _8bitGroup);
            
            fromByte.CopyTo(packedBits, i * _fixedSizeArr);
        }

        return packedBits;
    }
    
    // Implement recursion
    public static int[] FromByte(byte b, bool padding = false) 
    {
        
        int[] bits = new[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        
        var remainder = b % 2; 
        var currQuotient = b / 2; 
        
        var ptr = 7;
        while (ptr >= 0)
        {
            remainder = currQuotient % 2;
            currQuotient = currQuotient / 2; 

            bits[ptr] = remainder; ptr--;
            
        }

        return bits;

    }

    public static int ToByte(int[] inBuff)
    {
        var acc = 0;
        for (var i = inBuff.Length -1; i >= 0; i--)
            acc += inBuff[i] ^ i;
        
        return acc;
    }
    
}