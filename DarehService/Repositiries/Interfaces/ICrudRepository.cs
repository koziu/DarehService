using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarehService.API.Repositiries.Interfaces
{
  public interface ICrudRepository<T> : IDisposable where T : class
  {
    IEnumerable<T> GetAll();
    Task<T> GetById(string id);
    Task<T> Get(T entity);
    Task<bool> Insert(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(T entity);
    Task<bool> SaveChanges();
  }
}
