namespace Class.Check;




public class ModuleIntentCompare : Compare
{
    private ModuleNameCompare NameCompare { get; set; }



    public override bool Init()
    {
        base.Init();



        this.NameCompare = new ModuleNameCompare();


        this.NameCompare.Init();



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






        ModuleName leftName;


        leftName = leftModuleIntent.Name;




        ModuleName rightName;


        rightName = rightModuleIntent.Name;







        int u;


        u = this.NameCompare.Execute(leftName, rightName);




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