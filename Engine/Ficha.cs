namespace Engine;

public class Ficha<T>
{
    public T Cara1 { get; }
    public T Cara2 { get; }
    public int Peso { get; }
    public Ficha(T a, T b, int peso)
    {
        Cara1 = a;
        Cara2 = b;
        Peso = peso;
    }

    public override string ToString()
    {
        return $"[{Cara1},{Cara2}]";
    }
}

