using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.store_browsing
{
  public class ViewReport<Item> : ISupportAUserFeature
  {
    IRenderInformation response;
    IQueryForDataUsingTheRequest<Item> query;

    public ViewReport(IQueryForDataUsingTheRequest<Item> query, IRenderInformation response)
    {
      this.query = query;
      this.response = response;
    }

    public ViewReport(IQueryForAReport<Item> query):this(query.query_using,
      new WebFormResponseEngine())
    {
    }

    public ViewReport(IQueryForDataUsingTheRequest<Item> query):this(query,
      new WebFormResponseEngine())
    {
      this.query = query;
    }

    public void process(IProvideDetailsAboutTheRequest request)
    {
      response.display(query(request));
    }
  }
}