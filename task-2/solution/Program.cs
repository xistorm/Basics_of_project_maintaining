using UserContext;

namespace Solution;

public class Program {
    public static void Main(string[] args) {
        Context context = new ();
        context.Run();
    }
}