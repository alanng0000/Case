namespace Case.Test.Module.Import.ImportObject;






class Unit : global::Case.Test.Module.Unit
{
    public override bool Init()
    {
        base.Init();




        this.Name = "ImportObject";




        return true;
    }





    public override bool Execute()
    {
        this.Compile();





        if (this.Null(this.NextString()))
        {
            return false;
        }





        if (!this.NextInt().HasValue)
        {
            return false;
        }




        

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
        




        ulong classIndex;


        classIndex = u.Value;





        bool ba;



        ba = (classIndex == 0);



        if (!ba)
        {
            return false;
        }
        



        return true;
    }
}