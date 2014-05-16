namespace app.web.core
{
  public interface IProcessOneWebRequest : ISupportAUserFeature
  {
    bool can_handle(IProvideDetailsAboutTheRequest request);
  }
}