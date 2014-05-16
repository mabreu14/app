using app.web.application.store_browsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.store_browsing
{
  public class ViewSubCategories : ISupportAUserFeature
  {
    IGetSubCategories sub_categories;
    IRenderInformation response;

    public ViewSubCategories(IRenderInformation response, IGetSubCategories sub_categories)
    {
      this.response = response;
      this.sub_categories = sub_categories;
    }

    public ViewSubCategories():this(new WebFormResponseEngine(),
      new StubReportData())
    {
    }

    public void process(IProvideDetailsAboutTheRequest request)
    {
      this.response.display(sub_categories.get_categories_in(request.map<SubCategoryListingInput>()));
    }
  }
}