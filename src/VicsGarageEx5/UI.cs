namespace VicsGarageEx5
{
    abstract public class UI
    {
        abstract public void Output(string message);
        abstract public string Input();
        abstract public int InputInt();
        abstract public double InputDouble();
        abstract public bool InputYN();
    }
}