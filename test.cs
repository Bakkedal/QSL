public class test_complex
{

public static void Main(){
var a = new complex(1,2);
var b = new complex(2,3);
var c = a+b;
if(c == new complex(3,5)) c.Print("test complex addition passed");
else c.Print("test complex addition failed");
}

}
