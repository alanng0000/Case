namespace Class.Infra;




public class ClassIndexCompare : Compare
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




        ClassIndex leftIndex;



        leftIndex = (ClassIndex)left;





        ClassIndex rightIndex;



        rightIndex = (ClassIndex)right;




        int u;


        u = leftIndex.Value.CompareTo(rightIndex.Value);



        return u;
    }
}