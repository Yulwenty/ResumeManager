using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Interface.Service
{
    public interface IAppAutoNumberService
    {
        AppAutoNumber GetAppAutoNumberById(string srAutoNumber);
    
    }
}
