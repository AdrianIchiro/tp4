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

public class DoorMachine
{
    private DoorState currentState;

    public DoorMachine()
    {
        currentState = new LockedState(this);
    }

    public void Open()
    {
        currentState.Open();
    }

    public void Close()
    {
        currentState.Close();
    }

    public void DisplayState()
    {
        currentState.DisplayState();
    }

    public void SetState(DoorState state)
    {
        currentState = state;
    }
}


public interface DoorState
{
    void Open();
    void Close();
    void DisplayState();
}

public class LockedState : DoorState
{
    private DoorMachine doorMachine;

    public LockedState(DoorMachine doorMachine)
    {
        this.doorMachine = doorMachine;
    }

    public void Open()
    {
        Console.WriteLine("Pintu terkunci");
    }

    public void Close()
    {
        Console.WriteLine("Mengunci pintu...");
        doorMachine.SetState(new LockedState(doorMachine));
    }

    public void DisplayState()
    {
        Console.WriteLine("State pintu: Terkunci");
    }
}

public class UnlockedState : DoorState
{
    private DoorMachine doorMachine;

    public UnlockedState(DoorMachine doorMachine)
    {
        this.doorMachine = doorMachine;
    }

    public void Open()
    {
        Console.WriteLine("Membuka pintu...");
        doorMachine.SetState(new UnlockedState(doorMachine));
    }

    public void Close()
    {
        Console.WriteLine("Pintu tidak terkunci");
    }

    public void DisplayState()
    {
        Console.WriteLine("State pintu: Terbuka");
    }
}




class Program
{
    static void Main(string[] args)
    {
        KodePos kodePos = new KodePos();


        Console.WriteLine(kodePos.getKodePos(Kelurahan.Batununggal));
        Console.WriteLine(kodePos.getKodePos(Kelurahan.Kujangsari));

        DoorMachine doorMachine = new DoorMachine();

        doorMachine.DisplayState(); 

        doorMachine.Open(); 
        doorMachine.Close();
        doorMachine.DisplayState();

        doorMachine.Open();
        doorMachine.SetState(new UnlockedState(doorMachine));
        doorMachine.DisplayState();

        doorMachine.Close();
        doorMachine.SetState(new LockedState(doorMachine));
        doorMachine.DisplayState();

    }
}