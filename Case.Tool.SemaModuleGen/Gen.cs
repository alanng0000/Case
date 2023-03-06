namespace Case.Tool.SemaModuleGen;




class Gen : Object
{
    private Module SemaModule { get; set; }



    public int Execute()
    {
        this.CreateSemaModule();



        this.SetPath();



        this.WriteModule();



        this.WriteFile();



        return 0;
    }

    



    private bool CreateSemaModule()
    {
        Create create;

        create = new Create();

        create.Init();



        Module m;

        m = create.ExecuteSemaModule();



        this.SemaModule = m;



        return true;
    }





    private bool WriteModule()
    {
        ModuleWrite write;

        write = new ModuleWrite();

        write.Init();


        write.Mode = this.SemaModule;




        write.Execute();




        this.Data = write.Data;



        return true;
    }






    private bool SetPath()
    {
        ModulePath modulePath;

        modulePath = ModulePath.This;





        string s;


        s = modulePath.Mode(this.SemaModule.Ref);




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