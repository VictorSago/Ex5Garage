namespace VicsGarageEx5
{
    abstract public class UI : IUI
    {
        abstract public void Output(string message);
        abstract public string GetString();
        abstract public int GetInt();
        abstract public int GetValidatedInt(int min, int max);
        abstract public double GetDouble();
        abstract public bool GetYN();

    }
}