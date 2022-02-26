namespace Iwentys.EntityManager.DataAccess;

public interface ISpecification<in T, out TResult>
{
    IQueryable<TResult> Specify(IQueryable<T> queryable);
}