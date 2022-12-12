namespace Class.Test.Info.StringConstant.Alpha;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Alpha";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadStringConstant("We52");
    }
}