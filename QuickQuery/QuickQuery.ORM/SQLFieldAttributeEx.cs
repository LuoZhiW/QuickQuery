using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QuickQuery.ORM
{
    public sealed class SQLFieldAttributeEx
    {
        /// <summary>
        /// 是否忽略sql字段
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool GetIsIgnore(object[] item)
        {
            bool flag = item == null || item.Length == 0;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                for (int i = 0; i < item.Length; i++)
                {
                    object obj = item[i];
                    bool flag2 = obj.GetType() == typeof(SQLFieldAttribute);
                    if (flag2)
                    {
                        SQLFieldAttribute sQLFieldAttribute = (SQLFieldAttribute)obj;
                        result = sQLFieldAttribute.IsIgnore;
                        return result;
                    }
                }
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 是否忽略sql字段
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool GetIsIgnore(AttributeCollection item)
        {
            bool flag = item == null || item.Count == 0;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                foreach (object current in item)
                {
                    bool flag2 = current.GetType() == typeof(SQLFieldAttribute);
                    if (flag2)
                    {
                        SQLFieldAttribute sQLFieldAttribute = (SQLFieldAttribute)current;
                        result = sQLFieldAttribute.IsIgnore;
                        return result;
                    }
                }
                result = false;
            }
            return result;
        }
    }
}
