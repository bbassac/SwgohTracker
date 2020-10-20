using System;
using System.Collections.Generic;
using System.Text;

namespace Ipd.Services
{
    public class AuthProvider
    {
        private static AuthProvider instance = null;
        private AuthResponse auth = null;

        private AuthProvider()
        {
            auth = ExecutionThrottle.ThrottleSync<Task<AuthResponse>>(2000, (Func<Task<AuthResponse>>)(() => this.PlayerRankService.Login())).Result;
        }

        public AuthResponse GetAuthentication()
        {
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
