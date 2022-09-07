namespace Engine;


public class Player<T>
{   
    private Estrategia<T> estrategia;
    public string name{get;}
    public Player(Estrategia<T> a, string name){
        this.estrategia = a;
        this.name=name;
    }
    public int Juega(Tablero<T> tablero, List<Movimiento<T>> posiblesjugadas, Mano<T> hand)
    {
        return estrategia(tablero, posiblesjugadas, hand);
    }
}

