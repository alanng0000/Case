namespace Class.Test.Info.Zero;






class Kind : global::Class.Test.Kind
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Zero";





        this.AddUnit(new Zero.Unit());




        return true;
    }
}