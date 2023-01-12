namespace Class.Check;



class Infra : Object
{
    public Compile Compile { get; set; }



    public Refer CreateRefer()
    {
        return null;
    }



    private Module CreateReferModule(Module module)
    {
        Module m;

        m = new Module();

        m.Init();

        

        ModuleName name;

        name = this.CreateReferModuleName(module.Name);


        m.Name = name;








        return null;
    }




    private ModuleRefer CreateReferModuleRefer(ModuleRefer refer)
    {
        ModuleRefer a;

        a = new ModuleRefer();

        a.Init();




        ModuleIntent intent;

        intent = this.CreateReferModuleIntent(refer.Intent);


        a.Intent = intent;




        if (refer.Ver == null)
        {

        }





        ModuleRefer ret;

        ret = a;

        return ret;
    }





    private ulong GetCurrentModuleVer(ModuleIntent intent)
    {
        return 0;
    }





    private ModuleIntent CreateReferModuleIntent(ModuleIntent intent)
    {
        ModuleIntent a;

        a = new ModuleIntent();

        a.Init();

        a.Value = intent.Value;


        return a;
    }



    private ModuleName CreateReferModuleName(ModuleName name)
    {
        ModuleName a;

        a = new ModuleName();

        a.Init();

        a.Value = name.Value;


        return a;
    }
}