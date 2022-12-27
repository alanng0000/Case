namespace Class.Check;



public class AccessList : Object
{
    public static AccessList This { get; } = CreateGlobal();




    private static AccessList CreateGlobal()
    {
        AccessList global;


        global = new AccessList();



        global.Init();



        return global;
    }







    public override bool Init()
    {
        base.Init();




        this.Public = this.CreateAccess();



        this.Local = this.CreateAccess();



        this.Derive = this.CreateAccess();



        this.Private = this.CreateAccess();




        return true;
    }





    private ulong NewId { get; set; }





    private Access CreateAccess()
    {
        Access o;



        o = new Access();



        o.Init();



        o.Id = this.NewId;





        this.NewId = this.NewId + 1;




        Access ret;

        ret = o;

        return ret;
    }





    public Access Public { get; private set; }



    public Access Local { get; private set; }



    public Access Derive { get; private set; }



    public Access Private { get; private set; }
}