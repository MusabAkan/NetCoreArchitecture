﻿using System.Linq.Expressions;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories
{
    public interface IRepository<TEntity, TEntityId> : IQuery<TEntity>
        where TEntity : Entity<TEntityId>
    {
        TEntity? Get(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? incluede = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);

        Paginate<TEntity> GetList(
            Expression<Func<TEntity, bool>>? predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? incluede = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);
        Paginate<TEntity> GetListByDynamic(
            DynamicQuery dynamic,
            Expression<Func<TEntity, bool>>? predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? incluede = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);

        bool Any(
            Expression<Func<TEntity, bool>>? predicate,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);

        TEntity Add(TEntity entity);
        ICollection<TEntity> AddRange(ICollection<TEntity> entity);
        TEntity Update(TEntity entity);
        ICollection<TEntity> UpdateRange(ICollection<TEntity> entity);
        TEntity Delete(TEntity entity, bool permanent = false);
        ICollection<TEntity> DeleteRange(ICollection<TEntity> entity, bool permanent = false)
    }
}