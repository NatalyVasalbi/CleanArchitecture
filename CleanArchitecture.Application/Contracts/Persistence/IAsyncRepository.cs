using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T: BaseDomainModel
    {
        // Interface que va a tomar valores genericos desde T, donde T, la implementacion de la clase viene o debe ser de tipo BaseDomainModel que es la clave que definimos en el Domain

        // la T representa el tipo de objeto que va a devolver
        Task<IReadOnlyList<T>> GetAllAsync(); // ReadOnlYList<T> porque me va a devolver una lista generica y T por el objeto que va a devolver
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate); // le pasamos la condicion logica usando Expression Functions- Expression<Func<T, tipoDeValorQueVaDevolver>>
                                                                              // le vamos a pasar un obj del tipo expression, que a su vez contiene un Func y un bool y esa expression se va a transformar a futuro en una expression del tipo SQL, 
                                                                              // para luego ejecutar la query en la BD
        // ordenamiento
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
        string? includeString = null,
        bool disableTracking = true);
        // paginacion
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
        List<Expression<Func<T,object>>>? includes =null,
        bool disableTracking = true);
        //Query para hacer la consulta por id
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }




}
