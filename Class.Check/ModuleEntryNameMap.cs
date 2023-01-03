namespace Class.Check;





public class ModuleEntryNameMap : Map
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