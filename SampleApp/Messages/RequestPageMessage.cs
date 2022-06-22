using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Messages
{
  public class RequestPageMessage : ValueChangedMessage<string>
  {
    public RequestPageMessage(string value) : base(value)
    {
    }
  }
}
