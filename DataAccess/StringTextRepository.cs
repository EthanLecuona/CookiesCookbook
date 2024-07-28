namespace Cookies_Cookbook.DataAccess;

public class StringTextRepository : StringRepository
{
    private static readonly string Seperator = Environment.NewLine;
    protected override string StringsToText(List<string> strings)
    {
        return string.Join(Seperator, strings);
    }

    protected override List<string> TextToStrings(string fileContent)
    {
        return fileContent.Split(Seperator).ToList();
    }
}
