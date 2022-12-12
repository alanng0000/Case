namespace Class.Test.Info.ListConstant.NestedListConstantTrueL;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "NestedListConstantTrueL";



        return true;
    }






    public override bool Execute()
    {
        List list;



        list = new List();



        list.Init();




        list.Add(true);




        list.Add("L");




        return this.ReadListConstantListConstant(list);
    }
}