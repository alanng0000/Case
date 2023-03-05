namespace Case.Infra;



public class Keytoken : Object
{
    public static Keytoken Instance { get; } = CreateGlobal();




    private static Keytoken CreateGlobal()
    {
        Keytoken global;


        global = new Keytoken();



        global.Init();



        return global;
    }



    public string Case { get; private set; }
    public string This { get; private set; }
    public string Base { get; private set; }
    public string Newa { get; private set; }
    public string Glob { get; private set; }
    public string Cast { get; private set; }
    public string Null { get; private set; }
    public string True { get; private set; }
    public string Fase { get; private set; }
    public string Retu { get; private set; }
    public string Mifa { get; private set; }
    public string Lope { get; private set; }
    public string Publi { get; private set; }
    public string Prope { get; private set; }
    public string Paren { get; private set; }
    public string Priva { get; private set; }


    public List All { get; protected set; }


    public List Access { get; protected set; }


    public override bool Init()
    {
        base.Init();


        this.Case = "case";
        this.This = "this";
        this.Base = "base";
        this.Newa = "newa";
        this.Glob = "glob";
        this.Cast = "cast";
        this.Null = "null";
        this.True = "true";
        this.Fase = "fase";
        this.Retu = "retu";
        this.Mifa = "mifa";
        this.Lope = "lope";
        this.Publi = "publi";
        this.Prope = "prope";
        this.Paren = "paren";
        this.Priva = "priva";


        this.All = new List();
        this.All.Init();
        this.All.Add(this.Case);
        this.All.Add(this.This);
        this.All.Add(this.Base);
        this.All.Add(this.Newa);
        this.All.Add(this.Glob);
        this.All.Add(this.Cast);
        this.All.Add(this.Null);
        this.All.Add(this.True);
        this.All.Add(this.Fase);
        this.All.Add(this.Retu);
        this.All.Add(this.Mifa);
        this.All.Add(this.Lope);
        this.All.Add(this.Publi);
        this.All.Add(this.Prope);
        this.All.Add(this.Paren);
        this.All.Add(this.Priva);


        this.Access = new List();
        this.Access.Init();
        this.Access.Add(this.Publi);
        this.Access.Add(this.Prope);
        this.Access.Add(this.Paren);
        this.Access.Add(this.Priva);


        return true;
    }
}