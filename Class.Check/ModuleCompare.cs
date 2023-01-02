namespace Class.Check;




public class ModuleCompare : Compare
{
    private StringCompare StringCompare { get; set; }




    public override bool Init()
    {
        this.StringCompare = new StringCompare();


        this.StringCompare.Init();




        base.Init();



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




        Module leftModule;



        leftModule = (Module)left;




        Module rightModule;



        rightModule = (Module)right;





        string leftName;


        leftName = leftModule.Name.Value;




        string rightName;


        rightName = rightModule.Name.Value;





        int u;

        u = this.StringCompare.Execute(leftName, rightName);


        if (!(u == 0))
        {
            return u;
        }
        






        ulong leftVer;


        leftVer = leftModule.Ver.Value;




        ulong rightVer;


        rightVer = rightModule.Ver.Value;





        u = leftVer.CompareTo(rightVer);



        return u;
    }
}