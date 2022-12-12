namespace Class.Check;




public class ClassCompare : Compare
{
    public override int Execute(object left, object right)
    {
        if (left == null)
        {
            return 0;
        }



        if (right == null)
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