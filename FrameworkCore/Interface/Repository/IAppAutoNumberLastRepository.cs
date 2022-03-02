using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Interface.Repository
{
    public interface IAppAutoNumberLastRepository
    {
        AppAutoNumberLast GetAppAutoLastNumberById(AppAutoNumber appAutoNumber);

        void Insert(AppAutoNumberLast app);

        void Update(AppAutoNumberLast app);
    }
}
