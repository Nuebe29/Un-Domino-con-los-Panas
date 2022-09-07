using System.Collections;

namespace Engine;

public class Mano<T>
{
    public Mano()
    {
        Contenido = new List<Ficha<T>>();
    }
    public List<Ficha<T>> Contenido { get; }

    public int Peso
    {
        get
        {
            int peso = 0;

            foreach (var ficha in Contenido)
            {
                peso += ficha.Peso;
            }

            return peso;
        }
    }

    public void Add(Ficha<T> ficha)
    {
        Contenido.Add(ficha);
    }

    public void Remove(Ficha<T> ficha)
    {
        Contenido.Remove(ficha);
    }

    public Mano<T> Clone()
    {
        var newMano = new Mano<T>();
        foreach (var item in Contenido)
        {
            newMano.Add(item);
        }

        return newMano;
    }
}