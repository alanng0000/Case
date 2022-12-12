namespace Class.Test.Info.StringConstant.Empty;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Empty";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadStringConstant("");
    }
}