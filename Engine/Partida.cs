namespace Engine;

public class Partida<T>
{
    public Tablero<T> Tablero { get; set;}
    public List<Player<T>> Players { get; set; }
    private Referee<T> Referee { get; set;}
    public List<Mano<T>> Manos{get; set;}

    public Partida()
    {
        Tablero = new Tablero<T>();
        Manos = new List<Mano<T>>();
        Players = new List<Player<T>>();
    }
    
    public void Run() => Referee.Run();
    
    public bool Run(int a)=> Referee.Run(a);
    
    public void RecibeParametros(IEndcondition<T> endcondition, IWincondition<T> wincondition, IMatcher<T> matcher, Dealer<T> dealer,
     IGenerador<T> generador, List<Player<T>> players, T n, ITurner<T> turner, int cantidad){
        Players = players;
        Tablero = new Tablero<T>();
        Tablero.Hoja.Salida = true;
        Referee = new Referee<T>(endcondition, wincondition, matcher, dealer, generador, players, n, Tablero, turner, cantidad);
        Manos = Referee.Manos;
    }
}