namespace Case;




public class TaskKindList : Object
{
    public static TaskKindList This { get; } = CreateGlobal();




    private static TaskKindList CreateGlobal()
    {
        TaskKindList global;


        global = new TaskKindList();



        global.Init();



        return global;
    }







    public TaskKind Mode { get; private set; }



    public TaskKind Check { get; private set; }



    public TaskKind Node { get; private set; }



    public TaskKind Toke { get; private set; }



    public TaskKind Port { get; private set; }






    public override bool Init()
    {
        base.Init();



        this.Mode = this.CreateTaskKind();



        this.Check = this.CreateTaskKind();



        this.Node = this.CreateTaskKind();



        this.Toke = this.CreateTaskKind();



        this.Port = this.CreateTaskKind();





        return true;
    }





    private TaskKind CreateTaskKind()
    {
        TaskKind t;


        t = new TaskKind();


        t.Init();




        TaskKind ret;


        ret = t;


        return ret;
    }
}