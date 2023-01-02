namespace Class.Check;






public class ModuleDataMap : Map
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