using System.Web;

namespace app.web.core.aspnet
{
  public interface ICreateAspTemplateInstances
  {
    IHttpHandler create_template_instance_to_render<Report>(Report report);
  }
}