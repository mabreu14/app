using app.web.application.store_browsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.store_browsing
{
  public class ViewMainCategories : ISupportAUserFeature
  {
    IGetCategories categories;
    IRenderInformation response;

    public ViewMainCategories() : this(new StubCategories(),
      new WebFormResponseEngine())
    {
    }

    public ViewMainCategories(IGetCategories categories, IRenderInformation response)
    {
      this.categories = categories;
      this.response = response;
    }

    public void process(IProvideDetailsAboutTheRequest request)
    {
      var results = categories.get_main_categories();
      response.display(results);
    }
  }
}