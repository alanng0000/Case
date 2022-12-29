namespace Class.Port;





public class Read : Object
{
    public override bool Init()
    {
        base.Init();




        this.TextInfra = new TextInfra();



        this.TextInfra.Init();




        this.RangeInfra = new RangeInfra();



        this.RangeInfra.Init();

        



        return true;
    }



    private TextInfra TextInfra { get; set; }





    private RangeInfra RangeInfra { get; set; }






    public string Text { get; set; }





    public Port Execute()
    {
        return null;
    }
}