using System.Collections.Generic;

namespace app.web.application.store_browsing
{
  public interface IGetProducts
  {
    IEnumerable<ProductLineItem> get_products_in(SubCategoryListingInput category);
  }
}