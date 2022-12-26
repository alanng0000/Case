namespace Class.Infra;



public class Delimiter : Object
{
    public static Delimiter This { get; } = CreateGlobal();




    private static Delimiter CreateGlobal()
    {
        Delimiter global;


        global = new Delimiter();



        global.Init();



        return global;
    }



    public string StopSign { get; private set; }
    public string PauseSign { get; private set; }
    public string BaseSign { get; private set; }
    public string StateSign { get; private set; }
    public string EqualSign { get; private set; }
    public string AddSign { get; private set; }
    public string SubSign { get; private set; }
    public string MulSign { get; private set; }
    public string DivSign { get; private set; }
    public string AndSign { get; private set; }
    public string OrnSign { get; private set; }
    public string NotSign { get; private set; }
    public string JoinSign { get; private set; }
    public string LeftBracket { get; private set; }
    public string RightBracket { get; private set; }
    public string LeftBrace { get; private set; }
    public string RightBrace { get; private set; }
    public string LessSign { get; private set; }


    public List All { get; private set; }


    public override bool Init()
    {
        base.Init();


        this.StopSign = ".";
        this.PauseSign = ",";
        this.BaseSign = ":";
        this.StateSign = ";";
        this.EqualSign = "=";
        this.AddSign = "+";
        this.SubSign = "-";
        this.MulSign = "*";
        this.DivSign = "/";
        this.AndSign = "&";
        this.OrnSign = "|";
        this.NotSign = "!";
        this.JoinSign = "~";
        this.LeftBracket = "(";
        this.RightBracket = ")";
        this.LeftBrace = "{";
        this.RightBrace = "}";
        this.LessSign = "<";


        this.All = new List();
        this.All.Init();
        this.All.Add(this.StopSign);
        this.All.Add(this.PauseSign);
        this.All.Add(this.BaseSign);
        this.All.Add(this.StateSign);
        this.All.Add(this.EqualSign);
        this.All.Add(this.AddSign);
        this.All.Add(this.SubSign);
        this.All.Add(this.MulSign);
        this.All.Add(this.DivSign);
        this.All.Add(this.AndSign);
        this.All.Add(this.OrnSign);
        this.All.Add(this.NotSign);
        this.All.Add(this.JoinSign);
        this.All.Add(this.LeftBracket);
        this.All.Add(this.RightBracket);
        this.All.Add(this.LeftBrace);
        this.All.Add(this.RightBrace);
        this.All.Add(this.LessSign);


        return true;
    }
}