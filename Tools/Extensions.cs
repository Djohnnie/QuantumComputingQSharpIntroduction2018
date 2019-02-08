namespace Tools
{
    public static class Extensions
    {
        public static string ToQubitNotation(this bool bit)
        {
            return $"|{(bit ? "1" : "0")}>";
        }

        public static string ToQubitNotation(this (bool, bool) bits)
        {
            return $"|{(bits.Item1 ? "1" : "0")}{(bits.Item2 ? "1" : "0")}>";
        }

        public static string ToQubitNotation(this (bool, bool, bool) bits)
        {
            return $"|{(bits.Item1 ? "1" : "0")}{(bits.Item2 ? "1" : "0")}{(bits.Item3 ? "1s" : "0")}>";
        }
    }
}