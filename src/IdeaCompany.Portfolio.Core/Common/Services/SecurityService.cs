namespace IdeaCompany.Portfolio.Core.Common.Services;

public static class SecurityService
{
    public static string Encrypt(this string password)
    {
        var encrypted = System.Text.Encoding.Unicode.GetBytes(password);
        var result = Convert.ToBase64String(encrypted);
        
        return result;
    }
    
    public static string Decrypt(this string password)
    {
        var decrypted = Convert.FromBase64String(password);
        var result = System.Text.Encoding.Unicode.GetString(decrypted);
     
        return result;
    }
}