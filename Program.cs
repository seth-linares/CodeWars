namespace Code_Problems {
    using System.Text.RegularExpressions;
    public class Program {
        public static void Main(string[] args) {
            string bub = "";

            for(int i = 1; i <= 53; i++) {
                bub += i.ToString();
            }
            Console.WriteLine($"length of string: {bub.Length}");
            Console.WriteLine($"index of last digit: {bub.Length - 1}");
            Console.WriteLine($"string: {bub}");
        }

         
    }
}

