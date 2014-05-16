using System.Web;

namespace app.web.core.aspnet
{
  public delegate IProvideDetailsAboutTheRequest ICreateARequestFromAspNetRequests(HttpContext context);
}