namespace Shared
{
    public interface IPuzzleInput<T>
    {
        T ParseFromText(string textInput);
    }
}