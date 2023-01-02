namespace Class.Check;






public class DataMap : Map
{
    public override bool Init()
    {
        ModuleCompare compare;


        compare = new ModuleCompare();


        compare.Init();



        this.Compare = compare;

        



        base.Init();



        

        return true;
    }
}