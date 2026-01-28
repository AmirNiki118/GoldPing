using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldAlert.Application.Contracts.Services
{
    public interface ISmsService
    {
        Task SendAsync(string mobile, string message);
    }
}
