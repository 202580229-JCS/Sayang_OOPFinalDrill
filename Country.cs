namespace AseanPhonebook
{
 
    public class Country
    {
        public string Name { get; }
        public int Code { get; }

        public Country(string name, int code)
        {
            Name = name;
            Code = code;
        }
    }
}