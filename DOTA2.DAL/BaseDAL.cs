using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DOTA2.DAL
{
    public partial class BaseDAL<T> where T : class, new()
    {
        private DbContext dbContext = DbContextFactory.Create();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        public void Add(T t)
        {
            dbContext.Set<T>().Add(t);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        public void Delete(T t)
        {
            dbContext.Set<T>().Remove(t);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        public void Update(T t)
        {
            dbContext.Set<T>().AddOrUpdate(t);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetModels(Expression<Func<T, bool>> WhereLambda)
        {
            return dbContext.Set<T>().Where(WhereLambda);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="IsAsc">是否升序</param>
        /// <param name="OrderByLambda"></param>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetModelsByPage<type>(int PageSize, int PageIndex, bool IsAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            if (IsAsc)
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((PageIndex - 1) * PageSize).Take(PageSize);
            }
            else
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((PageIndex - 1) * PageSize).Take(PageSize);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}
