namespace Case.Tool.SemaModeGen;




class Create : Object
{
    public Mode ExecuteSemaMode()
    {
        ModeRef varRef;

        varRef = this.ExecuteSemaRef();
        



        Array varClass;

        varClass = this.ExecuteSemaClass();




        Array import;

        import = this.ExecuteSemaImport();



        Array export;

        export = this.ExecuteSemaExport();





        Mode module;


        module = new Mode();


        module.Init();


        module.Ref = varRef;


        module.Class = varClass;


        module.Import = import;


        module.Export = export;



        Mode ret;

        ret = module;


        return ret;
    }






    private ModeRef ExecuteSemaRef()
    {
        ModeInt varInt;

        varInt = this.ExecuteSemaInt();



        ModeVer ver;

        ver = this.ExecuteSemaVer();





        ModeRef varRef;

        varRef = new ModeRef();

        varRef.Init();

        varRef.Int = varInt;

        varRef.Ver = ver;




        ModeRef ret;

        ret = varRef;

        return ret;
    }








    private ModeInt ExecuteSemaInt()
    {
        CaseConstant constant;

        constant = CaseConstant.This;



        ModeInt varInt;

        varInt = new ModeInt();

        varInt.Init();

        varInt.Value = constant.SemaIntent;




        ModeInt ret;

        ret = varInt;

        return ret;
    }






    private ModeVer ExecuteSemaVer()
    {
        CaseConstant constant;

        constant = CaseConstant.This;



        ModeVer ver;

        ver = new ModeVer();

        ver.Init();

        ver.Value = constant.SemaVer;




        ModeVer ret;

        ret = ver;

        return ret;
    }





    private ModeName ExecuteSemaName()
    {
        CaseConstant constant;

        constant = CaseConstant.This;




        ModeName name;

        name = new ModeName();

        name.Init();

        name.Value = constant.SemaName;



        ModeName ret;

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
            ModeExport export;

            export = this.CreateExport(i);



            array.Set(i, export);




            i = i + 1;
        }





        Array ret;

        ret = array;

        return ret;
    }




    private ModeExport CreateExport(int index)
    {
        ModeExport export;

        export = new ModeExport();

        export.Init();

        export.Class = index;




        ModeExport ret;

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