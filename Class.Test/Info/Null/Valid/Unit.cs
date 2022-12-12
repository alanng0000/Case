namespace Class.Test.Info.Null.Valid;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Valid";



        return true;
    }





    public override bool Execute()
    {
        return this.ReadNull();
    }
}