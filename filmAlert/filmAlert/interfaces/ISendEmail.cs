using filmAlert.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmAlert.interfaces
{
    public interface ISendEmail
    {
        public Task<bool> send(List<show> showList);
    }
}
