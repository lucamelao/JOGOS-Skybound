public abstract class SingletonBase<T> 
    where T : SingletonBase<T>, new()
{
  private void Singleton() { }
  protected static T _instance;
  public static T GetInstance()
  {
    if (_instance == null)
    {
      _instance = new T();
      _instance.Init();
    }
    return _instance;
  }

  protected virtual void Init() {
    // Override this method to custom initialize your singleton
    return;
  }

  public void Destroy()
  {
    _instance = null;
  }

}