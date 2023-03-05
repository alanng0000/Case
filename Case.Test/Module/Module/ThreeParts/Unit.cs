namespace Case.Test.Module.Module.ThreeParts;






class Unit : global::Case.Test.Module.Unit
{
    public override bool Init()
    {
        base.Init();




        this.Name = "ThreeParts";




        return true;
    }





    public override bool Execute()
    {
        this.Compile();




        string name;


        name = this.NextString();




        if (this.Null(name))
        {
            return false;
        }





        bool b;


        b = (name == "A.B.D");





        bool ret;


        ret = b;



        return ret;
    }
}