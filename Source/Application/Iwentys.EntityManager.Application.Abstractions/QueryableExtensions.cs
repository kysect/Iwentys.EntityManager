﻿using System.Linq.Expressions;

namespace Iwentys.EntityManager.Application.Abstractions;

public static class QueryableExtensions
{
    public static IQueryable<T> WhereIf<T, TFilter>(this IQueryable<T> query, TFilter? filter, Expression<Func<T, bool>> func)
        where TFilter : struct
    {
        return filter is null
            ? query
            : query.Where(func);
    }

    public static IQueryable<TResult> Specify<T, TResult>(this IQueryable<T> query, ISpecification<T, TResult> spec) where T : class
    {
        ArgumentNullException.ThrowIfNull(spec);

        return spec.Specify(query);
    }
}