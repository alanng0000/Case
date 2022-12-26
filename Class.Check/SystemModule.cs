namespace Class.Check;





public class SystemModule : Object
{
    public Module Module { get; set; }




    public Class Bool { get; private set; }




    public Class Int { get; private set; }




    public Class String { get; private set; }






    public override bool Init()
    {
        base.Init();

        


        this.Bool = this.NewClass("Bool");




        this.Int = this.NewClass("Int");




        this.String = this.NewClass("String");




        return true;
    }






    private Class NewClass(string name)
    {
        Class c;


        c = new Class();


        c.Init();


        c.Name = name;





        Class ret;


        ret = c;



        return ret;
    }
}