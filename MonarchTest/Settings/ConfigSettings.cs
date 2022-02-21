using System;
using System.Collections.Generic;
using System.Text;


namespace MonarchTest.Settings
{
    public class ConfigSettings
    {
        public String Env { get; set; }
        public String MktgUrl { get; set; }
        public String BaseUrl { get; set; }
        public String PrereqPersonalUrl { get; set; }
        public String PrereqBusinessUrl { get; set; }
        public String validEmail { get; set; }
        public String validPwd { get; set; }
        public String invalidEmail { get; set; }
        public String wrongPwd { get; set; }
        public String wrongEmail { get; set; }
        public String validUsername { get; set; }
        public String forgotPwdEmail { get; set; }
        public String forgotPwdInvalidCode { get; set; }
        public String forgotPwdValidPwd1 { get; set; }
        public String forgotPwdValidPwd2 { get; set; }

    }
}
