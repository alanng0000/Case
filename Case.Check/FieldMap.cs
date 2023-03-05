namespace Case.Check;




public class FieldMap : Map
{
    public override bool Init()
    {
        StringCompare compare;


        compare = new StringCompare();


        compare.Init();




        this.Compare = compare;




        base.Init();
        



        return true;
    }
}