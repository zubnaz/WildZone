namespace Application.Helpers;

public static class CodeGenerator
{
    private static readonly Random random = new Random();
    public static string GenerateCode()
    {
        var code = String.Empty;
        for (int i = 0; i < 7; i++)
            code += random.Next(0, 10).ToString();
        return code;
    }
}
