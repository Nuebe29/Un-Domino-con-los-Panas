namespace Engine;

public delegate int Estrategia<T>(Tablero<T> estado, List<Movimiento<T>> posiblesjugadas, Mano<T> hand);
public static class Estrategias<T>
{
    public static int Estrategiarandom(Tablero<T> estado, List<Movimiento<T>> posiblesjugadas, Mano<T> hand)
    {
        Random r = new Random();
        return r.Next(posiblesjugadas.Count);
    }
    public static int Botagordas(Tablero<T> estado, List<Movimiento<T>> posiblesjugadas, Mano<T> hand)
    {

        int devolver = 0;
        int peso = 0;
        for (int i = 0; i < posiblesjugadas.Count; i++)
        {
            if (posiblesjugadas[i].EsPase) continue;
            if (posiblesjugadas[i].Ficha.Peso > peso) { devolver = i; peso = posiblesjugadas[i].Ficha.Peso; }
        }
        return devolver;
    }
    public static int NoPasarse(Tablero<T> estado, List<Movimiento<T>> posiblesjugadas, Mano<T> hand)
    {
        if(posiblesjugadas[0].EsPase)return 0;
        Dictionary<T, int> data = new();
        foreach (var ficha in hand.Contenido)
        {
            if (!data.ContainsKey(ficha.Cara1)) data.Add(ficha.Cara1, 1);
            else data[ficha.Cara1]++;
            if (!data.ContainsKey(ficha.Cara2)) data.Add(ficha.Cara2, 1);
            else data[ficha.Cara2]++;
        }
        var newMoves = posiblesjugadas.OrderByDescending(move => Math.Min(data[move.Ficha.Cara1!], data[move.Ficha.Cara2!]));
        for(int i=0;i < posiblesjugadas.Count;i++){
            if (posiblesjugadas[i] == newMoves.ElementAt(0))return i;
        }
        return 0;
    }

}