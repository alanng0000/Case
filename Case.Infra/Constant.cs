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





        this.SemaIntent = 0;



        this.SemaVer = 0;



        this.SemaName = "Sema";





        this.SemaObjectName = "Object";


        this.SemaBoolName = "Bool";


        this.SemaIntName = "Int";


        this.SemaStringName = "String";






        this.Quote = '\"';



        this.BackSlash = '\\';



        this.Space = ' ';



        this.Tab = '\t';



        this.NewLine = '\n';



        this.Hash = '#';






        return true;
    }




    public ulong SemaIntent
    {
        get;
        private set;
    }



    public ulong SemaVer
    {
        get;
        private set;
    }



    public string SemaName
    {
        get;
        private set;
    }




    public string SemaObjectName
    {
        get;
        private set;
    }




    public string SemaBoolName
    {
        get;
        private set;
    }



    public string SemaIntName
    {
        get;
        private set;
    }



    public string SemaStringName
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
}