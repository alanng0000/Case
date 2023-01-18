namespace Class;







class ModuleHeadImportRead : Object
{
    public Data Data { get; set; }




    public ulong Index { get; set; }





    public ModuleImport Import { get; set; }





    public CheckModule Module { get; set; }


    




    private Map ClassImportMap { get; set; }









    public bool Execute()
    {
        bool b;


        b = this.ExecuteModule();





        this.ClassImportMap = null;





        if (!b)
        {
            return false;
        }


        



        return true;
    }







    private bool ExecuteModule()
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







        this.ClassImportMap = new ClassImportMap();



        this.ClassImportMap.Init();






        b = this.ExecuteClassList();
        

        if (!b)
        {
            return false;
        }







        b = this.ExecuteImportList();


        if (!b)
        {
            return false;
        }








        b = this.ExecuteExportList();


        if (!b)
        {
            return false;
        }





        
        return true;
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
            string className;


            className = this.ExecuteClassName();



            if (this.Null(className))
            {
                return false;
            }




            string uu;


            uu = (string)this.Import.ClassImport.Get(className);



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

                pair.Key = a.Index;

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




            this.Module.Class.Add(pair);
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








    private string ExecuteClassName()
    {
        string value;


        value = this.NameValue();



        if (this.Null(value))
        {
            return null;
        }




        string ret;

        ret = value;


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
        Constant constant;

        constant = Constant.This;



        Convert convert;

        convert = Convert.This;





        ulong count;


        count = constant.IntByteCount;



        if (!this.CheckByteAvailable(count))
        {
            return null;
        }




        ulong k;


        k = convert.ByteListULong(this.Data.Value, this.Index);




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