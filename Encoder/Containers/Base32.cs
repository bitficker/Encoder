namespace Encoder.Containers;

public static class Base32
{
  

    public static char[] FromAscii(string chain)
    {
        byte[] convertedAscii = new byte[chain.Length];

        foreach (var c in chain)
        {
            var v = (byte)chain[i];
            
            Console.WriteLine("v:"+ v);

            if (v > 127)
                throw new InvalidOperationException();
            
            convertedAscii[i] = v;
            
        }
        
        var convertedBin = BinConverter.FromBytes(convertedAscii);
        char[] fromBin = new char[chain.Length / encoding.Fixed32PackSize];
        Encoder(inBuff: convertedBin, outBuff: fromBin);
        
        return fromBin;
    }
    
    private static void Encoder(int[] inBuff, char[] outBuff)
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

    public static void FromUtf8()
    {
        throw new NotImplementedException();
    }
    
   
    
}