namespace Class.Test.Info.BoolConstant;






class Kind : global::Class.Test.Kind
{
    public override bool Init()
    {
        base.Init();



        this.Name = "BoolConstant";






        this.AddUnit(new True.Unit());





        this.AddUnit(new False.Unit());





        return true;
    }
}