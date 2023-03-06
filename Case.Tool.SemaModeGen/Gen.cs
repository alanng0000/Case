namespace Case.Tool.SemaModeGen;




class Gen : Object
{
    private Mode SemaMode { get; set; }



    public int Execute()
    {
        this.CreateSemaMode();



        this.SetPath();



        this.WriteMode();



        this.WriteFile();



        return 0;
    }

    



    private bool CreateSemaMode()
    {
        Create create;

        create = new Create();

        create.Init();



        Mode m;

        m = create.ExecuteSemaMode();



        this.SemaMode = m;



        return true;
    }





    private bool WriteMode()
    {
        ModeWrite write;

        write = new ModeWrite();

        write.Init();


        write.Mode = this.SemaMode;




        write.Execute();




        this.Data = write.Data;



        return true;
    }






    private bool SetPath()
    {
        ModePath modulePath;

        modulePath = ModePath.This;





        string s;


        s = modulePath.Mode(this.SemaMode.Ref);




        string su;


        su = modulePath.ModeDataName;





        s = Path.Combine(s, su);




        this.DataPath = s;



        return true;
    }





    private string DataPath { get; set; }




    private Data Data { get; set; }





    private bool WriteFile()
    {
        File.WriteAllBytes(this.DataPath, this.Data.Value);
        
        


        return true;
    }
}