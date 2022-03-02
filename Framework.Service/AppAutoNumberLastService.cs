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
    public class AppAutoNumberLastService:IAppAutoNumberLastService
    {
        private readonly IAppAutoNumberLastRepository _appAutoNumberLastRepository;
        private readonly IAppAutoNumberRepository _appAutoNumberRepository;

        public AppAutoNumberLastService()
        {
            _appAutoNumberLastRepository = ObjRepositoryExtension.CreateInstanceAppAutoNumberLastRepository();
            _appAutoNumberRepository = ObjRepositoryExtension.CreateInstanceAppAutoNumberRepository();
        }
        public string GenerateAutoNumber(string srAutoNumber)
        {
            string applicantId = null;

            var appAutoNumber = _appAutoNumberRepository.GetAppAutoNumberById(srAutoNumber);

            if (appAutoNumber != null)
            {
                var appAutoNumberLast = _appAutoNumberLastRepository.GetAppAutoLastNumberById(appAutoNumber);

                if (appAutoNumberLast == null)
                {
                    int LastNumber = 1;
                    var primKey = appAutoNumber.Prefik + appAutoNumber.SeparatorAfterPrefik;

                    primKey = primKey
                            + DateTime.Now.Year + appAutoNumber.SeparatorAfterYear;

                    primKey = primKey + LastNumber.ToString().PadLeft(appAutoNumber.NumberLength ?? 0, '0');

                    applicantId = primKey;
                    //insert
                    AppAutoNumberLast objLastNumber = new AppAutoNumberLast();
                    objLastNumber.SRAutoNumber = appAutoNumber.SRAutoNumber;
                    objLastNumber.EffectiveDate = appAutoNumber.EffectiveDate;
                    objLastNumber.YearNo = DateTime.Now.Year;
                    objLastNumber.LastNumber = 1;
                    objLastNumber.LastCompleteNumber = primKey;
                    objLastNumber.LastUpdateDateTime = DateTime.Now;
                    objLastNumber.LastUpdateByUserId = "wenty";
                    _appAutoNumberLastRepository.Insert(objLastNumber);
                }
                else
                {
                    int LastNumber = (appAutoNumberLast.LastNumber ?? 0) + 1;
                    var primKey = appAutoNumber.Prefik + appAutoNumber.SeparatorAfterPrefik;

                    primKey = primKey
                            + DateTime.Now.Year + appAutoNumber.SeparatorAfterYear;

                    primKey = primKey + LastNumber.ToString().PadLeft(appAutoNumber.NumberLength ?? 0, '0');

                    applicantId = primKey;

                    //update
                    appAutoNumberLast.LastNumber = LastNumber;
                    appAutoNumberLast.LastCompleteNumber = primKey;
                    _appAutoNumberLastRepository.Update(appAutoNumberLast);
                }
            }
            return applicantId;
        }
    }
}
