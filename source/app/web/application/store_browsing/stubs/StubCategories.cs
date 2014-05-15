using System.Collections.Generic;
using System.Linq;

namespace app.web.application.store_browsing.stubs
{
  public class StubCategories : IGetCategories
  {
    public IEnumerable<CategoryLineItem> get_main_categories()
    {
      return Enumerable.Range(1, 1000).Select(x => new CategoryLineItem{name = x.ToString("Category 0")});
    }
  }
}