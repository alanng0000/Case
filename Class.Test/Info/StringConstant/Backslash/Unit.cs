namespace Class.Test.Info.StringConstant.Backslash;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Backslash";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadStringConstant("\\");
    }
}