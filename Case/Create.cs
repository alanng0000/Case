namespace Case;




public class Create : Object
{
    public Case Class { get; set; }




    public Result Result { get; set; }




    public SourceArray Source { get; set; }




    private TokeCreate Toke { get; set; }




    private NodeCreate Node { get; set; }




    private CheckCreate Check { get; set; }




    private ModeCreate Mode { get; set; }







    public override bool Init()
    {
        base.Init();







        this.Toke = this.CreateToke();







        this.Node = this.CreateNode();







        this.Check = this.CreateCheck();







        this.Mode = this.CreateMode();





        return true;
    }




    protected virtual TokeCreate CreateToke()
    {
        TokeCreate create;




        create = new TokeCreate();




        create.Init();





        TokeCreate ret;


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





    protected virtual ModeCreate CreateMode()
    {
        ModeCreate create;




        create = new ModeCreate();




        create.Init();





        ModeCreate ret;


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
        
        


        if (kind == kindList.Mode |
            kind == kindList.Check |
            kind == kindList.Node |
            kind == kindList.Toke
        )
        {
            this.ExecuteToke();
        }




        if (kind == kindList.Mode |
            kind == kindList.Check |
            kind == kindList.Node
        )
        {
            this.ExecuteNode();
        }

        


        if (kind == kindList.Mode |
            kind == kindList.Check
        )
        {
            this.ExecuteCheck();
        }




        if (kind == kindList.Mode)
        {
            this.ExecuteModule();
        }



        return true;
    }




    public bool ExecuteToke()
    {
        this.Toke.SourceList = this.Source;

        

        this.Toke.Execute();



        this.Result.Toke = this.Toke.Result;



        return true;
    }




    public bool ExecuteNode()
    {
        this.Node.SourceList = this.Source;



        this.Node.TaskNode = this.Class.Node;



        this.Node.TokenResult = this.Result.Toke;



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
        this.Mode.NodeResult = this.Result.Node;




        this.Mode.CheckResult = this.Result.Check;




        this.Mode.Execute();




        this.Result.Mode = this.Mode.Result;




        return true;
    }
}