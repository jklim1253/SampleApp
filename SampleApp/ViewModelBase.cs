using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace SampleApp
{
  public abstract class ViewModelBase : ObservableObject
  {
    private string title = "noname";

    public string Title
    {
      get => title;
      set => SetProperty(ref title, value);
    }
  }
}