using System.Collections.Generic;

namespace AseanPhonebook
{
    public static class CountryRegistry
    {
        public static readonly List<Country> Countries = new List<Country>
        {
            new Country("Philippines", 63),
            new Country("Thailand", 66),
            new Country("Singapore", 65),
            new Country("Indonesia", 62),
            new Country("Malaysia", 60)
        };

        public static bool IsValidCode(int code)
        {
            return FindByCode(code) != null;
        }

        public static Country FindByCode(int code)
        {
            foreach (Country c in Countries)
            {
                if (c.Code == code) return c;
            }
            return null;
        }
    }
}