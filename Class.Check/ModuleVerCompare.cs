namespace Class.Check;




public class ModuleVerCompare : Compare
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




        ModuleVer leftVer;



        leftVer = (ModuleVer)left;





        ModuleVer rightVer;



        rightVer = (ModuleVer)right;




        int u;


        u = leftVer.Value.CompareTo(rightVer.Value);



        return u;
    }
}