using System;

public enum Kelurahan
{
    Batununggal,
    Kujangsari,
    Mengger,
    Wates,
    Cijaura,
    Jatisari,
    Margasari,
    Sekejati,
    Kebonwaru,
    Maleer,
    Samoja
}
public class KodePos
{


    public string getKodePos(Kelurahan kelurahan)
    {
        string[] kodePos = {"40266", "40287", "40267", "40256", "40287",
        "40286", "40286", "40286", "40272", "40274",
        "40273"
 };
        {
            int index = (int)kelurahan;
            return kodePos[index];
        }
    }
}



class Program
{
    static void Main(string[] args)
    {
        KodePos kodePos = new KodePos();


        Console.WriteLine(kodePos.getKodePos(Kelurahan.Batununggal));
        Console.WriteLine(kodePos.getKodePos(Kelurahan.Kujangsari));
    }
}