namespace Engine;

public interface IMatcher<T>
{

    public bool matchea(T value, T value2);
    public bool PuedeSalir(Ficha<T> ficha);
    public List<Movimiento<T>> SacarJugadas(Tablero<T> tablero, List<Mano<T>> manos, int i)
    {
        List<Movimiento<T>> jugadas = new List<Movimiento<T>>();

        foreach (Tablero<T> t in tablero)
        {
            if (t.Hoja.Jugabilidad)
            {
                foreach (var ficha in manos[i].Contenido)
                {
                    if (t.Hoja.Turno is -1)
                    {
                        if (PuedeSalir(ficha))
                        {
                            jugadas.Add(new Movimiento<T>(ficha.Cara2, ficha, t.Hoja, false));
                            jugadas.Add(new Movimiento<T>(ficha.Cara1, ficha, t.Hoja, false));
                        }
                        continue;
                    }


                    if (matchea(ficha.Cara1, t.Hoja.Entrada))
                    {
                        jugadas.Add(new Movimiento<T>(ficha.Cara2, ficha, t.Hoja, false));
                    }
                    if (matchea(ficha.Cara2, t.Hoja.Entrada))
                    {
                        jugadas.Add(new Movimiento<T>(ficha.Cara1, ficha, t.Hoja, false));
                    }

                }
            }
        }

        if (jugadas.Count == 0) jugadas.Add(new Movimiento<T>(default!, default!, default!, true));

        return jugadas;
    }
    public void Jugabilidad(Tablero<T> nodo, Tablero<T> tablero, int letoca, int players);
    public void Jugabilidad(Tablero<T> tablero, int i);
}
public class MatcherClasico : IMatcher<int>
{
    public void Jugabilidad(Tablero<int> nodo, Tablero<int> tablero, int letoca, int players)
    {
        nodo.Hoja.Jugabilidad = false;
    }

    public void Jugabilidad(Tablero<int> tablero, int i)
    {

    }

    public bool matchea(int value, int value2)
    {
        if (value == value2) return true;
        return false;
    }
    public bool PuedeSalir(Ficha<int> ficha)
    {
        return true;

    }


}
public class MatcherDistancia2 : IMatcher<int>
{
    public void Jugabilidad(Tablero<int> nodo, Tablero<int> tablero, int letoca, int players)
    {
        nodo.Hoja.Jugabilidad = false;
    }

    public void Jugabilidad(Tablero<int> tablero, int i)
    {

    }

    public bool matchea(int value, int value2)
    {

        if (Math.Abs(value - value2) == 2) return true;
        return false;
    }
    public bool PuedeSalir(Ficha<int> ficha)
    {
        return true;
    }


}
public class MatcherLongana : IMatcher<int>
{
    public void Jugabilidad(Tablero<int> nodo, Tablero<int> tablero, int letoca, int players)
    {
        nodo.Hoja.Jugabilidad = false;
        if (nodo.Hoja.Turno == -1)
        {
            for (int i = 0; i < players - 2; i++)
            {
                tablero.Ramas.Add(new Tablero<int>(tablero.Ramas[0].Hoja.Entrada, tablero.Ramas[0].Hoja.Turno,
                tablero.Ramas[0].Hoja.Ficha, tablero.Ramas[0].Hoja.Player));
            }
            foreach (Tablero<int> rama in tablero.Ramas) rama.Hoja.Jugabilidad = false;
        }
        else
        {
            if (nodo.Ramas.Count is 0) return;
            foreach (Tablero<int> rama in tablero.Ramas[letoca])

                if (rama.Ramas.Count == 0) rama.Hoja.Jugabilidad = false;


        }
    }

    public void Jugabilidad(Tablero<int> tablero, int letoca)
    {
        if (tablero.Hoja.Jugabilidad is true) return;
        foreach (Tablero<int> nodo in tablero.Ramas[letoca])
        {
            if (nodo.Ramas.Count is 0) nodo.Hoja.Jugabilidad = true;
        }
    }

    public bool matchea(int value, int value2)
    {
        if (value == value2) return true;
        return false;
    }
    public bool PuedeSalir(Ficha<int> ficha)
    {
        if (ficha.Cara1 == ficha.Cara2) return true;
        return false;

    }
}
