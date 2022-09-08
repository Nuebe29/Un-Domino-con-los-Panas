namespace Engine;

public class Movimiento<T>
{
    public Movimiento(T value,Ficha<T> a, Nodo<T> b, bool esPase, T cola)
    {
        Ficha = a;
        Nodo  = b;
        EsPase = esPase;
        Entrada = value;
        Cola = cola;
    }
    
    public bool EsPase { get; }
    public Ficha<T> Ficha { get; }
    public Nodo<T> Nodo { get; }
    public T Entrada{get;}

    public T Cola{get;}
    
}