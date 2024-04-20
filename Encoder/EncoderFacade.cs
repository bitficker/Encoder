

using Encoder.Convert;

namespace Encoder
{
    
    public static class Encoding
    {

        public static void Base32(string chain)
        {
            byte[] convertedChain = Ascii.Encode(chain);
            
            
            
            Console.WriteLine("Hello World!");
        }
        
        
    }
}

