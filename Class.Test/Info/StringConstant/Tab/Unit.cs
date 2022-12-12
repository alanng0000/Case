namespace Class.Test.Info.StringConstant.Tab;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Tab";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadStringConstant("\t");
    }
}