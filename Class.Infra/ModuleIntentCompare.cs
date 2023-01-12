namespace Class.Infra;




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




        ModuleIntent leftIntent;



        leftIntent = (ModuleIntent)left;





        ModuleIntent rightIntent;



        rightIntent = (ModuleIntent)right;




        int u;


        u = leftIntent.Value.CompareTo(rightIntent.Value);



        return u;
    }
}