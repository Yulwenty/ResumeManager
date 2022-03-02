using Framework.Repository;
using FrameworkCore.Interface.Repository;
using FrameworkCore.Interface.Service;
using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service
{
    public class AppAutoNumberService: IAppAutoNumberService
    {
        private readonly IAppAutoNumberRepository _appAutoNumberRepository;
        private readonly IAppAutoNumberLastRepository _appAutoNumberLastRepository;

        public AppAutoNumberService()
        {
            _appAutoNumberRepository = ObjRepositoryExtension.CreateInstanceAppAutoNumberRepository();
            _appAutoNumberLastRepository = ObjRepositoryExtension.CreateInstanceAppAutoNumberLastRepository();
        }
        public AppAutoNumber GetAppAutoNumberById(string srAutoNumber)
        {
            return _appAutoNumberRepository.GetAppAutoNumberById(srAutoNumber);
        }

       
    }
}
