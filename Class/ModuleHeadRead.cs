namespace Class;







class ModuleHeadRead : Object
{
    public Data Data { get; set; }




    public ulong Index { get; set; }





    public ModuleImport Import { get; set; }





    public CheckModule Result { get; set; }


    




    private Convert Convert { get; set; }




    private Map ClassImportMap { get; set; }




    private CheckClassMap ClassMap { get; set; }





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




        this.ClassImportMap = null;




        this.Result = module;



        return true;
    }







    private CheckModule ExecuteModule()
    {
        bool b;


        b = this.ExecutePassModuleIntent();


        if (!b)
        {
            return null;
        }





        b = this.ExecutePassModuleVer();


        if (!b)
        {
            return null;
        }
        



        b = this.ExecutePassModuleName();


        if (!b)
        {
            return null;
        }







        ClassIndexCompare compare;

        compare = new ClassIndexCompare();

        compare.Init();






        this.ClassImportMap = new Map();


        this.ClassImportMap.Compare = compare;


        this.ClassImportMap.Init();




        b = this.ExecuteClassList();
        

        if (!b)
        {
            return null;
        }







        b = this.ExecuteImportList();


        if (!b)
        {
            return null;
        }





        this.ClassMap = new CheckClassMap();


        this.ClassMap.Init();





        b = this.ExecuteExportList();


        if (!b)
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

        ret.Refer = this.Import.Refer;

        ret.Name = this.Import.Name;

        return ret;
    }






    private bool ExecuteClassList()
    {
        ulong ? u;

        u = this.Count();



        if (!u.HasValue)
        {
            return false;
        }





        ulong count;

        count = u.Value;



        ulong i;


        i = 0;


        while (i < count)
        {
            CheckClassName className;


            className = this.ExecuteClassName();



            if (this.Null(className))
            {
                return false;
            }




            CheckClassName uu;


            uu = (CheckClassName)this.Import.ClassImport.Get(className);



            if (!this.Null(uu))
            {
                ClassIndex oi;

                oi = new ClassIndex();

                oi.Init();

                oi.Value = i;




                ClassImport a;


                a = new ClassImport();


                a.Init();


                a.Index = oi;


                a.Class = className;


                a.Name = uu;
                



                Pair pair;

                pair = new Pair();

                pair.Init();

                pair.Key = oi;

                pair.Value = a;



                this.ClassImportMap.Add(pair);
            }




            i = i + 1;
        }




        return true;
    }




    private bool ExecuteImportList()
    {
        ulong ? u;

        u = this.Count();



        if (!u.HasValue)
        {
            return false;
        }





        ulong count;

        count = u.Value;



        ulong i;


        i = 0;


        while (i < count)
        {
            bool b;


            b = this.ExecuteImport();


            if (!b)
            {
                return false;
            }




            i = i + 1;
        }



        return true;
    }




    private bool ExecuteImport()
    {
        bool b;



        b = this.ExecutePassModuleIntent();


        if (!b)
        {
            return false;
        }





        b = this.ExecutePassModuleVer();


        if (!b)
        {
            return false;
        }




        b = this.ExecutePassClassIndex();


        if (!b)
        {
            return false;
        }



        return true;
    }





    private bool ExecuteExportList()
    {
        ulong ? u;

        u = this.Count();



        if (!u.HasValue)
        {
            return false;
        }





        ulong count;

        count = u.Value;



        ulong i;


        i = 0;


        while (i < count)
        {
            bool b;


            b = this.ExecuteExport();


            if (!b)
            {
                return false;
            }




            i = i + 1;
        }



        return true;
    }






    private bool ExecuteExport()
    {
        ClassIndex a;


        a = this.ExecuteClassIndex();



        if (this.Null(a))
        {
            return false;
        }





        ClassImport u;


        u = (ClassImport)this.ClassImportMap.Get(a);




        if (!this.Null(u))
        {
            int k;


            k = this.SInt32(a.Value);
            



            CheckClass varClass;


            varClass = new CheckClass();


            varClass.Init();


            varClass.Name = u.Class;


            varClass.Index = k;




            Pair pair;

            pair = new Pair();

            pair.Init();

            pair.Key = u.Name;

            pair.Value = varClass;




            this.ClassMap.Add(pair);
        }





        return true;
    }







    private bool ExecutePassModuleName()
    {
        bool b;


        b = this.PassNameValue();



        if (!b)
        {
            return false;
        }




        return true;
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







    private ClassIndex ExecuteClassIndex()
    {
        ulong? u;

        u = this.ExecuteInt();


        if (!u.HasValue)
        {
            return null;
        }



        ulong value;


        value = u.Value;



        ClassIndex ret;

        ret = new ClassIndex();

        ret.Init();

        ret.Value = value;

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






    private bool PassNameValue()
    {
        bool b;

        b = this.ExecutePassString();


        return b;
    }





    

    private bool CheckByteAvailable(ulong count)
    {
        ulong a;


        a = this.ULong(this.Data.Value.Length);



        return this.Index + count <= a;
    }






    private bool ExecutePassString()
    {
        ulong? u;


        u = this.ExecuteInt();



        if (!u.HasValue)
        {
            return false;
        }




        ulong count;

        count = u.Value;




        if (!this.CheckByteAvailable(count))
        {
            return false;
        }




        this.Index = this.Index + count;




        return true;
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




    private bool ExecutePassModuleIntent()
    {
        return this.ExecutePassInt();
    }





    private bool ExecutePassModuleVer()
    {
        return this.ExecutePassInt();
    }




    private bool ExecutePassClassIndex()
    {
        return this.ExecutePassInt();
    }





    private bool ExecutePassInt()
    {
        ulong count;


        count = Constant.This.IntByteCount;



        if (!this.CheckByteAvailable(count))
        {
            return false;
        }




        this.Index = this.Index + count;




        return true;
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