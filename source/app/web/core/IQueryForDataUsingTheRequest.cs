namespace app.web.core
{
  public delegate Report IQueryForDataUsingTheRequest<Report>(IProvideDetailsAboutTheRequest request);

  public interface IQueryForAReport<Report>
  {
    Report query_using(IProvideDetailsAboutTheRequest request); 
  }
}