using System.Collections.Generic;

namespace ExpenseMonitor.AppManagement
{
  public interface IFilter<T>
  {
    IEnumerable<T> Filter( IEnumerable<T> items, ISpecification<T> spec );
  }
}