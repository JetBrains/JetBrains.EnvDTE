namespace System.Runtime.InteropServices;

public static class Marshal
{
    public static void ThrowExceptionForHR(int errorCode)
    {
        if (errorCode >= 0)
        {
            return;
        }

        throw new Exception($"Exception from HRESULT: 0x{errorCode:X8}");
    }
}
