using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Messages
{
  public class NavigateMessage : ValueChangedMessage<string>
  {
    public NavigateMessage(string value) : base(value)
    {
    }
  }
}
