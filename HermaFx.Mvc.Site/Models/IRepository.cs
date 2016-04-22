using System.Linq;

namespace HermaFx.Mvc.Site.Models
{
    public interface IRepository<out T>
    {
        IOrderedQueryable<T> GetAll();
        T GetById(object id);
    }
}