using System.Text;

void printAnalysis(int length, int addedItems){
    bloomFilter trial = new bloomFilter(length);
    Random random = new Random();
    char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
    for (int i = 0; i < addedItems; i++){
        StringBuilder sb = new StringBuilder();
        int keyLength = random.Next(2, 10);
        for (int j = 0; j < keyLength; j++){
            sb.Append(chars[random.Next(chars.Length)]);
        }
        string key = sb.ToString();
        //Console.WriteLine(key);
        trial.Add(key);
    }
    Console.WriteLine($"Array Length: {length}   Items Added: {addedItems}   Possible False Positives: {trial.PossibleFalsePositives}");
}

printAnalysis(5, 3);
printAnalysis(5, 5);
printAnalysis(5, 10);
printAnalysis(5, 15);
printAnalysis(5, 20);

printAnalysis(20, 10);
printAnalysis(20, 20);
printAnalysis(20, 50);
printAnalysis(20, 100);
printAnalysis(20, 250);

printAnalysis(50, 10);
printAnalysis(50, 50);
printAnalysis(50, 100);
printAnalysis(50, 150);
printAnalysis(50, 200);