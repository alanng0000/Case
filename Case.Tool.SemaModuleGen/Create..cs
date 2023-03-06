namespace Case.Tool.SemaModuleGen;




class Create : Object
{
    public Module ExecuteSemaModule()
    {
        ModuleRef varRef;

        varRef = this.ExecuteSemaRef();
        



        Array varClass;

        varClass = this.ExecuteSemaClass();




        Array import;

        import = this.ExecuteSemaImport();



        Array export;

        export = this.ExecuteSemaExport();





        Module module;


        module = new Module();


        module.Init();


        module.Ref = varRef;


        module.Class = varClass;


        module.Import = import;


        module.Export = export;



        Module ret;

        ret = module;


        return ret;
    }






    private ModuleRef ExecuteSemaRef()
    {
        ModuleInt varInt;

        varInt = this.ExecuteSemaInt();



        ModuleVer ver;

        ver = this.ExecuteSemaVer();





        ModuleRef varRef;

        varRef = new ModuleRef();

        varRef.Init();

        varRef.Int = varInt;

        varRef.Ver = ver;




        ModuleRef ret;

        ret = varRef;

        return ret;
    }








    private ModuleInt ExecuteSemaInt()
    {
        CaseConstant constant;

        constant = CaseConstant.This;



        ModuleInt varInt;

        varInt = new ModuleInt();

        varInt.Init();

        varInt.Value = constant.SemaIntent;




        ModuleInt ret;

        ret = varInt;

        return ret;
    }






    private ModuleVer ExecuteSemaVer()
    {
        CaseConstant constant;

        constant = CaseConstant.This;



        ModuleVer ver;

        ver = new ModuleVer();

        ver.Init();

        ver.Value = constant.SemaVer;




        ModuleVer ret;

        ret = ver;

        return ret;
    }





    private ModuleName ExecuteSemaName()
    {
        CaseConstant constant;

        constant = CaseConstant.This;




        ModuleName name;

        name = new ModuleName();

        name.Init();

        name.Value = constant.SemaName;



        ModuleName ret;

        ret = name;


        return ret;
    }




    private Array ExecuteSemaClass()
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




    private Array ExecuteSemaImport()
    {
        Array array;

        array = new Array();

        array.Count = 0;

        array.Init();



        Array ret;

        ret = array;

        return ret;
    }




    private Array ExecuteSemaExport()
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
            ModuleExport export;

            export = this.CreateExport(i);



            array.Set(i, export);




            i = i + 1;
        }





        Array ret;

        ret = array;

        return ret;
    }




    private ModuleExport CreateExport(int index)
    {
        ModuleExport export;

        export = new ModuleExport();

        export.Init();

        export.Class = index;




        ModuleExport ret;

        ret = export;

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