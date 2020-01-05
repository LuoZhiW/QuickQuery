using System;
using System.ComponentModel;

namespace QuickQuery.ORM.Common
{
    /// <summary>
    /// 数据记录基类
    /// </summary>
    [Serializable]
    public abstract class EntityBase<T>
    {
        /// <summary>
        /// 数据记录的状态，用于批量更新记录集（UpdateList）
        /// </summary>
        private EntityStates entityState = EntityStates.Original;

        /// <summary>
        /// 获取或设置数据记录的状态，用于批量更新记录集（UpdateList）
        /// </summary>
        public EntityStates EntityState
        {
            get
            {
                return this.entityState;
            }
            set
            {
                this.entityState = value;
            }
        }

        /// <summary>
        /// 实体之间相互转换,只对相同字段赋值,忽略大小写
        /// </summary>
        /// <typeparam name="T">转换后的类型</typeparam>
        /// <returns>返回转换后的对象</returns>
        public Result ToEntity<Result>()
        {
            return this.CurrentEntity().EntityConvert<Result>();
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="Result">要更新实体的类型</typeparam>
        /// <param name="t">要更新的实体</param>
        /// <returns>更新后的实体</returns>
        public Result UpdateToEntity<Result>(Result result)
        {
            try
            {
                T t = this.CurrentEntity();
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(t.GetType());
                PropertyDescriptorCollection properties2 = TypeDescriptor.GetProperties(typeof(Result));
                foreach (PropertyDescriptor propertyDescriptor in properties2)
                {
                    PropertyDescriptor propertyDescriptor2 = properties.Find(propertyDescriptor.Name, false);
                    bool flag = propertyDescriptor2 != null;
                    if (flag)
                    {
                        object value = propertyDescriptor2.GetValue(t);
                        propertyDescriptor.SetValue(result, value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 当前派生类
        /// </summary>
        /// <returns>返回派生类</returns>
        protected abstract T CurrentEntity();
    }
}
