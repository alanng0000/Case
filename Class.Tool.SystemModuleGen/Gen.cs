namespace Class.Tool.SystemModuleGen;




class Gen : Object
{
    private Module SystemModule { get; set; }



    public int Execute()
    {
        this.SystemModule = this.CreateSystemModule();



        this.SetPath();



        this.WriteModule();



        this.WriteFile();



        return 0;
    }





    private bool WriteModule()
    {
        Write write;

        write = new Write();

        write.Init();


        write.Module = this.SystemModule;


        write.Path = this.DataPath;



        write.Execute();




        this.Data = write.Data;



        return true;
    }






    private bool SetPath()
    {
        ModulePath modulePath;

        modulePath = ModulePath.This;




        ulong intent;
        
        intent = this.SystemModule.Refer.Intent.Value;


        ulong ver;

        ver = this.SystemModule.Refer.Ver.Value;





        string s;


        s = modulePath.Module(intent, ver);




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







    private Module CreateSystemModule()
    {
        ModuleRefer refer;

        refer = this.CreateSystemRefer();



        ModuleName name;

        name = this.CreateSystemName();



        Array varClass;

        varClass = this.CreateSystemClass();




        Array import;

        import = this.CreateSystemImport();



        Array export;

        export = this.CreateSystemExport();




        ClassIndex entry;

        entry = this.CreateSystemEntry();





        Module module;


        module = new Module();


        module.Init();


        module.Refer = refer;


        module.Name = name;


        module.Class = varClass;


        module.Import = import;


        module.Export = export;


        module.Entry = entry;



        Module ret;

        ret = module;


        return ret;
    }






    private ModuleRefer CreateSystemRefer()
    {
        ModuleIntent intent;

        intent = this.CreateSystemIntent();



        ModuleVer ver;

        ver = this.CreateSystemVer();





        ModuleRefer refer;

        refer = new ModuleRefer();

        refer.Init();

        refer.Intent = intent;

        refer.Ver = ver;




        ModuleRefer ret;

        ret = refer;

        return ret;
    }








    private ModuleIntent CreateSystemIntent()
    {
        ModuleIntent intent;

        intent = new ModuleIntent();

        intent.Init();

        intent.Value = 0;




        ModuleIntent ret;

        ret = intent;

        return ret;
    }






    private ModuleVer CreateSystemVer()
    {
        ModuleVer ver;

        ver = new ModuleVer();

        ver.Init();

        ver.Value = 0;




        ModuleVer ret;

        ret = ver;

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




    private Array CreateSystemImport()
    {
        Array array;

        array = new Array();

        array.Count = 0;

        array.Init();



        Array ret;

        ret = array;

        return ret;
    }




    private Array CreateSystemExport()
    {
        Array array;

        array = new Array();

        array.Count = 4;

        array.Init();





        int count;

        count = array.Count;



        int i;

        i = 0;


        while (i < count)
        {
            Export export;

            export = this.CreateExport(i);



            array.Set(i, export);




            i = i + 1;
        }





        Array ret;

        ret = array;

        return ret;
    }




    private Export CreateExport(int index)
    {
        Convert convert;

        convert = Convert.This;




        ulong o;


        o = convert.ULong(index);




        ClassIndex classIndex;

        classIndex = new ClassIndex();

        classIndex.Init();

        classIndex.Value = o;




        Export export;

        export = new Export();

        export.Init();

        export.Index = classIndex;




        Export ret;

        ret = export;

        return ret;
    }






    private ClassIndex CreateSystemEntry()
    {
        Constant constant;

        constant = Constant.This;




        ulong o;

        o = constant.NullClassIndex;

        


        ClassIndex index;

        index = new ClassIndex();

        index.Init();

        index.Value = o;




        ClassIndex ret;

        ret = index;

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