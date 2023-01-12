namespace Class.Infra;




public class ModuleNameCompare : Compare
{
    private StringCompare StringCompare { get; set; }



    public override bool Init()
    {
        base.Init();



        this.StringCompare = new StringCompare();


        this.StringCompare.Init();



        return true;
    }

    



    public override int Execute(object left, object right)
    {
        if (this.Null(left))
        {
            return 0;
        }



        if (this.Null(right))
        {
            return 0;
        }




        ModuleName leftName;



        leftName = (ModuleName)left;




        ModuleName rightName;



        rightName = (ModuleName)right;




        int u;


        u = this.StringCompare.Execute(leftName.Value, rightName.Value);


        return u;
    }
}