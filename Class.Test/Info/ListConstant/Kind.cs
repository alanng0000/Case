namespace Class.Test.Info.ListConstant;






class Kind : global::Class.Test.Kind
{
    public override bool Init()
    {
        base.Init();



        this.Name = "ListConstant";






        this.AddUnit(new Empty.Unit());





        this.AddUnit(new TwoObjects.Unit());





        this.AddUnit(new FourObjects.Unit());





        this.AddUnit(new NestedListConstant.Unit());





        this.AddUnit(new NestedListConstantTrueL.Unit());





        return true;
    }
}