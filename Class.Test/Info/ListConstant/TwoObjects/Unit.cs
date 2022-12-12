namespace Class.Test.Info.ListConstant.TwoObjects;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "TwoObjects";



        return true;
    }






    public override bool Execute()
    {
        List list;


        list = new List();


        list.Init();





        list.Add(true);




        ulong k;


        k = 8;



        list.Add(k);




        return this.ReadListConstant(list);
    }
}