namespace Class.Test.Info.IntConstant.FourHundredTwenty;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "FourHundredTwenty";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadIntConstant(420);
    }
}