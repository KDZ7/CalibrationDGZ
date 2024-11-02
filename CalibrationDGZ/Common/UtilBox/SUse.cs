using System.Text.RegularExpressions;

namespace modus.Common.UtilBox
{
    public static class SUse
    {
        public static bool MatchUInt8(string? @in)
        {
            if (string.IsNullOrEmpty(@in))
                return true;
            var regex = new Regex(@"^(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])$");
            return regex.IsMatch(@in);
        }
        public static bool MatchUInt16(string? @in)
        {
            if (string.IsNullOrEmpty(@in))
                return true;
            var regex = new Regex(@"^(6553[0-5]|655[0-2][0-9]|65[0-4][0-9]{2}|6[0-4][0-9]{3}|[1-5][0-9]{0,4}|[1-9][0-9]{0,3}|0)$");
            return regex.IsMatch(@in);
        }
        public static bool MatchUInt(string? @in)
        {
            if (string.IsNullOrEmpty(@in))
                return true;
            var regex = new Regex(@"^\d+$");
            return regex.IsMatch(@in);
        }
    }
}

