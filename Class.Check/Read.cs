namespace Class.Check;







public class Read : Object
{
    public Data Data { get; set; }




    public ulong Index { get; set; }




    public Module Result { get; set; }




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
        Module module;


        module = this.ExecuteModule();




        this.Result = module;



        return true;
    }




    private Module ExecuteModule()
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





        ImportList import;

        import = this.ExecuteImportList();


        if (this.Null(import))
        {
            return null;
        }




        ExportList export;

        export = this.ExecuteExportList();


        if (this.Null(export))
        {
            return null;
        }





        Entry entry;

        entry = this.ExecuteEntry();


        if (this.Null(entry))
        {
            return null;
        }





        Module ret;

        ret = new Module();

        ret.Name = name;

        ret.Ver = ver;

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

        ret.Value = value;


        return ret;
    }






    private ClassName ExecuteClassName()
    {
        string value;


        value = this.NameValue();



        if (this.Null(value))
        {
            return null;
        }




        ClassName ret;

        ret = new ClassName();

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





    
    private ImportList ExecuteImportList()
    {
        ulong? u;


        u = this.Count();




        if (!u.HasValue)
        {
            return null;
        }




        ImportList list;

        list = new ImportList();

        list.Init();





        Import import;




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



        ImportList ret;

        ret = list;

        return ret;
    }






    private Import ExecuteImport()
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




        ClassName varClass;

        varClass = this.ExecuteClassName();


        if (this.Null(varClass))
        {
            return null;
        }





        ClassName name;

        name = this.ExecuteClassName();


        if (this.Null(name))
        {
            return null;
        }



        Import ret;

        ret = new Import();

        ret.Init();

        ret.Class = null;

        ret.Name = name;

        return ret;
    }







    private ExportList ExecuteExportList()
    {
        ulong? u;


        u = this.Count();




        if (!u.HasValue)
        {
            return null;
        }




        ExportList list;

        list = new ExportList();

        list.Init();





        Export export;




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



        ExportList ret;

        ret = list;

        return ret;
    }








    private Export ExecuteExport()
    {
        ClassName varClass;


        varClass = this.ExecuteClassName();



        if (this.Null(varClass))
        {
            return null;
        }




        Export ret;

        ret = new Export();

        ret.Init();

        ret.Class = null;

        return ret;
    }






    private Entry ExecuteEntry()
    {
        ClassName varClass;


        varClass = this.ExecuteClassName();



        Entry ret;

        ret = new Entry();

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


        count = InfraConstant.This.IntByteCount;



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