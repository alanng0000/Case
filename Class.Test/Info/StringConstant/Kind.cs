namespace Class.Test.Info.StringConstant;






class Kind : global::Class.Test.Kind
{
    public override bool Init()
    {
        base.Init();



        this.Name = "StringConstant";






        this.AddUnit(new Empty.Unit());




        this.AddUnit(new OneLetter.Unit());




        this.AddUnit(new Alpha.Unit());




        this.AddUnit(new Space.Unit());




        this.AddUnit(new Quote.Unit());




        this.AddUnit(new LineEnd.Unit());




        this.AddUnit(new Tab.Unit());




        this.AddUnit(new Backslash.Unit());





        return true;
    }
}