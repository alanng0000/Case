namespace Class;






public class ModuleDataMap : Map
{
    public override bool Init()
    {
        CheckModuleReferCompare compare;


        compare = new CheckModuleReferCompare();


        compare.Init();



        this.Compare = compare;

        



        base.Init();



        

        return true;
    }
}