namespace Class.Test.Info.IntConstant;






class Kind : global::Class.Test.Kind
{
    public override bool Init()
    {
        base.Init();



        this.Name = "IntConstant";





        this.AddUnit(new One.Unit());




        this.AddUnit(new Twelve.Unit());




        this.AddUnit(new FourHundredTwenty.Unit());




        this.AddUnit(new OneTrillion.Unit());
        





        return true;
    }
}