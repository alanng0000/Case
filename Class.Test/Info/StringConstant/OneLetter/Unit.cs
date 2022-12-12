namespace Class.Test.Info.StringConstant.OneLetter;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "OneLetter";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadStringConstant("A");
    }
}