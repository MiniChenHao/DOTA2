using DOTA2.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DOTA2.BLL
{
    public abstract partial class BaseService<T> where T : class, new()
    {
        public BaseService()
        {
            SetDal();
        }

        public IBaseDAL<T> Dal { get; set; }

        public abstract void SetDal();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Add(T t)
        {
            Dal.Add(t);
            return Dal.SaveChanges();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Delete(T t)
        {
            Dal.Delete(t);
            return Dal.SaveChanges();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update(T t)
        {
            Dal.Update(t);
            return Dal.SaveChanges();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetModels(Expression<Func<T, bool>> WhereLambda)
        {
            return Dal.GetModels(WhereLambda);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="IsAsc"></param>
        /// <param name="OrderByLambda"></param>
        /// <param name="WHereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetModelsByPage<type>(int PageSize, int PageIndex, bool IsAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WHereLambda)
        {
            return Dal.GetModelsByPage(PageSize, PageIndex, IsAsc, OrderByLambda, WHereLambda);
        }
    }
}
