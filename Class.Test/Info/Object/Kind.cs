namespace Class.Test.Info.Object;






class Kind : global::Class.Test.Kind
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Object";





        this.AddUnit(new ZeroFields.Unit());




        this.AddUnit(new TwoFields.Unit());
        





        return true;
    }
}