namespace Class.Check;





public class ModuleNameMap : Map
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