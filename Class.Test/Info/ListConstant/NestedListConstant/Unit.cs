namespace Class.Test.Info.ListConstant.NestedListConstant;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "NestedListConstant";



        return true;
    }






    public override bool Execute()
    {
        List list;


        list = new List();


        list.Init();



        return this.ReadListConstantListConstant(list);
    }
}