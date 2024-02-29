public interface IPartialSet {
   void Add(string key);
   bool Contains(string key);
}

public class bloomFilter : IPartialSet{
    private bool[] check1;
    private bool[] check2;
    private bool[] check3;
    public int PossibleFalsePositives;

    public bloomFilter(int arrayLength = 10){
        check1 = new bool[arrayLength];
        check2 = new bool[arrayLength];
        check3 = new bool[arrayLength];
        PossibleFalsePositives = 0;
    }

    public int Hash1(string key){

        int size = key.Length;
        char first = key[0];
        char second = key[1];

        int firstAscii = Convert.ToInt32(first);
        int secondAscii = Convert.ToInt32(second);

        return (11 * firstAscii + secondAscii) % size;
    }
   public int Hash2(string key){

        int size = key.Length;
        char first = key[0];
        char last = key[size - 1];
        
        int firstAscii = Convert.ToInt32(first);
        int lastAscii = Convert.ToInt32(last);

        return (7 * firstAscii + 5 * lastAscii) % size;
    }
    public int Hash3(string key){
        
        int size = key.Length;
        char first = key[0];
        char second = key[1];
        char last = key[size - 1];
        
        int firstAscii = Convert.ToInt32(first);
        int secondAscii = Convert.ToInt32(second);
        int lastAscii = Convert.ToInt32(last);

        return (firstAscii * secondAscii * lastAscii) % size;
    }
    
    
    public void Add(string key){
        if (check1[Hash1(key)] && check2[Hash2(key)] && check3[Hash3(key)]) PossibleFalsePositives ++;
        check1[Hash1(key)] = true;
        check2[Hash2(key)] = true;
        check3[Hash3(key)] = true;
    }
    public bool Contains(string key){
        if (check1[Hash1(key)] && check2[Hash2(key)] && check3[Hash3(key)]) return true;
        else return false;
    }
}
