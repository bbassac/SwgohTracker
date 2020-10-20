using System;
using System.Collections.Generic;
using System.Text;

namespace Ipd.Services
{
    public class AuthProvider
    {
        private static AuthProvider instance = null;

        private AuthProvider()
        {

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
