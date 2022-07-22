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

namespace SampleApp.Controls
{
  /// <summary>
  /// Interaction logic for SampleBox.xaml
  /// </summary>
  public partial class SampleBox : UserControl
  {
    public SampleBox()
    {
      InitializeComponent();
    }

    //public SampleBoxInfo Info { get; set; }



    public int Id
    {
      get { return (int)GetValue(IdProperty); }
      set { SetValue(IdProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Info.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IdProperty =
        DependencyProperty.Register("Id", typeof(int), typeof(SampleBox), new PropertyMetadata(0));



    public string URL
    {
      get { return (string)GetValue(URLProperty); }
      set { SetValue(URLProperty, value); }
    }

    // Using a DependencyProperty as the backing store for URL.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty URLProperty =
        DependencyProperty.Register("URL", typeof(string), typeof(SampleBox), new PropertyMetadata(string.Empty));


  }
}
