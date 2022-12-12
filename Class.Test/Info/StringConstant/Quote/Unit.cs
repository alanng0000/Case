namespace Class.Test.Info.StringConstant.Quote;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Quote";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadStringConstant("\"");
    }
}