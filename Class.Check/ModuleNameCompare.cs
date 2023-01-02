namespace Class.Check;




public class ModuleNameCompare : Compare
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




        ModuleName leftName;



        leftName = (ModuleName)left;




        ModuleName rightName;



        rightName = (ModuleName)right;




        int u;

        u = leftName.Value.CompareTo(rightName.Value);


        return u;
    }
}