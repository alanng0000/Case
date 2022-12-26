namespace Class;




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







    public TaskKind Module { get; private set; }



    public TaskKind Check { get; private set; }



    public TaskKind Node { get; private set; }



    public TaskKind Token { get; private set; }






    public override bool Init()
    {
        base.Init();



        this.Module = this.CreateTaskKind();



        this.Check = this.CreateTaskKind();



        this.Node = this.CreateTaskKind();



        this.Token = this.CreateTaskKind();





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