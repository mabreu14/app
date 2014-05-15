namespace app.web.core
{
  public class RequestHandler : IProcessWebRequests
  {
    IFindHandlersToProcessRequests handlers;

    public RequestHandler(IFindHandlersToProcessRequests handlers)
    {
      this.handlers = handlers;
    }

    public RequestHandler():this(new HandlerLookup())
    {
    }

    public void process(IProvideDetailsAboutTheRequest request)
    {
      var handler = handlers.get_the_handler_for(request);
      handler.process(request);
    }
  }
}