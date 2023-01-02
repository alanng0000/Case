namespace Class.Check;




public class ModuleIntentCompare : Compare
{
    public override bool Init()
    {
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





        ulong leftName;


        leftName = leftModuleIntent.Name.Value;




        ulong rightName;


        rightName = rightModuleIntent.Name.Value;





        int u;

        u = leftName.CompareTo(rightName);


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