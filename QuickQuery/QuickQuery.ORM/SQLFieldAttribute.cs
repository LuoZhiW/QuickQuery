using System;

namespace QuickQuery.ORM
{
    public class SQLFieldAttribute: Attribute
    {
        /// <summary>
        /// 生成sql Select语句时是否忽略该字段。
        /// </summary>
        public bool IsIgnore
        {
            get;
            set;
        }

        public SQLFieldAttribute()
        {
            this.IsIgnore = false;
        }
    }
}
