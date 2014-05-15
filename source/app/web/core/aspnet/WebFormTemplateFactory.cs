using System.Web;
using System.Web.Compilation;
using app.web.core.aspnet.stubs;

namespace app.web.core.aspnet
{
  public class WebFormTemplateFactory : ICreateAspTemplateInstances
  {
    IGetAPathToATemplate template_paths;
    ICreatePageInstances page_factory;

    public WebFormTemplateFactory() : this(new StubTemplatePathRegistry(),
      BuildManager.CreateInstanceFromVirtualPath)
    {
    }

    public WebFormTemplateFactory(IGetAPathToATemplate template_paths, ICreatePageInstances page_factory)
    {
      this.template_paths = template_paths;
      this.page_factory = page_factory;
    }

    public IHttpHandler create_template_instance_to_render<Report>(Report report)
    {
      var path = template_paths.get_path_to_template_for<Report>();
      var template_instance = (IDisplayA<Report>) page_factory(path, typeof(IDisplayA<Report>));
      template_instance.report = report;
      return template_instance;
    }
  }
}