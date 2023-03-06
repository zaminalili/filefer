namespace filefer.Service.AutoKey
{
    public class AutoKey: IAutoKey
	{
        Random random = new Random();

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string newString = "";

        public string CreateKey(int charLength, int intLength)
        {  

            for (int i = 0; i < charLength; i++)
                newString += chars[random.Next(0, chars.Length)];

            return newString + Convert.ToString(random.Next(Convert.ToInt32(Math.Pow(10, intLength - 1)), Convert.ToInt32(Math.Pow(10, intLength))));
        }

        public string CreateKey(int charLength)
        {


            for (int i = 0; i < charLength; i++)
                newString += chars[random.Next(0, chars.Length)];

            return newString;
        }
    }
}
