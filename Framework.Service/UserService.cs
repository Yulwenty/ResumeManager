using Framework.Repository;
using FrameworkCore.Interface.Service;
using FrameworkCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service
{
    public class UserService:IUserService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //nanti harus pindahkan ke helper, jadi static
        public  string GetMD5(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(password);
            byte[] targetData = md5.ComputeHash(fromData);

            StringBuilder encryptedString= new StringBuilder();

            for(int i=0; i< targetData.Length; i++)
            {
                encryptedString.Append(targetData[i].ToString("x2"));
            }

            return encryptedString.ToString();
        }

        public User TryLogin(User user)
        {
            var password = GetMD5(user.Password);
       
            var data = unitOfWork.UserRepository.Get(x => x.UserName == user.UserName && x.Password == password , null, "", false).FirstOrDefault();
            if(data != null)
            {
                return data;
            }
            return null;

        }
    }
}
