using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Interface.Service
{
    public interface IAppAutoNumberLastService
    {
        string GenerateAutoNumber(string srAutoNumber);
    }
}
