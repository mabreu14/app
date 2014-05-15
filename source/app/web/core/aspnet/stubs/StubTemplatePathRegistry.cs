using System;
using System.Collections.Generic;
using app.web.application.store_browsing;

namespace app.web.core.aspnet.stubs
{
  public class StubTemplatePathRegistry : IGetAPathToATemplate
  {
    public string get_path_to_template_for<Report>()
    {
      var paths = new Dictionary<Type, string>
      {
        {typeof(IEnumerable<CategoryLineItem>), "~/views/DepartmentBrowser.aspx"}
      };

      if (paths.ContainsKey(typeof(Report ))) return paths[typeof(Report)];

      throw new NotImplementedException("There is no template for the report");
    }
  }
}