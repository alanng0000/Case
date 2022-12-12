namespace Class.Test.Info.ListConstant.FourObjects;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "FourObjects";



        return true;
    }






    public override bool Execute()
    {
        List list;


        list = new List();


        list.Init();





        list.Add(null);




        list.Add(true);




        ulong k;


        k = 8;



        list.Add(k);




        list.Add("GKjl");





        return this.ReadListConstant(list);
    }
}