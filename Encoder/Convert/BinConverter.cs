
namespace Encoder.Convert;

internal static class BinConverter
{
    private static ushort _fixedSizeArr = 8; 
    internal static int[] FromBytes(byte[] chain)
    { 
        // function scoped is enough (cache for previously evaluated values)
        var _8bitGroupCache = new Dictionary<byte, int[]>(chain.Length);
        
        int[] packedBits = new int[chain.Length * 8];
        for (var i = 0; i < chain.Length * 8; i++) // for each byte a correspondent binary bit representation (with 8 bits)
        {
            var innerByte = chain[i];
            if (_8bitGroupCache.TryGetValue(innerByte, out var existing8BitGroup))
            {
                existing8BitGroup.CopyTo(packedBits, i * _fixedSizeArr); continue;
                
            }
            
            var _8bitGroup = FromByte(innerByte);
            
            _8bitGroup.CopyTo(packedBits, i * _fixedSizeArr);
            
            _8bitGroupCache.Add(innerByte, _8bitGroup);
        }

        return packedBits;
    }
    
    // this function is executed one time per Byte (innerByte)
    private static int[] FromByte(byte b, bool padding = false)   
    {
        // Abstract the byte component (?)
        int[] bits = new[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        
        int dividend = b; 
        var tail = bits.Length - 1; 
        while (dividend > 0)
        {
            var remainder = dividend % 2; 
            dividend = dividend / 2; 
            
            bits[tail] = remainder; tail--;
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