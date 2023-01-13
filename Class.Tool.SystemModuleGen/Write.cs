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




        this.ExecuteModule();






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




        this.ExecuteModule();




        return true;
    }






    private bool ExecuteModule()
    {






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







    private Stream Stream { get; set; }






    private bool InitStream()
    {
        this.Stream = new FileStream(this.Path, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None);



        return true;
    }
}