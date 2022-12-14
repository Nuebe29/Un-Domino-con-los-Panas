using System.Collections;

namespace Engine;
public class Nodo<T>
{
    public Nodo()
    {
        Turno = -1;
        Jugabilidad = true;
    }

    public Nodo(T entrada, int turno, Ficha<T> ficha, int player,T cola)
    {
        Entrada = entrada;
        Turno = turno;
        Jugabilidad = true;
        Ficha = ficha;
        Player = player;
        Cola = cola;
    }

    public Nodo<T> Clone() => new Nodo<T>(Entrada!, Turno, Ficha!, Player, Cola);
    
    public T? Entrada { get; }
    public int Turno { get; }
    public bool Jugabilidad { get; set; }
    public bool Salida{get;set;}
    public Ficha<T>? Ficha;
    public int Player;

    public T Cola;

    
}
public class Tablero<T> : IEnumerable<Tablero<T>>
{
    public Tablero(T entrada, int turno, Ficha<T> ficha, int player,T cola)
    {
        Hoja = new Nodo<T>(entrada,turno,ficha, player, cola);
        Ramas = new List<Tablero<T>>();
    }

    public Tablero()
    {
        Ramas = new List<Tablero<T>>();
        Hoja = new Nodo<T>();
    }

    private Tablero(Nodo<T> hoja)
    {
        Ramas = new List<Tablero<T>>();
        Hoja = hoja.Clone();
    }
    

    public  Nodo<T> Hoja { get; }
    public List<Tablero<T>> Ramas { get; }

    public IEnumerator<Tablero<T>> GetEnumerator()
    {
        yield return this;

        foreach (var hijo in Ramas)
        {
            foreach (Tablero<T> item in hijo)
            {
                yield return item;
            }
        }
    }
    
    public IEnumerable<Tablero<T>> Pintar(Tablero<T> tablero) {
        List<Tablero<T>> list = new List<Tablero<T>>();
        var root = tablero;
        var actual = tablero;
        list.Add(tablero);
        while (actual.Ramas.Count is not 0) {
            actual = actual.Ramas.ElementAt(0);
            list.Add(actual);
        }
        list.Reverse();
        foreach (var item in list) yield return item;
        if (root.Ramas.Count is not 0) 
        {
            if (root.Ramas[0].Ramas.Count is 2)
            {
                actual = root.Ramas[0].Ramas.ElementAt(1);
                yield return actual; 
            }
        }
        
        while (actual.Ramas.Count is not 0) {
            actual = actual.Ramas.ElementAt(0);
            yield return actual;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Tablero<T> Clone()
    {
        var newTablero = new Tablero<T>(Hoja);
        foreach (var item in Ramas)
            newTablero.Ramas.Add(item.Clone());

        return newTablero;
    }
}

