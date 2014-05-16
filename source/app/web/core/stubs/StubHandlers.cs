using System.Collections;
using System.Collections.Generic;
using app.web.application.store_browsing;

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
      yield return new SingleRequestHandler(x => true, new ViewCategoryProducts());
      yield return new SingleRequestHandler(x => true, new ViewMainCategories());
    }
  }
}