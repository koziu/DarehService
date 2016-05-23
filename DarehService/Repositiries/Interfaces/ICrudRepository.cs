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
    T GetById(Guid id);
    T Get(T entity);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    void SaveChanges();
  }
}
