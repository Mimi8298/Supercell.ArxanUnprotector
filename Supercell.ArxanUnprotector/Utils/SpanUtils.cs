namespace Supercell.ArxanUnprotector.Utils;

public static class SpanUtils
{
    public static bool Contains(this ReadOnlySpan<byte> span, ReadOnlySpan<byte> values)
    {
        for (int i = 0; i < span.Length - values.Length; i++)
        {
            bool notFound = false;
            
            for (int j = values.Length - 1; j >= 0; j--)
            {
                if (span[i + j] != values[j])
                {
                    notFound = true;
                    break;
                }
            }
            
            if (!notFound)
                return true;
        }
        
        return false;
    }
}