

using System.Net.Sockets;

namespace Encoder.Convert;


public static class BinConverter
{
    private static ushort _fixedSizeArr = 8; 
    internal static int[] FromBytes(byte[] chain)
    { 
        
        int[] packedBits = new int[chain.Length * 8];
        for (var i = 1; i <= chain.Length * 8; i++)
        {
            var fromByte = FromByte(chain[i]);

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