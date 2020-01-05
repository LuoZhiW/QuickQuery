using System;
using System.ComponentModel;
using System.Text;

namespace QuickQuery.ORM.Common
{
    /// <summary>
    /// 相同对象复制
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// 实体同名的属性的值,
        /// </summary>
        public static void SetModelValue(this object entity, object value)
        {
            try
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value.GetType());
                PropertyDescriptorCollection properties2 = TypeDescriptor.GetProperties(entity.GetType());
                foreach (PropertyDescriptor propertyDescriptor in properties2)
                {
                    PropertyDescriptor propertyDescriptor2 = properties.Find(propertyDescriptor.Name, false);
                    bool flag = propertyDescriptor2 != null;
                    if (flag)
                    {
                        object value2 = propertyDescriptor2.GetValue(value);
                        propertyDescriptor.SetValue(entity, value2);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 实体之间相互转换,只对相同字段赋值,忽略大小写
        /// </summary>
        /// <typeparam name="Result">转换后的类型</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Result EntityConvert<Result>(this object entity)
        {
            Result result2;
            try
            {
                Result result = (Result)((object)Activator.CreateInstance(typeof(Result)));
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entity.GetType());
                PropertyDescriptorCollection properties2 = TypeDescriptor.GetProperties(typeof(Result));
                foreach (PropertyDescriptor propertyDescriptor in properties2)
                {
                    PropertyDescriptor propertyDescriptor2 = properties.Find(propertyDescriptor.Name, false);
                    bool flag = propertyDescriptor2 != null;
                    if (flag)
                    {
                        object value = propertyDescriptor2.GetValue(entity);
                        propertyDescriptor.SetValue(result, value);
                    }
                }
                result2 = result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result2;
        }

        /// <summary>
        /// 获取实体中所有公共属性,的键值对,不包含null的值,用;分隔(例:Name1=Value1;Name2=Value2;)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static StringBuilder EntityToGetKeyValue<T>(this T entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor propertyDescriptor in properties)
                {
                    object value = propertyDescriptor.GetValue(entity);
                    bool flag = value != null;
                    if (flag)
                    {
                        stringBuilder.Append(string.Format("{0}={1};", propertyDescriptor.Name, value));
                    }
                }
                bool flag2 = stringBuilder.Length > 1;
                if (flag2)
                {
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stringBuilder;
        }
    }
}
