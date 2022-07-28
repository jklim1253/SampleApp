using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SampleApp.ViewModels
{
  public class ArchitectureViewModel : ViewModelBase
  {
    private readonly ILogger<ArchitectureViewModel> logger;

    private double posX = 0.0;

    public double PosX
    {
      get => posX;
      set => SetProperty(ref posX, value);
    }

    private double posY = 0.0;

    public double PosY
    {
      get => posY;
      set => SetProperty(ref posY, value);
    }


    public IRelayCommand<object> CaptureCommand { get; }
    public IRelayCommand<object> ReleaseCommand { get; }
    public IRelayCommand<object> MoveCommand { get; }

    public ArchitectureViewModel(ILogger<ArchitectureViewModel> logger)
    {
      this.logger = logger;

      CaptureCommand = new RelayCommand<object>(OnCapture);
      ReleaseCommand = new RelayCommand<object>(OnRelease);
      MoveCommand = new RelayCommand<object>(OnMove);
    }

    private Point ptMouse = new Point(0, 0);
    private Vector posCurrent = new Vector(0, 0);

    private void OnCapture(object? obj)
    {
      var target = obj as Rectangle;
      if (target == null) return;

      if (target.CaptureMouse())
      {
        ptMouse = Mouse.GetPosition(null);
        logger.LogInformation("captured.");
      }
    }
    private void OnRelease(object? obj)
    {
      var target = obj as Rectangle;
      if (target == null) return;

      if (target.IsMouseCaptured)
      {
        target.ReleaseMouseCapture();
        logger.LogInformation("released.");
      }
    }
    private void OnMove(object? obj)
    {
      var target = obj as Rectangle;
      if (target == null) return;

      if (target.IsMouseCaptured)
      {
        Point ptCurrent = Mouse.GetPosition(null);

        Vector diff = ptCurrent - ptMouse;

        posCurrent += diff;

        // origin is center of view.
        //target.RenderTransform = new TranslateTransform(posCurrent.X, posCurrent.Y);

        PosX = (posCurrent.X < 0)? 0 : posCurrent.X;
        PosY = (posCurrent.Y < 0)? 0 : posCurrent.Y;

        ptMouse = ptCurrent;
      }
    }
  }
}
