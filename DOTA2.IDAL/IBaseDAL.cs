using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DOTA2.IDAL
{
    public partial interface IBaseDAL<T> where T : class, new()
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        void Add(T t);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        void Delete(T t);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        void Update(T t);

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
        /// <param name="PageIndex"></param>
        /// <param name="IsAsc"></param>
        /// <param name="OrderByLambda"></param>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetModelsByPage<type>(int PageSize, int PageIndex, bool IsAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda);

        /// <summary>
        /// 一个业务中有可能涉及到对多张表的操作,那么可以将操作的数据,打上相应的标记,最后调用该方法,将数据一次性提交到数据库中,避免了多次链接数据库。
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
