
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

            var encoding = new Encoding();
            char[] fromBin = new char[chain.Length / base32Encoder.FixedPackSize];
            encoding.Base32Encoder(inBuff: converted, outBuff: fromBin);
            
            
            
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

