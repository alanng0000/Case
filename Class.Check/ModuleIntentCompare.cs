namespace Class.Check;




public class ModuleIntentCompare : Compare
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




        ModuleIntent leftModuleIntent;



        leftModuleIntent = (ModuleIntent)left;




        ModuleIntent rightModuleIntent;



        rightModuleIntent = (ModuleIntent)right;





        string leftName;


        leftName = leftModuleIntent.Name.Value;




        string rightName;


        rightName = rightModuleIntent.Name.Value;





        int u;

        u = this.StringCompare.Execute(leftName, rightName);


        if (!(u == 0))
        {
            return u;
        }
        






        ulong leftVer;


        leftVer = leftModuleIntent.Ver.Value;




        ulong rightVer;


        rightVer = rightModuleIntent.Ver.Value;





        u = leftVer.CompareTo(rightVer);



        return u;
    }
}