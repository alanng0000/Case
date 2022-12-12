namespace Class.Test.Info.BoolConstant.False;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "False";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadBoolConstant(false);
    }
}