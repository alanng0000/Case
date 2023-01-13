namespace Class.Tool.SystemModuleGen;




class Gen : Object
{
    private Module SystemModule { get; set; }



    public int Execute()
    {
        return 0;
    }




    private bool CreateSystemModule()
    {
        ModuleIntent intent;

        intent = new ModuleIntent();

        intent.Init();

        intent.Value = 0;




        ModuleVer ver;

        ver = new ModuleVer();

        ver.Init();

        ver.Value = 0;




        ModuleRefer refer;

        refer = new ModuleRefer();

        refer.Init();

        refer.Intent = intent;

        refer.Ver = ver;





        ModuleName name;

        name = new ModuleName();

        name.Init();

        name.Value = "System";




        Module module;


        module = new Module();


        module.Init();


        module.Refer = refer;


        module.Name = name;


        return true;
    }

}