namespace filefer.Service.AutoKey
{
	public interface IAutoKey
	{
        string CreateKey(int charLength, int intLength);
        string CreateKey(int charLength);

    }
}
