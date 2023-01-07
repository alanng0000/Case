namespace Class.Check;




public class ClassMap : Map
{
    public override bool Init()
    {
        ClassNameCompare compare;


        compare = new ClassNameCompare();


        compare.Init();




        this.Compare = compare;




        base.Init();
        



        return true;
    }
}