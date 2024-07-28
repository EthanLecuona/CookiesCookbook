using System.Text.Json;

namespace Cookies_Cookbook.DataAccess;

public class StringJSONRepository : StringRepository
{
    protected override string StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToStrings(string fileContent)
    {
        var result = JsonSerializer.Deserialize<List<string>>(fileContent);
        return result is not null ? result : new List<string>();
    }
}
