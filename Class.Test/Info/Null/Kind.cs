namespace Class.Test.Info.Null;






class Kind : global::Class.Test.Kind
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Null";





        this.AddUnit(new Valid.Unit());




        return true;
    }
}