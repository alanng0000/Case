namespace Case.Test.Module.Module;






class Kind : global::Case.Test.Kind
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Module";






        this.AddUnit(new Valid.Unit());




        this.AddUnit(new TwoParts.Unit());




        this.AddUnit(new ThreeParts.Unit());
        





        return true;
    }
}