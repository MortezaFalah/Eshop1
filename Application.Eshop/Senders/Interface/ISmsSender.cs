using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Senders.Interface
{
    public interface ISmsSender
    {
      Task<string> SendSmsAsync(string mobile, string message, bool isFlash=true);
    }
}
