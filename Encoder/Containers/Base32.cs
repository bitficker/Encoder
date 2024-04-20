using Encoder.Convert;

namespace Encoder.Containers;

public static class Base32 
{
    
    private const ushort Fixed32PackSize = 5;
    
    private static readonly string Base32Table = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

    public static char[] FromAscii(string chain)
    {
        byte[] convertedAscii = new byte[chain.Length];

        var ctr = 0; // Legibilidade +
        foreach (var c in chain) // Legibilidade
        {
            var v = (byte)c;
            
            Console.WriteLine("v:"+ v);

            if (v > 127)
                throw new InvalidOperationException();
            
            convertedAscii[ctr] = v;
            ctr++;
        }
        
        var convertedBin = BinConverter.FromBytes(convertedAscii);
        char[] fromBin = new char[chain.Length / Fixed32PackSize];
        
        Encode(inBuff: convertedBin, outBuff: fromBin);
        
        return fromBin;
    }
    
    private static void Encode(int[] inBuff, char[] outBuff)
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
            var unpackedByte = BinConverter.ToByte(inBuff[new Range(i, i + Fixed32PackSize)]);
            
            // mapear para tabela base32
            outBuff[i] = Base32Table[unpackedByte];
            
        }
        
    }

    public static void FromUtf8() => throw new NotImplementedException(); 
    
}