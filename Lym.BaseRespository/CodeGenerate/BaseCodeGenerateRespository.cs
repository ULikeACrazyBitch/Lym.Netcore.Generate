using Lym.BaseRespository.Extensions;
using Lym.Core.CodeGenerate;
using Lym.Core.DatabaseOne;
using Lym.Model.ApiResult;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Lym.BaseRespository.DatabaseOne
{
    /// <summary>
    /// 仓储基类实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseCodeGenerateRespository<T> : CodeGenerateContext<T>, IBaseRespository<T> where T : class, new()
    {
        public SqlSugarClient GetInstance(DbType type, string connection)
        {
            return new SqlSugarClient(new ConnectionConfig()
            {
                DbType = type,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true,
                ConnectionString = connection
            });
        }


        #region 事务

        /// <summary>
        /// 启用事务
        /// </summary>
        public void BeginTran()
        {
            base.Context.Ado.BeginTran();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTran()
        {
            base.Context.Ado.CommitTran();
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTran()
        {
            base.Context.Ado.RollbackTran();
        }

        #endregion

        #region 添加操作
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="parm">T</param>
        /// <returns></returns>
        public int Add(T parm)
        {
            return base.Context.Insertable(parm).RemoveDataCache().ExecuteCommand();
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="parm">List<T></param>
        /// <returns></returns>
        public int Add(List<T> parm)
        {
            return base.Context.Insertable(parm).RemoveDataCache().ExecuteCommand();
        }

        /// <summary>
        /// 添加或更新数据
        /// </summary>
        /// <param name="parm">List<T></param>
        /// <returns></returns>
        public T Saveable(T parm, Expression<Func<T, object>> uClumns = null, Expression<Func<T, object>> iColumns = null)
        {
            var command = base.Context.Saveable(parm);

            if (uClumns != null)
            {
                command = command.UpdateIgnoreColumns(uClumns);
            }

            if (iColumns != null)
            {
                command = command.InsertIgnoreColumns(iColumns);
            }

            return command.ExecuteReturnEntity();
        }

        /// <summary>
        /// 批量添加或更新数据
        /// </summary>
        /// <param name="parm">List<T></param>
        /// <returns></returns>
        public List<T> Saveable(List<T> parm, Expression<Func<T, object>> uClumns = null, Expression<Func<T, object>> iColumns = null)
        {
            var command = base.Context.Saveable(parm);

            if (uClumns != null)
            {
                command = command.UpdateIgnoreColumns(uClumns);
            }

            if (iColumns != null)
            {
                command = command.InsertIgnoreColumns(iColumns);
            }

            return command.ExecuteReturnList();
        }
        #endregion

        #region 查询操作

        /// <summary>
        /// 根据条件查询数据是否存在
        /// </summary>
        /// <param name="where">条件表达式树</param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> where)
        {
            return base.Context.Queryable<T>().Any(where);
        }

        /// <summary>
        /// 根据条件合计字段
        /// </summary>
        /// <param name="where">条件表达式树</param>
        /// <returns></returns>
        public TResult Sum<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> field)
        {
            return base.Context.Queryable<T>().Where(where).Sum(field);
        }

        /// <summary>
        /// 根据主值查询单条数据
        /// </summary>
        /// <param name="pkValue">主键值</param>
        /// <returns>泛型实体</returns>
        public T GetId(object pkValue)
        {
            return base.Context.Queryable<T>().InSingle(pkValue);
        }

        /// <summary>
        /// 根据主键查询多条数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<T> GetIn(object[] ids)
        {
            return base.Context.Queryable<T>().In(ids).ToList();
        }

        /// <summary>
        /// 根据条件取条数
        /// </summary>
        /// <param name="where">条件表达式树</param>
        /// <returns></returns>
        public int GetCount(Expression<Func<T, bool>> where)
        {
            return base.Context.Queryable<T>().Count(where);

        }

        /// <summary>
        /// 查询所有数据(无分页,请慎用)
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll(bool useCache = false, int cacheSecond = 3600)
        {
            return base.Context.Queryable<T>().WithCacheIF(useCache, cacheSecond).ToList();
        }

        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="where">Expression<Func<T, bool>></param>
        /// <returns></returns>
        public T GetFirst(Expression<Func<T, bool>> where)
        {
            return base.Context.Queryable<T>().Where(where).First();
        }

        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="parm">string</param>
        /// <returns></returns>
        public T GetFirst(string parm)
        {
            return base.Context.Queryable<T>().Where(parm).First();
        }


        /// <summary>
        /// 根据条件查询分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<T> GetPages(Expression<Func<T, bool>> where, PageParm parm)
        {
            var source = base.Context.Queryable<T>().Where(where);

            return source.ToPage(parm);
        }


        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="where">条件表达式树</param>
        /// <returns></returns>
        public List<T> GetWhere(Expression<Func<T, bool>> where, bool useCache = false, int cacheSecond = 3600)
        {
            var query = base.Context.Queryable<T>().Where(where).WithCacheIF(useCache, cacheSecond);
            return query.ToList();
        }

        /// <summary>
		/// 根据条件查询数据
		/// </summary>
		/// <param name="where">条件表达式树</param>
		/// <returns></returns>
        public List<T> GetWhere(Expression<Func<T, bool>> where, Expression<Func<T, object>> order, string orderEnum = "Asc", bool useCache = false, int cacheSecond = 3600)
        {
            var query = base.Context.Queryable<T>().Where(where).OrderByIF(orderEnum == "Asc", order, OrderByType.Asc).OrderByIF(orderEnum == "Desc", order, OrderByType.Desc).WithCacheIF(useCache, cacheSecond);
            return query.ToList();
        }

        #endregion

        #region 修改操作

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="parm">T</param>
        /// <returns></returns>
        public int Update(T parm)
        {
            return base.Context.Updateable(parm).RemoveDataCache().ExecuteCommand();
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="parm">T</param>
        /// <returns></returns>
        public int Update(List<T> parm)
        {
            return base.Context.Updateable(parm).RemoveDataCache().ExecuteCommand();
        }

        /// <summary>
        /// 按查询条件更新
        /// </summary>
        /// <param name="where"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public int Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> columns)
        {
            return base.Context.Updateable<T>().SetColumns(columns).Where(where).RemoveDataCache().ExecuteCommand();
        }

        #endregion

        #region 删除操作

        /// <summary>
        /// 删除一条或多条数据
        /// </summary>
        /// <param name="parm">string</param>
        /// <returns></returns>
        public int Delete(object id)
        {
            return base.Context.Deleteable<T>(id).RemoveDataCache().ExecuteCommand();
        }

        /// <summary>
        /// 删除一条或多条数据
        /// </summary>
        /// <param name="parm">string</param>
        /// <returns></returns>
        public int Delete(object[] ids)
        {
            return base.Context.Deleteable<T>().In(ids).RemoveDataCache().ExecuteCommand();
        }

        /// <summary>
        /// 根据条件删除一条或多条数据
        /// </summary>
        /// <param name="where">过滤条件</param>
        /// <returns></returns>
        public int Delete(Expression<Func<T, bool>> where)
        {
            return base.Context.Deleteable<T>().Where(where).RemoveDataCache().ExecuteCommand();
        }
        #endregion

    }
}
