namespace Case.Tool.SystemModuleGen;




class Gen : Object
{
    private Module SystemModule { get; set; }



    public int Execute()
    {
        this.CreateSystemModule();



        this.SetPath();



        this.WriteModule();



        this.WriteFile();



        return 0;
    }

    



    private bool CreateSystemModule()
    {
        Create create;

        create = new Create();

        create.Init();



        Module m;

        m = create.ExecuteSystemModule();



        this.SystemModule = m;



        return true;
    }





    private bool WriteModule()
    {
        ModuleWrite write;

        write = new ModuleWrite();

        write.Init();


        write.Module = this.SystemModule;




        write.Execute();




        this.Data = write.Data;



        return true;
    }






    private bool SetPath()
    {
        ModulePath modulePath;

        modulePath = ModulePath.This;





        string s;


        s = modulePath.Module(this.SystemModule.Ref);




        string su;


        su = modulePath.ModuleDataName;





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