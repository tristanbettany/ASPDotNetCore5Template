namespace ApplicationLayer.Helpers
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            if (str == null || str.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
