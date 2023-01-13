namespace Class.Tool.SystemModuleGen;




class Write : Object
{
    public string Path { get; set; }



    public Module Module { get; set; }





    public bool Execute()
    {



        return true;
    }




    private bool ExecuteModule()
    {
        this.Int(0);




        this.HeadSize();




        return true;
    }




    private bool HeadSize()
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
        this.Index = this.Index + 1;


        return true;
    }





    public ulong Index { get; set; }





    public Data Data { get; set; }





    private Stream Stream { get; set; }






    private bool InitStream()
    {
        this.Stream = new FileStream(this.Path, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None);



        return true;
    }
}