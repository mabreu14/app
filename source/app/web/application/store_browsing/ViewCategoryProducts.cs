using app.web.application.store_browsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.store_browsing
{
  public class ViewCategoryProducts : ISupportAUserFeature
  {
    IGetProducts products;
    IRenderInformation response;

    public ViewCategoryProducts(IRenderInformation response, IGetProducts products)
    {
      this.response = response;
      this.products = products;
    }

    public ViewCategoryProducts():this(new WebFormResponseEngine(),
      new StubReportData())
    {
    }

    public void process(IProvideDetailsAboutTheRequest request)
    {
      this.response.display(products.get_products_in(request.map<SubCategoryListingInput>()));
    }
  }
}
