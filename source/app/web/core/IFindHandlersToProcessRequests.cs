namespace app.web.core
{
  public interface IFindHandlersToProcessRequests
  {
    IProcessOneWebRequest get_the_handler_for(IProvideDetailsAboutTheRequest request);
  }
}