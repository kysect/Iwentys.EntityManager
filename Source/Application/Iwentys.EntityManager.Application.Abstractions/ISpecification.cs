namespace Iwentys.EntityManager.Application.Abstractions;

public interface ISpecification<in T, out TResult>
{
    IQueryable<TResult> Specify(IQueryable<T> queryable);
}