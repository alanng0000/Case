namespace Class;




public class Compile : Object
{
    public Class Class { get; set; }
        
        


    public Result Result { get; set; }




    public SourceArray Source { get; set; }




    public TokenCompile Token { get; set; }




    public NodeCompile Node { get; set; }




    public CheckCompile Check { get; set; }




    public ModuleCompile Module { get; set; }





    public override bool Init()
    {
        base.Init();





        this.Token = this.CreateToken();







        this.Node = this.CreateNode();







        this.Check = this.CreateCheck();







        this.Module = this.CreateModule();





        return true;
    }




    protected virtual TokenCompile CreateToken()
    {
        TokenCompile compile;




        compile = new TokenCompile();




        compile.Init();





        TokenCompile ret;


        ret = compile;



        return ret;
    }





    protected virtual NodeCompile CreateNode()
    {
        NodeCompile compile;




        compile = new NodeCompile();




        compile.Init();





        NodeCompile ret;


        ret = compile;



        return ret;
    }





    protected virtual CheckCompile CreateCheck()
    {
        CheckCompile compile;




        compile = new CheckCompile();




        compile.Init();





        CheckCompile ret;


        ret = compile;



        return ret;
    }





    protected virtual ModuleCompile CreateModule()
    {
        ModuleCompile compile;




        compile = new ModuleCompile();




        compile.Init();





        ModuleCompile ret;


        ret = compile;



        return ret;
    }






    public bool Execute()
    {
        this.Result = new Result();


        this.Result.Init();
        



        this.Source = this.Class.Source;




        TaskKind kind;


        kind = this.Class.Task.Kind;



        TaskKindList kinds;
            

        kinds = this.Class.TaskKindList;

        


        if (kind == kinds.Module |
            kind == kinds.Check |
            kind == kinds.Node |
            kind == kinds.Token
        )
        {
            this.ExecuteToken();
        }




        if (kind == kinds.Module |
            kind == kinds.Check |
            kind == kinds.Node
        )
        {
            this.ExecuteNode();
        }

        


        if (kind == kinds.Module |
            kind == kinds.Check
        )
        {
            this.ExecuteCheck();
        }




        if (kind == kinds.Module)
        {
            this.ExecuteModule();
        }



        return true;
    }




    public bool ExecuteToken()
    {
        this.Token.SourceList = this.Source;

        

        this.Token.Execute();



        this.Result.Token = this.Token.Result;



        return true;
    }




    public bool ExecuteNode()
    {
        this.Node.SourceList = this.Source;



        this.Node.TaskNode = this.Class.Task.Node;



        this.Node.TokenResult = this.Result.Token;



        this.Node.Execute();



        this.Result.Node = this.Node.Result;



        return true;
    }




    public bool ExecuteCheck()
    {
        this.Check.SourceList = this.Source;




        this.Check.Port = this.Class.Port;




        this.Check.NodeResult = this.Result.Node;
        



        if (this.Class.SystemResult != null)
        {
            this.Check.SystemModules = this.Class.SystemResult.Check.Refer.Module;
        }
        


        this.Check.Execute();



        this.Result.Check = this.Check.Result;



        return true;
    }





    public bool ExecuteModule()
    {
        this.Module.Sources = this.Source;




        this.Module.Port = this.Class.Port;




        this.Module.NodeResult = this.Result.Node;




        this.Module.CheckResult = this.Result.Check;




        this.Module.Execute();




        this.Result.Module = this.Module.Result;




        return true;
    }
}