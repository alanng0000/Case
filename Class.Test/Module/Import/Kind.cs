namespace Case.Test.Module.Import;






class Kind : global::Case.Test.Kind
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Import";






        this.AddUnit(new Valid.Unit());




        this.AddUnit(new ImportObject.Unit());
        





        return true;
    }
}