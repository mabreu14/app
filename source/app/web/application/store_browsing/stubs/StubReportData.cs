using System;
using System.Collections.Generic;
using System.Linq;

namespace app.web.application.store_browsing.stubs
{
  public class StubReportData :
    IGetCategories,
    IGetSubCategories,
    IGetProducts
  {
    public IEnumerable<CategoryLineItem> get_main_categories()
    {
      return generate(x => new CategoryLineItem {name = x.ToString("Category 0")});
    }

    public IEnumerable<CategoryLineItem> get_categories_in(SubCategoryListingInput parent)
    {
      return generate(x => new CategoryLineItem {name = x.ToString("Sub Category 0")});
    }

    public IEnumerable<ProductLineItem> get_products_in(SubCategoryListingInput parent)
    {
      return generate(
        x =>
          new ProductLineItem
          {
            name = x.ToString("Product 0"),
            description = "This is a Hello",
            price = 100,
            quantity = 50
          });
    }

    IEnumerable<T> generate<T>(Func<int, T> factory)
    {
      return generate(1000, factory);
    }

    IEnumerable<T> generate<T>(int number_to_generate, Func<int, T> factory)
    {
      return Enumerable.Range(1, number_to_generate).Select(factory);
    }
  }
}