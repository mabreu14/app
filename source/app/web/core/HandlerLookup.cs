using System.Collections.Generic;

namespace app.web.core
{
  public class HandlerLookup : IFindHandlersToProcessRequests
  {
    IEnumerable<IProcessOneWebRequest> all_handlers;

    public HandlerLookup(IEnumerable<IProcessOneWebRequest> all_handlers)
    {
      this.all_handlers = all_handlers;
    }

    public IProcessOneWebRequest get_the_handler_for(IProvideDetailsAboutTheRequest request)
    {
        foreach (var processOneWebRequest in all_handlers)
        {
            if (processOneWebRequest.can_handle(request))
                return processOneWebRequest;
        }
        return null;
        
    }
  }
}