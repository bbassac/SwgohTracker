using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ipd.Core.Models;
using Ipd.Core.Utils;

namespace Ipd.Services
{
    public class AuthProvider
    {
        private static AuthProvider instance = null;
        private AuthResponse auth = null;

        private AuthProvider()
        {
          
        }

        public AuthResponse GetAuthentication()
        {
            if (auth == null)
            {
                auth = ExecutionThrottle.ThrottleSync<Task<AuthResponse>>(2000, (Func<Task<AuthResponse>>)(() => this.PlayerRankService.Login())).Result;
            }
            return auth;
        }

        public static AuthProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuthProvider();
                }
                return instance;
            }
        }
    }
}
