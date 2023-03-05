namespace Case.Test.Module.Module.TwoParts;






class Unit : global::Case.Test.Module.Unit
{
    public override bool Init()
    {
        base.Init();




        this.Name = "TwoParts";




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


        b = (name == "A.B");





        bool ret;


        ret = b;



        return ret;
    }
}