using System.Collections.Generic;

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

        /// <summary>
        /// Equals。
        /// </summary>
        /// <param name="x">x。</param>
        /// <param name="y">y。</param>
        /// <returns></returns>
        public bool Equals(string x, string y)
        {
            return x.ToUpper() == y.ToUpper();
        }

        /// <summary>
        /// GetHashCode。
        /// </summary>
        /// <param name="obj">obj。</param>
        /// <returns></returns>
        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
