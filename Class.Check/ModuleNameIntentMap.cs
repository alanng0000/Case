namespace Class.Check;





public class ModuleNameMap : Map
{
    public override bool Init()
    {
        ModuleNameCompare compare;


        compare = new ModuleNameCompare();


        compare.Init();




        this.Compare = compare;





        base.Init();





        return true;
    }
}