using System.Text;
using Encoder.Containers;

namespace Encoder.Convert;


internal class Binary
{

    // Retornar um arr multidimensional com grupos de 5 bits
    internal string[][] Bin(byte[] chain, EncodingType encodingType)
    {
        var builder = new StringBuilder();

        if (encodingType is EncodingType.Base_32)
        {
            string[][] fiveBitGroupArr = new string[chain.Length][];

            for (var i = 0; i < chain.Length; i++)
            {
                var value = BinaryConversionByRecursiveDivision(chain[i]);
            }

            return fiveBitGroupArr;

        }
        else if (encodingType is EncodingType.Base_64)
        {
            // Implementar
            throw new NotImplementedException();
        }
        
        // return something
    }

    // Aplicar recursion
    private string[] BinaryConversionByRecursiveDivision(byte b)
    {
        
        string[] bits = new[] { "0", "0", "0", "0", "0", "0", "0", "0" };
        
        string remainder = (b % 2).ToString(); 
        UInt16 currQuotient = (ushort)(b / 2); 
        
        var ptr = 7;
        while (ptr >= 0)
        {
            remainder = (currQuotient % 2).ToString();
            currQuotient = (ushort)(currQuotient / 2); 

            bits[ptr] = remainder; ptr--;
            
        }

        return bits;

    }

    // private string DivideBy2()
    // {
    //     // var remainder = (quotient % 2).ToString();
    //     //     
    //     // quotient = b / 2;
    // }
    
}