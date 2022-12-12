namespace Class.Test.Module.Imports;






class Kind : global::Class.Test.Kind
{
    public override bool Init()
    {
        base.Init();




        this.Name = "Imports";






        this.AddUnit(new OneImports.Unit());




        this.AddUnit(new TwoImports.Unit());
        





        return true;
    }
}