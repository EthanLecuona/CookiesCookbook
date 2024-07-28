using System;
using System.Collections.Generic;
namespace Cookies_Cookbook.DataAccess;

public interface IStringRepository
{
    List<string> Read(string filePath);
    void Write(string filePath, List<string> strings);
}
