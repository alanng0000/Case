namespace Case.Check;



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




        this.Array = new Array();


        this.Array.Count = 4;


        this.Array.Init();





        this.Public = this.AddAccess();



        this.Proper = this.AddAccess();



        this.Parent = this.AddAccess();



        this.Privat = this.AddAccess();




        return true;
    }





    public Access Get(int index)
    {
        return (Access)this.Array.Get(index);
    }
    




    private Array Array { get; set; }




    private int Index { get; set; }





    private Access AddAccess()
    {
        Access o;



        o = new Access();



        o.Init();



        o.Index = this.Index;





        this.Index = this.Index + 1;




        Access ret;

        ret = o;

        return ret;
    }





    public Access Public { get; private set; }



    public Access Proper { get; private set; }



    public Access Parent { get; private set; }



    public Access Privat { get; private set; }
}