namespace Engine;

public interface IWincondition<T>
{

    public void Ordena(List<Mano<T>> manos, List<Player<T>> players, Tablero<T> tablero)
    {
        List<Player<T>> copy = new List<Player<T>>();
        List<Mano<T>> clon = new List<Mano<T>>();

        foreach (var player in players)
        {
            copy.Add(player);
        }
        foreach(var mano in manos){
            clon.Add(mano.Clone());
        }
        
        int a = manos.Count;
        for (int i = 0; i < a; i++)
        {
            var aux = DecidirGanador(clon, tablero);
            players[i] = copy[aux];
            clon.Remove(clon[aux]);
            copy.Remove(copy[aux]);
        }
    }
    public int DecidirGanador(List<Mano<T>> list, Tablero<T> tablero);

}
public class GanadorCálsico : IWincondition<int>
{
    public int DecidirGanador(List<Mano<int>> list, Tablero<int> tablero)
    {
        int ganador = 0;
        int min = int.MaxValue;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Contenido.Count == 0) return i;
            if (list[i].Peso < min)
            {
                ganador = i;
                min = list[i].Peso;
            }


        }
        return ganador;
    }


}
public class GanadorPorFichas : IWincondition<int>
{
    public int DecidirGanador(List<Mano<int>> list, Tablero<int> tablero)
    {
        int aux = int.MaxValue;
        int devolver = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Contenido.Count < aux) { aux = list[i].Contenido.Count(); devolver = i; }
        }
        return devolver;
    }
}
public class GanadorPorPases : IWincondition<int>
{
    public int DecidirGanador(List<Mano<int>> list, Tablero<int> tablero)
    {
        int devolver = 0;
        int count = int.MinValue;
        for (int i = 0; i < list.Count; i++)
        {
            int aux = 0;
            foreach (Tablero<int> nodo in tablero.Where(x=>x.Hoja.Turno is not -1))
            {
                if (nodo.Hoja.Player==i) aux++;
            }
            if(aux>count){
                count = aux;
                devolver = i;
            }
        }
        return devolver;
    }
}
