namespace Class.Check;




public class ModuleMap : Map
{
    public override bool Init()
    {
        ModuleIntentCompare compare;


        compare = new ModuleIntentCompare();


        compare.Init();




        this.Compare = compare;




        base.Init();
        



        return true;
    }
}