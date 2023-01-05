namespace Class;






public class ModuleDataMap : Map
{
    public override bool Init()
    {
        ModuleReferCompare compare;


        compare = new ModuleReferCompare();


        compare.Init();



        this.Compare = compare;

        



        base.Init();



        

        return true;
    }
}