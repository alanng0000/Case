namespace Class.Test.Info.IntConstant.OneTrillion;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "OneTrillion";



        return true;
    }





    public override bool Execute()
    {
        bool b;
        
        
        b = this.ReadIntConstant(1000000000000);



        return !b;
    }
}