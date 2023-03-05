namespace Case.Infra;




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





        this.SystemIntent = 0;



        this.SystemVer = 0;



        this.SystemName = "System";





        this.SystemObjectName = "Object";


        this.SystemBoolName = "Bool";


        this.SystemIntName = "Int";


        this.SystemStringName = "String";






        this.Quote = '\"';



        this.BackSlash = '\\';



        this.Space = ' ';



        this.Tab = '\t';



        this.NewLine = '\n';



        this.Hash = '#';





        this.NullClassIndex = 0xffffffffffffffff;





        return true;
    }




    public ulong SystemIntent
    {
        get;
        private set;
    }



    public ulong SystemVer
    {
        get;
        private set;
    }



    public string SystemName
    {
        get;
        private set;
    }




    public string SystemObjectName
    {
        get;
        private set;
    }




    public string SystemBoolName
    {
        get;
        private set;
    }



    public string SystemIntName
    {
        get;
        private set;
    }



    public string SystemStringName
    {
        get;
        private set;
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






    public ulong NullClassIndex
    {
        get;
        private set;
    }
}