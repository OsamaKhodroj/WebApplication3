namespace Infrastcature;

public class Encryption
{
    public static string Hash(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentException("Input cannot be null or empty", nameof(input));

        var hash = BCrypt.Net.BCrypt.HashPassword(input);
        return hash;
    }


    public static bool Verify(string input, string hash)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentException("Input cannot be null or empty", nameof(input));
        if (string.IsNullOrEmpty(hash))
            throw new ArgumentException("Hash cannot be null or empty", nameof(hash));


        return BCrypt.Net.BCrypt.Verify(input, hash);
    }
}
