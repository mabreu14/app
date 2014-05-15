using System.Web;
using app.web.core.stubs;

namespace app.web.core.aspnet
{
  public class AspNetRequestHandler : IHttpHandler
  {
    ICreateARequestFromAspNetRequests request_factory;
    IProcessWebRequests request_handler;

    public AspNetRequestHandler():this(WebDelegates.create_request, new RequestHandler())
    {
    }

    public AspNetRequestHandler(ICreateARequestFromAspNetRequests request_factory, IProcessWebRequests request_handler)
    {
      this.request_handler = request_handler;
      this.request_factory = request_factory;
    }

    public void ProcessRequest(HttpContext context)
    {
      request_handler.process(request_factory(context));
    }

    public bool IsReusable
    {
      get { return true; }
    }
  }
}