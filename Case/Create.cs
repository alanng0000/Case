namespace Case;




public class Create : Object
{
    public Case Class { get; set; }




    public Result Result { get; set; }




    public SourceArray Source { get; set; }




    private TokenCreate Token { get; set; }




    private NodeCreate Node { get; set; }




    private CheckCreate Check { get; set; }




    private ModuleCreate Module { get; set; }







    public override bool Init()
    {
        base.Init();







        this.Token = this.CreateToken();







        this.Node = this.CreateNode();







        this.Check = this.CreateCheck();







        this.Module = this.CreateModule();





        return true;
    }




    protected virtual TokenCreate CreateToken()
    {
        TokenCreate create;




        create = new TokenCreate();




        create.Init();





        TokenCreate ret;


        ret = create;



        return ret;
    }





    protected virtual NodeCreate CreateNode()
    {
        NodeCreate create;




        create = new NodeCreate();




        create.Init();





        NodeCreate ret;


        ret = create;



        return ret;
    }





    protected virtual CheckCreate CreateCheck()
    {
        CheckCreate create;




        create = new CheckCreate();




        create.Init();





        CheckCreate ret;


        ret = create;



        return ret;
    }





    protected virtual ModuleCreate CreateModule()
    {
        ModuleCreate create;




        create = new ModuleCreate();




        create.Init();





        ModuleCreate ret;


        ret = create;



        return ret;
    }






    public bool Execute()
    {
        this.Result = new Result();


        this.Result.Init();
        



        this.Source = this.Class.Source;




        TaskKind kind;


        kind = this.Class.Task.Kind;



        TaskKindList kindList;
            

        kindList = TaskKindList.This;
        
        


        if (kind == kindList.Module |
            kind == kindList.Check |
            kind == kindList.Node |
            kind == kindList.Token
        )
        {
            this.ExecuteToken();
        }




        if (kind == kindList.Module |
            kind == kindList.Check |
            kind == kindList.Node
        )
        {
            this.ExecuteNode();
        }

        


        if (kind == kindList.Module |
            kind == kindList.Check
        )
        {
            this.ExecuteCheck();
        }




        if (kind == kindList.Module)
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



        this.Node.TaskNode = this.Class.Node;



        this.Node.TokenResult = this.Result.Token;



        this.Node.Execute();



        this.Result.Node = this.Node.Result;



        return true;
    }




    public bool ExecuteCheck()
    {
        this.Check.SourceList = this.Source;




        this.Check.NodeResult = this.Result.Node;
        

        
        this.Check.PortRefer = this.Class.Refer;




        this.Check.Execute();



        this.Result.Check = this.Check.Result;



        return true;
    }





    public bool ExecuteModule()
    {
        this.Module.NodeResult = this.Result.Node;




        this.Module.CheckResult = this.Result.Check;




        this.Module.Execute();




        this.Result.Module = this.Module.Result;




        return true;
    }
}