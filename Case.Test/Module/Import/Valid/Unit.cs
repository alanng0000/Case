namespace Case.Test.Module.Import.Valid;






class Unit : global::Case.Test.Module.Unit
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





        if (this.Null(this.NextString()))
        {
            return false;
        }






        ulong? u;



        u = this.NextInt();



        if (!u.HasValue)
        {
            return false;
        }





        ulong importCount;


        importCount = u.Value;

        




        bool ba;


        ba = (importCount == 1);



        if (!ba)
        {
            return false;
        }
        



        string name;


        name = this.NextString();



        if (this.Null(name))
        {
            return false;
        }





        u = this.NextInt();



        if (!u.HasValue)
        {
            return false;
        }




        ulong classIndex;


        classIndex = u.Value;





        bool bb;



        bb = (name == "System" & 
            classIndex == 0
            );



        if (!bb)
        {
            return false;
        }
        



        return true;
    }
}