namespace Case.Check;




public class ModuleMap : Map
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