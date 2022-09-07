namespace Engine;


public interface IGenerador<T>{
    public List<Ficha<T>> Generamazo(T value);
}
public class Generadorclasico:IGenerador<int>
{
    

    public List<Ficha<int>> Generamazo(int value)
    {
        List<Ficha<int>> list = new List<Ficha<int>>();
        
        for(int i = 0; i<value+1;i++){
            for(int j = i; j<value+1;j++){
                list.Add(new Ficha<int>(i,j, i+j));
            }
        }
        return list;
    }

    
}
public class GeneradorPares : IGenerador<int>
{
    public List<Ficha<int>> Generamazo(int value)
    {
        List<Ficha<int>> list = new List<Ficha<int>>();
        for(int i = 0; i<value+1;i++){
            for(int j = i; j<value+1;j++){
                if((i+j)%2!=0)continue;
                list.Add(new Ficha<int>(i,j, i+j));
            }
        }
        return list;
    }
}
public class GeneradorPrimos : IGenerador<int>
{
    public List<Ficha<int>> Generamazo(int value)
    {
        List<Ficha<int>> list = new List<Ficha<int>>();
        for(int i = 0; i<value+1;i++){
            if(!EsPrimo(i))continue;
            for(int j = i; j<value+1;j++){
                if(!EsPrimo(j))continue;
                list.Add(new Ficha<int>(i,j, i+j));
            }
        }
        return list;
    }
    private bool EsPrimo(int value){
        double aux = Math.Sqrt(value);
        for(int i = ((int)aux); i>1;i--){
            if(value%i==0)return false;
        }
        return true;
    }
}
