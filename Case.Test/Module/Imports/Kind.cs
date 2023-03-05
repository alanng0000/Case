namespace Case.Test.Module.Imports;






class Kind : global::Case.Test.Kind
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