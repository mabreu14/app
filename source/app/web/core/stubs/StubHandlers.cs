using System.Collections;
using System.Collections.Generic;
using app.web.application.store_browsing;
using app.web.application.store_browsing.stubs;

namespace app.web.core.stubs
{
  public class StubHandlers : IEnumerable<IProcessOneWebRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessOneWebRequest> GetEnumerator()
    {
      yield return create_viewer_for(new GetCategoryProducts());
      yield return create_viewer_for(new GetSubCategories());
      yield return create_viewer_for(new GetTheMainCategories());
    }

    IProcessOneWebRequest create_viewer_for<Report>(IQueryForAReport<Report> query)
    {
      return create_viewer_for(query.query_using);
    }

    IProcessOneWebRequest create_viewer_for<Report>(IQueryForDataUsingTheRequest<Report> query)
    {
      return new SingleRequestHandler(x => true,
        new ViewReport<Report>(query));
    }

    public class GetTheMainCategories : IQueryForAReport<IEnumerable<CategoryLineItem>>
    {
      public IEnumerable<CategoryLineItem> query_using(IProvideDetailsAboutTheRequest request)
      {
        return new StubReportData().get_main_categories();
      }
    }

    public class GetSubCategories : IQueryForAReport<IEnumerable<CategoryLineItem>>
    {
      public IEnumerable<CategoryLineItem> query_using(IProvideDetailsAboutTheRequest request)
      {
        return new StubReportData().get_categories_in(request.map<SubCategoryListingInput>());
      }
    }

    public class GetCategoryProducts : IQueryForAReport<IEnumerable<ProductLineItem>>
    {
      public IEnumerable<ProductLineItem> query_using(IProvideDetailsAboutTheRequest request)
      {
        return new StubReportData().get_products_in(request.map<SubCategoryListingInput>());
      }
    }
  }
}
