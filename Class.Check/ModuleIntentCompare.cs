namespace Class.Check;




public class ModuleIntentCompare : Compare
{
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




        int u;


        u = leftModuleIntent.Value.CompareTo(rightModuleIntent.Value);



        return u;
    }
}