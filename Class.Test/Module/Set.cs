namespace Class.Test.Module;






class Set : global::Class.Test.Set
{
    public override bool Init()
    {
        base.Init();




        this.Name = "Module";





        this.AddKind(new Module.Kind());




        this.AddKind(new Import.Kind());




        this.AddKind(new Imports.Kind());





        return true;
    }
}