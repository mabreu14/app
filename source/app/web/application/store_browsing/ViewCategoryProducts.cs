using app.web.application.store_browsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.store_browsing
{
  public class ViewCategoryProducts : ISupportAUserFeature
  {
     IGetSubItemsOFCategories<ProductLineItem> products;
    IRenderInformation response;


    public ViewCategoryProducts(): this(new WebFormResponseEngine(), new StubProducts())
    {
    }

    public ViewCategoryProducts(IRenderInformation response, IGetSubItemsOFCategories<ProductLineItem> products)
    {
      this.response = response;
      this.products = products;
    }

    public void process(IProvideDetailsAboutTheRequest request)
    {
        this.response.display(products.get_categories_in(request.map<SubCategoryListingInput>()));
    }

  }
}