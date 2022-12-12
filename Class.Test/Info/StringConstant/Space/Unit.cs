namespace Class.Test.Info.StringConstant.Space;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Space";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadStringConstant(" ");
    }
}