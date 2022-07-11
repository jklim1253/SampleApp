using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.ViewModels
{
  public class TestData
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public override bool Equals(object? obj)
    {
      return Id == (obj as TestData)?.Id;
    }

    public override int GetHashCode()
    {
      return Id;
    }
  }

  public class SettingViewModel : ViewModelBase
  {
    private TestData selected;

    public TestData Selected
    {
      get => selected;
      set => SetProperty(ref selected, value);
    }

    private IList<TestData> depot;

    public IList<TestData> Depot
    {
      get => depot;
      set => SetProperty(ref depot, value);
    }
    
    public IRelayCommand ClickCommand { get; set; }
    public IRelayCommand Click2Command { get; set; }

    public SettingViewModel()
    {
      Title = "ViewModel-Setting";

      Depot = new List<TestData>()
      {
        new TestData(){ Id = 1, Name = "hello" },
        new TestData(){ Id = 2, Name = "world" },
        new TestData(){ Id = 3, Name = "jklim" },
      };

      ClickCommand = new RelayCommand(OnClick);
      Click2Command = new RelayCommand(OnClick2);
    }

    private void OnClick()
    {
      Selected = Depot[2];
    }
    private void OnClick2()
    {
      Selected = new TestData() { Id = 1, Name = "hello" };
      //var temp = Selected;
      //Selected = Depot.FirstOrDefault(e => e.Id == Selected.Id);
    }
  }
}
