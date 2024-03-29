﻿using Microsoft.Toolkit.Mvvm.DependencyInjection;
using SampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleApp.Views
{
  /// <summary>
  /// Interaction logic for ViewView.xaml
  /// </summary>
  public partial class ViewView : Page
  {
    public ViewView()
    {
      InitializeComponent();
      this.DataContext = Ioc.Default.GetRequiredService<ViewViewModel>();
    }
  }
}
