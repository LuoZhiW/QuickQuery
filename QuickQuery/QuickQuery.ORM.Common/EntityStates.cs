namespace QuickQuery.ORM.Common
{
    /// <summary>
    /// 数据记录的状态枚举，用于批量操作（UpdateList）
    /// </summary>
    public enum EntityStates
    {
        /// <summary>
        /// 待新增状态
        /// </summary>
        ToBeAdd,
        /// <summary>
        /// 待删除状态
        /// </summary>
        ToBeDelete,
        /// <summary>
        /// 待修改状态
        /// </summary>
        ToBeUpdated,
        /// <summary>
        /// 原始状态
        /// </summary>
        Original
    }
}
