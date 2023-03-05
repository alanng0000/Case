namespace Case.Check;




public class ClassCompare : Compare
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




        Class leftClass;



        leftClass = (Class)left;




        Class rightClass;



        rightClass = (Class)right;




        return leftClass.Id.CompareTo(rightClass.Id);
    }
}