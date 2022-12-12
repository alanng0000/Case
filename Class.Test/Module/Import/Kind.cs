namespace Class.Test.Module.Import;






class Kind : global::Class.Test.Kind
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