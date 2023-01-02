namespace Class.Check;




public class Load : Object
{
    public override bool Init()
    {
        base.Init();



        
        this.InitRootPath();




        return true;
    }





    private bool InitRootPath()
    {
        string s;


        s = File.ReadAllText(this.PathFileName);



        this.RootPath = s;



        return true;
    }






    private string RootPath { get; set; }




    private string PathFileName
    {
        get
        {
            return "Path.txt";
        }
        set
        {
        }
    }




    private string DataFileName
    {
        get
        {
            return "_";
        }
        set
        {
        }
    }




    public string ModuleName { get; set; }



    public ulong ModuleVer { get; set; }




    public Data Result { get; set; }





    public bool Execute()
    {
        string modulePath;

        modulePath = this.ModulePath();



        byte[] u;

        u = new byte[InfraConstant.This.IntByteCount];





        FileStream fileStream;


        fileStream = new FileStream(modulePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);


        int f;



        f = fileStream.Read(u, 0, u.Length);



        if (f < u.Length)
        {
            return true;
        }






        
        





        Data data;


        data = new Data();


        data.Value = u;



        this.Result = data;


        return true;
    }









    private string ModulePath()
    {
        string u;

        u = this.ModuleVer.ToString();




        string s;


        s = Path.Combine(this.RootPath, this.ModuleName, u);


        s = Path.Combine(s, this.DataFileName);




        string ret;

        ret = s;


        return ret;
    }
}