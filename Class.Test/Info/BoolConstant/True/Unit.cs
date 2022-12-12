namespace Class.Test.Info.BoolConstant.True;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "True";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadBoolConstant(true);
    }
}