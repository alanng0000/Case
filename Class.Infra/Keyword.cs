namespace Class.Infra;



public class Keyword : Object
{
    public static Keyword Instance { get; } = CreateGlobal();




    private static Keyword CreateGlobal()
    {
        Keyword global;


        global = new Keyword();



        global.Init();



        return global;
    }



    public string Class { get; private set; }
    public string Get { get; private set; }
    public string Set { get; private set; }
    public string This { get; private set; }
    public string Base { get; private set; }
    public string New { get; private set; }
    public string Global { get; private set; }
    public string Cast { get; private set; }
    public string Null { get; private set; }
    public string True { get; private set; }
    public string False { get; private set; }
    public string Return { get; private set; }
    public string If { get; private set; }
    public string While { get; private set; }
    public string Public { get; private set; }
    public string Proper { get; private set; }
    public string Parent { get; private set; }
    public string Private { get; private set; }


    public List All { get; protected set; }


    public List Access { get; protected set; }


    public override bool Init()
    {
        base.Init();


        this.Class = "class";
        this.Get = "get";
        this.Set = "set";
        this.This = "this";
        this.Base = "base";
        this.New = "new";
        this.Global = "global";
        this.Cast = "cast";
        this.Null = "null";
        this.True = "true";
        this.False = "false";
        this.Return = "return";
        this.If = "if";
        this.While = "while";
        this.Public = "public";
        this.Proper = "proper";
        this.Parent = "parent";
        this.Private = "private";


        this.All = new List();
        this.All.Init();
        this.All.Add(this.Class);
        this.All.Add(this.Get);
        this.All.Add(this.Set);
        this.All.Add(this.This);
        this.All.Add(this.Base);
        this.All.Add(this.New);
        this.All.Add(this.Global);
        this.All.Add(this.Cast);
        this.All.Add(this.Null);
        this.All.Add(this.True);
        this.All.Add(this.False);
        this.All.Add(this.Return);
        this.All.Add(this.If);
        this.All.Add(this.While);
        this.All.Add(this.Public);
        this.All.Add(this.Proper);
        this.All.Add(this.Parent);
        this.All.Add(this.Private);


        this.Access = new List();
        this.Access.Init();
        this.Access.Add(this.Public);
        this.Access.Add(this.Proper);
        this.Access.Add(this.Parent);
        this.Access.Add(this.Private);


        return true;
    }
}