namespace Engine;


public class Dealer<T>
{
    public List<Mano<T>> Reparte(List<Ficha<T>> mazo, int jugadores, int cant)
    {
        Random r = new Random();
        List<Mano<T>> list = new List<Mano<T>>();
        for(int i = 0; i< jugadores;i++){
            list.Add(new Mano<T>());
        }
        for(int i = 0; i< jugadores;i++){
            for(int j = 0;j<cant;j++){
                int aux = r.Next(mazo.Count);
                list[i].Add(mazo[aux]);
                mazo.Remove(mazo[aux]);
            }
        }
        return list;
    }
    
}
