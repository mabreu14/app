using app.web.core;

namespace app.web.application.store_browsing
{
  public class ViewSubCategories : ISupportAUserFeature
  {
    IGetSubItemsOFCategories<CategoryLineItem> sub_categories;
    IRenderInformation response;

    public ViewSubCategories(IRenderInformation response, IGetSubItemsOFCategories<CategoryLineItem> sub_categories)
    {
      this.response = response;
      this.sub_categories = sub_categories;
    }

    public void process(IProvideDetailsAboutTheRequest request)
    {
      this.response.display(sub_categories.get_categories_in(request.map<SubCategoryListingInput>()));
    }
  }
}