using System.Web;

namespace app.web.core.aspnet
{
  public class AspNetRequestHandler : IHttpHandler
  {
    IProcessOneWebRequest request_handler;
    ICreateARequestFromAspNetRequests request_factory;

    public AspNetRequestHandler(IProcessOneWebRequest request_handler, ICreateARequestFromAspNetRequests request_factory)
    {
      this.request_handler = request_handler;
      this.request_factory = request_factory;
    }
    public void ProcessRequest(HttpContext context)
    {
      request_handler.process(request_factory(context));
    }

    public bool IsReusable { get; private set; }
  }
}