namespace Class;





public class ClassImportMap : Map
{
    public override bool Init()
    {
        ClassIndexCompare compare;


        compare = new ClassIndexCompare();


        compare.Init();




        this.Compare = compare;





        base.Init();





        return true;
    }
}