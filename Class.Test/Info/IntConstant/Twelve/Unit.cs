namespace Class.Test.Info.IntConstant.Twelve;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Twelve";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadIntConstant(12);
    }
}