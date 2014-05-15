namespace app.web.core
{
  public interface IProcessOneWebRequest
  {
    void process(IProvideDetailsAboutTheRequest request);
    bool can_handle(IProvideDetailsAboutTheRequest request);
  }
}