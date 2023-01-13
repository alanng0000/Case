namespace Class.Tool.SystemModuleGen;




class Write : Object
{
    public string Path { get; set; }



    public Module Module { get; set; }




    
    public Data Data { get; set; }




    public bool Execute()
    {
        this.Index = 0;



        CountByteOp countOp;

        countOp = new CountByteOp();

        countOp.Write = this;

        countOp.Init();



        this.ByteOp = countOp;




        this.ExecuteModule(this.Module);






        ulong headSize;

        headSize = this.Index;




        Constant constant;

        constant = Constant.This;




        ulong totalSize;

        totalSize = headSize + constant.IntByteCount;
        



        byte[] uu;

        uu = new byte[totalSize];



        this.Data = new Data();

        this.Data.Init();

        this.Data.Value = uu;




        this.Index = 0;




        WriteByteOp writeOp;

        writeOp = new WriteByteOp();

        writeOp.Write = this;

        writeOp.Init();



        this.ByteOp = writeOp;





        this.Int(headSize);




        this.ExecuteModule(this.Module);




        return true;
    }






    private bool ExecuteModule(Module module)
    {
        this.ExecuteModuleRefer(module.Refer);



        this.ExecuteModuleName(module.Name);



        this.ExecuteClassArray(module.Class);



        this.ExecuteImportArray(module.Import);



        this.ExecuteExportArray(module.Export);



        this.ExecuteEntry(module.Entry);



        return true;
    }




    private bool ExecuteModuleRefer(ModuleRefer refer)
    {
        this.ExecuteModuleIntent(refer.Intent);


        this.ExecuteModuleVer(refer.Ver);



        return true;
    }





    private bool ExecuteModuleIntent(ModuleIntent intent)
    {
        this.Int(intent.Value);


        return true;
    }




    private bool ExecuteModuleVer(ModuleVer ver)
    {
        this.Int(ver.Value);


        return true;
    }




    private bool ExecuteModuleName(ModuleName name)
    {
        this.String(name.Value);


        return true;
    }




    private bool ExecuteClassArray(Array varClass)
    {
        Convert convert;


        convert = Convert.This;




        ulong k;

        k = convert.ULong(varClass.Count);




        ulong count;

        count = k;




        this.Int(count);



        int uu;



        ulong i;

        i = 0;


        while (i < count)
        {
            uu = convert.SInt32(i);



            string s;

            s = (string)varClass.Get(uu);




            this.String(s);




            i = i + 1;
        }



        return true;
    }







    private bool ExecuteImportArray(Array import)
    {
        Convert convert;


        convert = Convert.This;




        ulong k;

        k = convert.ULong(import.Count);




        ulong count;

        count = k;




        this.Int(count);



        int uu;



        ulong i;

        i = 0;


        while (i < count)
        {
            uu = convert.SInt32(i);



            Import a;

            a = (Import)import.Get(uu);




            this.ExecuteImport(a);




            i = i + 1;
        }



        return true;
    }






    private bool ExecuteExportArray(Array export)
    {
        Convert convert;


        convert = Convert.This;




        ulong k;

        k = convert.ULong(export.Count);




        ulong count;

        count = k;




        this.Int(count);



        int uu;



        ulong i;

        i = 0;


        while (i < count)
        {
            uu = convert.SInt32(i);



            Export a;

            a = (Export)export.Get(uu);




            this.ExecuteExport(a);




            i = i + 1;
        }



        return true;
    }








    private bool ExecuteImport(Import import)
    {
        this.ExecuteModuleRefer(import.Refer);


        this.ExecuteClassIndex(import.Index);


        return true;
    }





    private bool ExecuteExport(Export export)
    {
        this.ExecuteClassIndex(export.Index);


        return true;
    }




    private bool ExecuteEntry(ClassIndex entry)
    {
        this.ExecuteClassIndex(entry);


        return true;
    }





    private bool ExecuteClassIndex(ClassIndex index)
    {
        this.Int(index.Value);


        return true;
    }





    private bool String(string o)
    {
        Convert convert;

        convert = Convert.This;




        ulong k;

        k = convert.ULong(o.Length);




        ulong count;

        count = k;




        this.Int(count);




        char oc;



        byte ob;




        int uu;



        ulong i;

        i = 0;

        while (i < count)
        {
            uu = convert.SInt32(i);


            oc = o[uu];


            ob = convert.CharByte(oc);



            this.Byte(ob);




            i = i + 1;
        }



        return true;
    }





    private bool Int(ulong o)
    {
        Constant constant;

        constant = Constant.This;



        Convert convert;

        convert = Convert.This;




        ulong uu;

        uu = constant.ByteBitCount;



        ulong shiftCount;



        int ou;




        byte ob;



        ulong k;
        


        ulong count;

        count = constant.IntByteCount;



        ulong i;

        i = 0;


        while (i < count)
        {
            shiftCount = i * uu;


            ou = convert.SInt32(shiftCount);


            k = o >> ou;



            ob = convert.Byte(k);




            this.Byte(ob);
            



            i = i + 1;
        }



        return true;
    }







    private bool Byte(byte ob)
    {
        this.ByteOp.Execute(ob);




        return true;
    }







    public ulong Index { get; set; }








    private ByteOp ByteOp { get; set; }
}