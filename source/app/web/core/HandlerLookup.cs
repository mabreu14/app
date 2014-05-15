using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class HandlerLookup : IFindHandlersToProcessRequests
  {
    IEnumerable<IProcessOneWebRequest> all_handlers;
    ICreateAHandlerForAnUncofiguredRequest create_missing_request_handler;

    public HandlerLookup(IEnumerable<IProcessOneWebRequest> all_handlers,
      ICreateAHandlerForAnUncofiguredRequest create_missing_request_handler)
    {
      this.all_handlers = all_handlers;
      this.create_missing_request_handler = create_missing_request_handler;
    }

    public IProcessOneWebRequest get_the_handler_for(IProvideDetailsAboutTheRequest request)
    {
      return all_handlers.FirstOrDefault(x => x.can_handle(request)) ?? create_missing_request_handler(request);
    }
  }
}