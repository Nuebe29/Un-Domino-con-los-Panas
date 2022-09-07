namespace Engine;

public class Movimiento<T>
{
    public Movimiento(T value,Ficha<T> a, Nodo<T> b, bool esPase)
    {
        Ficha = a;
        Nodo  = b;
        EsPase = esPase;
        Entrada = value;
    }
    
    public bool EsPase { get; }
    public Ficha<T> Ficha { get; }
    public Nodo<T> Nodo { get; }
    public T Entrada{get;}
    
}