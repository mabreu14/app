using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormResponseEngine : IRenderInformation
  {
    ICreateAspTemplateInstances template_factory;
    IGetTheCurrentlyExecutingContext current_context;

    public WebFormResponseEngine():this(() => HttpContext.Current, new WebFormTemplateFactory())
    {
    }

    public WebFormResponseEngine(IGetTheCurrentlyExecutingContext current_context, ICreateAspTemplateInstances template_factory)
    {
      this.current_context = current_context;
      this.template_factory = template_factory;
    }

    public void display<Report>(Report model)
    {
      var template_instance = template_factory.create_template_instance_to_render(model);
      template_instance.ProcessRequest(current_context());
    }
  }
}