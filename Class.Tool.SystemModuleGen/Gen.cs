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
        ModuleRefer refer;

        refer = this.CreateSystemRefer();



        ModuleName name;

        name = this.CreateSystemName();



        Array varClass;

        varClass = this.CreateSystemClass();




        Module module;


        module = new Module();


        module.Init();


        module.Refer = refer;


        module.Name = name;


        return true;
    }






    private ModuleRefer CreateSystemRefer()
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




        ModuleRefer ret;

        ret = refer;

        return ret;
    }





    private ModuleName CreateSystemName()
    {
        ModuleName name;

        name = new ModuleName();

        name.Init();

        name.Value = "System";



        ModuleName ret;

        ret = name;


        return ret;
    }




    private Array CreateSystemClass()
    {
        string objectName;

        objectName = "Object";


        string boolName;

        boolName = "Bool";


        string intName;

        intName = "Int";


        string stringName;

        stringName = "String";




        int count;

        count = 4;




        Array array;

        array = new Array();

        array.Count = count;

        array.Init();





        this.Array = array;


        this.Index = 0;




        this.AddItem(objectName);


        this.AddItem(boolName);


        this.AddItem(intName);


        this.AddItem(stringName);





        Array ret;

        ret = array;


        return ret;
    }






    private Array Array { get; set; }



    private int Index { get; set; }




    private bool AddItem(object item)
    {
        this.Array.Set(this.Index, item);


        
        this.Index = this.Index + 1;



        return true;
    }
}