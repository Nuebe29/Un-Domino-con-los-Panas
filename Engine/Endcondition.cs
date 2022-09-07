namespace Engine;

public interface IEndcondition<T>
{
    public bool Condicion(List<Mano<T>> list, int pases, Tablero<T> tablero);
}
public class EndconditionClasico : IEndcondition<int>
{


    public bool Condicion(List<Mano<int>> list, int pases, Tablero<int> tablero)
    {
        if (pases == list.Count*1000) return true;
        foreach (var mano in list)
        {
            if (mano.Contenido.Count == 0) return true;
        }
        return false;
    }
}
public class EndconditionPorPuntos50 : IEndcondition<int>
{
    private int Tope = 50;
    private bool Salida;

    public EndconditionPorPuntos50()
    {
    }

    public EndconditionPorPuntos50(int tope)
    {
        Tope = tope;
    }


    public bool Condicion(List<Mano<int>> list, int pases, Tablero<int> tablero)
    {
        if (pases == list.Count*1000) return true;
        int aux = 0;
        foreach (Tablero<int> nodo in tablero.Where(x => x.Hoja.Turno is not -1))
        {
            if (nodo.Hoja.Salida && Salida) continue;
            else Salida = true;
            aux += nodo.Hoja.Ficha.Peso;
            if (aux >= Tope) return true;
        }
        return false;
    }
}
public class EndconditionPorPases3 : IEndcondition<int>
{
    private int Tope;

    public EndconditionPorPases3()
    {
        Tope = 3;
    }

    public EndconditionPorPases3(int tope)
    {
        Tope = tope;
    }

    public bool Condicion(List<Mano<int>> list, int pases, Tablero<int> tablero)
    {
        if (pases == list.Count*1000) return true;
        
        int aux = 0; int turnos = 0;

        foreach (Tablero<int> nodo in tablero.Where(x => x.Hoja.Turno is not -1))
        {
            aux++;
            if (nodo.Hoja.Turno > turnos) turnos = nodo.Hoja.Turno;
        }
        if (turnos - aux - 1 >= Tope) return true;


        return false;
    }
}
