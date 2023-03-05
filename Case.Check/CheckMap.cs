namespace Case.Check;




public class CheckMap : Map
{
    public override bool Init()
    {
        NodeCompare compare;


        compare = new NodeCompare();


        compare.Init();




        this.Compare = compare;




        base.Init();
        



        return true;
    }
}