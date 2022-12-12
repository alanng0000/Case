namespace Class.Test.Info.IntConstant.One;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "One";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadIntConstant(1);
    }
}