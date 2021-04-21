using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsHunter.Business.Interfaces
{
    public interface IAuthenticationBusiness
    {
        void SaveSecrets(string url, string key);

        void LoadSecrets();
    }
}
