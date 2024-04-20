
using Encoder.Convert;

namespace Encoder
{
    
    public class EncoderFacade
    {
        private Bin _bin { get; set; } = new();

        public void Base32(string chain)
        {
            byte[] convertedAsciiChain = Ascii.Encode(chain);
            
            var converted = _bin.FromBytes(convertedAsciiChain);
            
            char[] fromBin = new char[chain.Length / _fixedPackSize];
            
            
            
        }
        
        // public void Base64(string chain)
        // {
        //     byte[] convertedAsciiChain = Ascii.Encode(chain);
        //     var encoded = _bin.Run(convertedAsciiChain);
        //     
        //     
        // }
        
        
    }
}

