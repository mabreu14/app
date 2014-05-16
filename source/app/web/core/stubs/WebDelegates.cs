using System;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
  public class WebDelegates
  {
    public static readonly ICreateARequestFromAspNetRequests create_request = x => new FakeRequest();

    public static ICreateAHandlerForAnUncofiguredRequest create_missing_handler = delegate
    {
      throw new NotImplementedException("There is no command for this request");
    };

    class FakeRequest : IProvideDetailsAboutTheRequest
    {
      public InputModel map<InputModel>()
      {
        return Activator.CreateInstance<InputModel>();
      }
    }
  }
}