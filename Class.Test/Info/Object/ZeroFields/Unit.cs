namespace Class.Test.Info.Object.ZeroFields;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "ZeroFields";



        return true;
    }





    public override bool Execute()
    {
        string h;



        h = "Hig";




        Map map;


        map = new Map();


        map.Compare = new StringCompare();


        map.Init();




        string s;


        s = this.RootObjectText(h, map);




        InfoObject o;


        o = this.RootObject(s);




        if (this.Null(o))
        {
            return false;
        }




        bool ba;


        ba = (o.Class.Value == h);



        if (!ba)
        {
            return false;
        }




        bool bb;


        bb = (o.Fields.Count == 0);



        if (!bb)
        {
            return false;
        }




        return true;
    }
}