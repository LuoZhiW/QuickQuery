using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QuickQuery.ORM
{
    /// <summary>
    /// 域名比较器,支持泛解析。
    /// </summary>
    public class DomainEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            bool flag = string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y);
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = x == y;
                if (flag2)
                {
                    result = true;
                }
                else
                {
                    bool flag3 = x.StartsWith("*");
                    if (flag3)
                    {
                        Regex regex = new Regex(".+" + x.Substring(1).Replace(".", "\\."));
                        bool flag4 = regex.IsMatch(y);
                        result = flag4;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
