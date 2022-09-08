namespace Engine;
public interface ITurner<T>
{
    public IEnumerable<int> Turno(int players);
}
public class TurnerClasico : ITurner<int>
{
    public IEnumerable<int> Turno(int players)
    {
        int count = 0;
        while (true)
        {
            if (count == players) count = 0;
            yield return count;
            count++;
        }
    }
}
public class TurnerRandom : ITurner<int>
{
    public IEnumerable<int> Turno(int players)
    {
        Random r = new Random();
        while (true) yield return r.Next(players);
    }
}

public class TurnerContrario : ITurner<int>
{
    public IEnumerable<int> Turno(int players)
        => new TurnerClasico().Turno(players).Select(x => players - x - 1);
}
