using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DOTA2.IBLL
{
    public partial interface IBaseService<T> where T : class, new()
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        bool Add(T t);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Delete(T t);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update(T t);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetModels(Expression<Func<T, bool>> WhereLambda);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex">页码</param>
        /// <param name="IsAsc">是否升序</param>
        /// <param name="OrderByLambda"></param>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetModelsByPage<type>(int PageSize, int PageIndex, bool IsAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda);
    }
}
