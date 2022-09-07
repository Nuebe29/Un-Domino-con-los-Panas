namespace Engine;
public interface ITurner<T>{
    public int Turno(Tablero<T> tablero, int turno, int players);
}
public class TurnerClasico : ITurner<int>
{
    public int Turno(Tablero<int> tablero, int turno, int players)
    {
        return turno%(players);
    }
}
public class TurnerRandom : ITurner<int>
{
    public int Turno(Tablero<int> tablero, int turno, int players)
    {
     Random r = new Random();
    return r.Next(players);
    }
}

public class TurnerContrario : ITurner<int>
{
    public int Turno(Tablero<int> tablero, int turno, int players)
    {
        return (turno+players-1)%players;
    }
}
