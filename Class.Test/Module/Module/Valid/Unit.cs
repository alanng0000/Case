namespace Class.Test.Module.Module.Valid;






class Unit : global::Class.Test.Module.Unit
{
    public override bool Init()
    {
        base.Init();




        this.Name = "Valid";




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


        b = (name == "Module");
        



        bool ret;


        ret = b;



        return ret;
    }
}