using FrameworkCore.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkCore.Model;
using Framework.Repository;

namespace Framework.Service
{
    public class MenuListService : IMenuListService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<Menu_List> getMenus()
        {
            return unitOfWork.MenuListRepository.Get();
           
           
        }
    }
}
