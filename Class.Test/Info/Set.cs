namespace Class.Test.Info;






class Set : global::Class.Test.Set
{
    public override bool Init()
    {
        base.Init();




        this.Name = "Info";






        this.AddKind(new Zero.Kind());




        this.AddKind(new Null.Kind());




        this.AddKind(new BoolConstant.Kind());




        this.AddKind(new IntConstant.Kind());




        this.AddKind(new StringConstant.Kind());




        this.AddKind(new ListConstant.Kind());





        this.AddKind(new Object.Kind());





        return true;
    }
}