namespace ExpenseMonitor.AppManagement
{
  public interface ISpecification<T>
  {
    bool IsSatisfied( T t );
  }
}