using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ipd.Core.Models;
using Ipd.Core.Services;
using Ipd.Core.Utils;

namespace Ipd.Services
{
    public class AuthProvider
    {
        private static AuthProvider _instance = null;
        private AuthResponse auth = null;

        private AuthProvider()
        {
          
        }

        public AuthResponse GetAuthentication(PlayerRankService service)
        {
            if (auth == null)
            {
                auth = ExecutionThrottle.ThrottleSync<Task<AuthResponse>>(2000, (Func<Task<AuthResponse>>)(service.Login)).Result;
            }
            return auth;
        }

        public static AuthProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AuthProvider();
                }
                return _instance;
            }
        }
    }
}
