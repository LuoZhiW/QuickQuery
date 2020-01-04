using System;
using System.Collections.Generic;
using System.Text;

namespace QuickQuery.ORM
{
    public class IEqualityComparerString: IEqualityComparer<string>
    {
        public static IEqualityComparerString Comparer
        {
            get
            {
                return new IEqualityComparerString();
            }
        }

        public bool Equals(string x, string y)
        {
            return x.ToUpper() == y.ToUpper();
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
