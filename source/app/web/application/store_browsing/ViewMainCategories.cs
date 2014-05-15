using app.web.core;

namespace app.web.application.store_browsing
{
  public class ViewMainCategories : ISupportAUserFeature
  {
    IGetCategories categories;
    IRenderInformation response;

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