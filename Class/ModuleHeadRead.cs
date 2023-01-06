namespace Class;







class ModuleHeadRead : Object
{
    public Data Data { get; set; }




    public ulong Index { get; set; }




    public Map ClassImportList { get; set; }





    public CheckModule Result { get; set; }


    




    private Convert Convert { get; set; }





    public override bool Init()
    {
        base.Init();



        this.Convert = new Convert();


        this.Convert.Init();



        return true;
    }





    public bool Execute()
    {
        CheckModule module;


        module = this.ExecuteModule();




        this.Result = module;



        return true;
    }




    private CheckModule ExecuteModule()
    {
        ModuleName name;

        name = this.ExecuteModuleName();


        if (this.Null(name))
        {
            return null;
        }




        ModuleVer ver;

        ver = this.ExecuteModuleVer();


        if (this.Null(ver))
        {
            return null;
        }





        CheckImportList import;

        import = this.ExecuteImportList();


        if (this.Null(import))
        {
            return null;
        }




        CheckExportList export;

        export = this.ExecuteExportList();


        if (this.Null(export))
        {
            return null;
        }





        CheckModuleEntry entry;

        entry = this.ExecuteEntry();


        if (this.Null(entry))
        {
            return null;
        }





        CheckModule ret;

        ret = new CheckModule();

        ret.Init();

        return ret;
    }












    private ModuleName ExecuteModuleName()
    {
        string value;


        value = this.NameValue();



        if (this.Null(value))
        {
            return null;
        }




        ModuleName ret;

        ret = new ModuleName();

        ret.Init();


        return ret;
    }






    private CheckClassName ExecuteClassName()
    {
        string value;


        value = this.NameValue();



        if (this.Null(value))
        {
            return null;
        }




        CheckClassName ret;

        ret = new CheckClassName();

        ret.Init();

        ret.Value = value;


        return ret;
    }





    private ModuleVer ExecuteModuleVer()
    {
        ulong? u;

        u = this.ExecuteInt();


        if (!u.HasValue)
        {
            return null;
        }



        ulong value;


        value = u.Value;



        ModuleVer ret;

        ret = new ModuleVer();

        ret.Init();

        ret.Value = value;

        return ret;
    }





    
    private CheckImportList ExecuteImportList()
    {
        ulong? u;


        u = this.Count();




        if (!u.HasValue)
        {
            return null;
        }




        CheckImportList list;

        list = new CheckImportList();

        list.Init();





        CheckImport import;




        ulong count;

        count = u.Value;




        ulong i;

        i = 0;


        while (i < count)
        {
            import = this.ExecuteImport();


            if (this.Null(import))
            {
                return null;
            }



            list.Add(import);



            i = i + 1;
        }



        CheckImportList ret;

        ret = list;

        return ret;
    }






    private CheckImport ExecuteImport()
    {
        ModuleName module;

        module = this.ExecuteModuleName();


        if (this.Null((module)))
        {
            return null;
        }




        ModuleVer ver;

        ver = this.ExecuteModuleVer();


        if (this.Null(ver))
        {
            return null;
        }




        CheckClassName varClass;

        varClass = this.ExecuteClassName();


        if (this.Null(varClass))
        {
            return null;
        }





        CheckClassName name;

        name = this.ExecuteClassName();


        if (this.Null(name))
        {
            return null;
        }



        CheckImport ret;

        ret = new CheckImport();

        ret.Init();

        ret.Class = null;

        ret.Name = name;

        return ret;
    }







    private CheckExportList ExecuteExportList()
    {
        ulong? u;


        u = this.Count();




        if (!u.HasValue)
        {
            return null;
        }




        CheckExportList list;

        list = new CheckExportList();

        list.Init();





        CheckExport export;




        ulong count;

        count = u.Value;




        ulong i;

        i = 0;


        while (i < count)
        {
            export = this.ExecuteExport();


            if (this.Null(export))
            {
                return null;
            }



            list.Add(export);



            i = i + 1;
        }



        CheckExportList ret;

        ret = list;

        return ret;
    }








    private CheckExport ExecuteExport()
    {
        CheckClassName varClass;


        varClass = this.ExecuteClassName();



        if (this.Null(varClass))
        {
            return null;
        }




        CheckExport ret;

        ret = new CheckExport();

        ret.Init();

        ret.Class = null;

        return ret;
    }






    private CheckModuleEntry ExecuteEntry()
    {
        CheckClassName varClass;


        varClass = this.ExecuteClassName();



        CheckModuleEntry ret;

        ret = new CheckModuleEntry();

        ret.Init();

        ret.Class = null;

        return ret;
    }







    private ulong? Count()
    {
        ulong? u;

        u = this.ExecuteInt();


        return u;
    }
    





    private string NameValue()
    {
        string value;

        value = this.ExecuteString();



        return value;
    }









    

    private bool CheckByteAvailable(ulong count)
    {
        ulong a;


        a = this.ULong(this.Data.Value.Length);



        return this.Index + count <= a;
    }





    private string ExecuteString()
    {
        ulong? u;


        u = this.ExecuteInt();



        if (!u.HasValue)
        {
            return null;
        }




        ulong count;

        count = u.Value;




        if (!this.CheckByteAvailable(count))
        {
            return null;
        }




        StringBuilder sb;


        sb = new StringBuilder();




        char oc;


        byte ob;




        ulong i;


        i = 0;



        while (i < count)
        {
            ob = this.Byte();



            oc = (char)ob;



            sb.Append(oc);



            i = i + 1;
        }



        string s;


        s = sb.ToString();




        string ret;

        ret = s;


        return ret;
    }







    private ulong? ExecuteInt()
    {
        ulong count;


        count = Constant.This.IntByteCount;



        if (!this.CheckByteAvailable(count))
        {
            return null;
        }




        ulong k;


        k = this.Convert.ByteListULong(this.Data.Value, this.Index);




        this.Index = this.Index + count;




        ulong ret;

        ret = k;


        return ret;
    }





    private byte Byte()
    {
        byte ob;

        ob = this.Data.Value[this.Index];



        this.Index = this.Index + 1;



        byte ret;

        ret = ob;

        return ret;
    }






    private bool Null(object o)
    {
        return o == null;
    }





    private ulong ULong(int k)
    {
        return (ulong)k;
    }




    private int SInt32(ulong k)
    {
        return (int)k;
    }
}