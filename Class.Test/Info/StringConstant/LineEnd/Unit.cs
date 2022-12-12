namespace Class.Test.Info.StringConstant.LineEnd;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "LineEnd";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadStringConstant("\n");
    }
}