namespace Encoder.Interfaces;

internal  static class Encoder
{
    public abstract static char[] FromAscii(string chain);

    public abstract void FromUtf8(); 
    
    protected abstract void Encode(int[] inBuff, char[] outBuff);
}