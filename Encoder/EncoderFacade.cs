
using Encoder.Convert;

namespace Encoder
{
    
    // Turn into static
    public class EncoderFacade
    {
        p

        public void Base32(string chain)
        {
            byte[] convertedAsciiChain = Ascii.Encode(chain);
            
            var convertedBin = BinConverter.FromBytes(convertedAsciiChain);

            var encoding = new Encoding();
            char[] fromBin = new char[chain.Length / encoding.Fixed32PackSize];
            encoding.Base32Encoder(inBuff: convertedBin, outBuff: fromBin);
            
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

