namespace VicsGarageEx5
{
    public interface IUI
    {
        void Output(string message);
        string GetString();
        int GetInt();
        int GetValidatedInt(int min, int max);
        double GetDouble();
        bool GetYN();
    }
}