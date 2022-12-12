namespace Class.Test.Info.ListConstant.Empty;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "Empty";



        return true;
    }






    public override bool Execute()
    {
        List list;


        list = new List();


        list.Init();



        return this.ReadListConstant(list);
    }
}