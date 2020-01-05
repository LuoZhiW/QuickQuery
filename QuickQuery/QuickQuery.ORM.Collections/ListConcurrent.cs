using System.Collections;
using System.Collections.Generic;

namespace QuickQuery.ORM.Collections
{
    /// <summary>
    /// 缓存管理。
    /// </summary>
    public class ListConcurrent
    {
        protected Hashtable CacheBuffer = Hashtable.Synchronized(new Hashtable());

        public object this[object key]
        {
            get
            {
                bool flag = this.CacheBuffer.ContainsKey(key);
                object result;
                if (flag)
                {
                    result = this.CacheBuffer[key];
                }
                else
                {
                    result = null;
                }
                return result;
            }
            set
            {
                this.Update(key, value);
            }
        }

        /// <summary>
        /// 添加一个对象(存在不添加)
        /// </summary>
        /// <param name="key">添加对象的键(唯一)</param>
        /// <param name="value">添加对象的值</param>
        public void Add(object key, object value)
        {
            bool flag = !this.CacheBuffer.ContainsKey(key);
            if (flag)
            {
                this.CacheBuffer.Add(key, value);
            }
        }

        /// <summary>
        /// 移除指定的对象
        /// </summary>
        /// <param name="key">移除对象的键(唯一)</param>
        public void Remove(object key)
        {
            bool flag = this.CacheBuffer.ContainsKey(key);
            if (flag)
            {
                this.CacheBuffer.Remove(key);
            }
        }

        /// <summary>
        /// 是否包含对象
        /// </summary>
        /// <param name="key">判断对象的键(唯一)</param>
        /// <returns>存在返回true,否则返回false</returns>
        public bool Exist(object key)
        {
            return this.CacheBuffer.ContainsKey(key);
        }

        /// <summary>
        /// 获取对应的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetValue(object key)
        {
            bool flag = this.CacheBuffer.ContainsKey(key);
            object result;
            if (flag)
            {
                result = this.CacheBuffer[key];
            }
            else
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// 更新值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void Update(object key, object value)
        {
            bool flag = this.CacheBuffer.ContainsKey(key);
            if (flag)
            {
                this.CacheBuffer[key] = value;
            }
        }

        public List<object> GetList()
        {
            List<object> list = new List<object>();
            ArrayList arrayList = new ArrayList(this.CacheBuffer.Keys);
            foreach (object current in arrayList)
            {
                list.Add(this.CacheBuffer[current]);
            }
            return list;
        }
    }
}
