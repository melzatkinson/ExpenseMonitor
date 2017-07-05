namespace ExpenseMonitor.AppManagement
{
  public class AndSpecification<T> : ISpecification<T>
  {
    private readonly ISpecification<T> _specification1;
    private readonly ISpecification<T> _specification2;

    public AndSpecification( ISpecification<T> specification1, ISpecification<T> specification2 )
    {
      _specification1 = specification1;
      _specification2 = specification2;
    }

    public bool IsSatisfied( T t )
    {
      return _specification1.IsSatisfied( t ) && _specification2.IsSatisfied( t );
    }
  }
}
