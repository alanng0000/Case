namespace Class.Check;





public class ModuleStringMap : Map
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