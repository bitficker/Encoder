namespace Encoder.Convert;


internal static class Ascii
{

    internal static byte[] Encode(string chain)
    {
        byte[] sbytes = new byte[chain.Length];

        for (var i = 0; i < chain.Length; i++)
        {
            var v = (byte)chain[i];
            
            Console.WriteLine("v:"+ v);

            if (v > 127)
                throw new InvalidOperationException();
            
            sbytes[i] = v;
            
        }

        return sbytes;
    }

    internal static string Decode(byte[] chain) => String.Empty;
    

}