namespace Engine;


public class Referee<T>{
    private IEndcondition<T> Endcondition;
    private IGenerador<T> Generador;
    private Dealer<T> Dealer;
    public List<Mano<T>> Manos { get; }
    private IMatcher<T> Matcher { get; }
    public Tablero<T> Tablero {get; }
    public List<Player<T>> Players { get; }
    private IWincondition<T> Wincondition;
    public int Pases { get; set; }
    private int Turno = -1;
    public readonly IEnumerator<int> turnEnumerator;

    public Referee(IEndcondition<T> endcondition, IWincondition<T> wincondition, IMatcher<T> matcher,Dealer<T> dealer,
     IGenerador<T> generador,List<Player<T>> players, T n,Tablero<T> tablero, ITurner<T> turner, int cantidad)
    {
        Endcondition = endcondition;
        Dealer = dealer;
        Wincondition = wincondition;
        Generador  = generador;
        Matcher = matcher;
        Players = players;
        Manos = Dealer.Reparte(Generador.Generamazo(n), players.Count,cantidad  );
        Tablero = tablero;
        Pases = 0;
        turnEnumerator = turner.Turno(players.Count).GetEnumerator();
        turnEnumerator.MoveNext();
    }

    public void Run()
    {

        while (!Endcondition.Condicion(Manos,Pases,Tablero))
        {
            Turno++;
            Matcher.Jugabilidad(Tablero, turnEnumerator.Current);
            var PosiblesJugadas = Matcher.SacarJugadas(Tablero, Manos, turnEnumerator.Current);
            var j = Players[turnEnumerator.Current].Juega(Tablero, PosiblesJugadas.ToList(), Manos[turnEnumerator.Current].Clone());
            EfectuarJugada(PosiblesJugadas[j], Tablero, Manos, Turno);
            turnEnumerator.MoveNext();            
        }
        Wincondition.Ordena(Manos, Players, Tablero);
    }
    public void EfectuarJugada(Movimiento<T> jugada, Tablero<T> tablero, List<Mano<T>> manos, int turno)
    {
        if (!jugada.EsPase)
        {
            Pases = 0;
            manos[turnEnumerator.Current].Remove(jugada.Ficha);
            foreach (Tablero<T> t in tablero)
            {
                if (t.Hoja == jugada.Nodo)
                {
                    if (jugada.Nodo.Salida)
                    {
                        t.Ramas.Add(new Tablero<T>(jugada.Ficha.Cara1,0,jugada.Ficha,turnEnumerator.Current, jugada.Ficha.Cara2));
                        t.Ramas[0].Hoja.Jugabilidad=false;
                        t.Ramas[0].Ramas.Add(new Tablero<T>(jugada.Ficha.Cara2,-2,jugada.Ficha,turnEnumerator.Current,jugada.Ficha.Cara1));
                        t.Ramas[0].Ramas.Add(new Tablero<T>(jugada.Ficha.Cara1, -2,jugada.Ficha,turnEnumerator.Current,jugada.Ficha.Cara2));
                    }
                    else t.Ramas.Add(new Tablero<T>(jugada.Entrada, turno   ,jugada.Ficha,turnEnumerator.Current, jugada.Cola));          
                    Matcher.Jugabilidad(t,tablero,turnEnumerator.Current, Players.Count);

                }
            }

        }

        else Pases++;
    }
    public bool RunTurn(){
        if(!Endcondition.Condicion(Manos,Pases,Tablero)){
            Turno++;
            turnEnumerator.MoveNext();            
            Matcher.Jugabilidad(Tablero,turnEnumerator.Current);
            var PosiblesJugadas = Matcher.SacarJugadas(Tablero, Manos, turnEnumerator.Current);
            var j = Players[turnEnumerator.Current].Juega(Tablero, PosiblesJugadas, Manos[turnEnumerator.Current]);
            EfectuarJugada(PosiblesJugadas[j], Tablero, Manos, Turno);
            
            return false;
        }
        
        Wincondition.Ordena(Manos, Players, Tablero);
        return true;
    }
    

    
}
