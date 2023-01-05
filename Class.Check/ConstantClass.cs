namespace Class.Check;





public class ConstantClass : Object
{
    public Class Bool { get; private set; }




    public Class Int { get; private set; }




    public Class String { get; private set; }






    public override bool Init()
    {
        base.Init();

        


        this.Bool = this.CreateClass("Bool");




        this.Int = this.CreateClass("Int");




        this.String = this.CreateClass("String");




        return true;
    }






    private Class CreateClass(string name)
    {
        ClassName h;

        h = new ClassName();

        h.Init();

        h.Value = name;




        Class c;


        c = new Class();


        c.Init();


        c.Name = h;





        Class ret;


        ret = c;



        return ret;
    }
}