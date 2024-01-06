

namespace PostgresConnectAxum
{
    
    class GlobalVariables
    {

        private static string uniStr = "root";

        public static string uStr
        {
            get { return uniStr; }
            set { uniStr = value; }
        }

        private static string pniStr = "axum";

        public static string pStr
        {
            get { return pniStr; }
            set { pniStr = value; }
        }

        private static string ipStr = "";

        public static string ipAddressStr
        {
            get { return ipStr; }
            set { ipStr = value; }
        }

        private static bool validLogin = false;

        public static bool isValid
        {
            get { return validLogin; }
            set { validLogin = value; }
        }

    }
}
