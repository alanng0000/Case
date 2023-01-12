namespace Class.Infra;




public class Constant : Object
{
    public static Constant This { get; } = CreateGlobal();




    private static Constant CreateGlobal()
    {
        Constant global;


        global = new Constant();



        global.Init();



        return global;
    }







    public override bool Init()
    {
        base.Init();




        this.Quote = '\"';



        this.BackSlash = '\\';



        this.Space = ' ';



        this.Tab = '\t';



        this.NewLine = '\n';



        this.Hash = '#';





        this.IntByteCount = sizeof(ulong);



        this.ByteBitCount = 8;





        return true;
    }


    

    public char Quote
    {
        get;
        private set;
    }




    public char BackSlash
    {
        get;
        private set;
    }




    public char Space
    {
        get;
        private set;
    }




    public char Tab
    {
        get;
        private set;
    }




    public char NewLine
    {
        get;
        private set;
    }





    public char Hash
    {
        get;
        private set;
    }





    public ulong IntByteCount
    {
        get;
        private set;
    }



    public ulong ByteBitCount
    {
        get;
        private set;
    }
}