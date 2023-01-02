namespace Class.Check;




public class Load : Object
{
    private Convert Convert { get; set; }




    public override bool Init()
    {
        base.Init();



        
        this.InitRootPath();




        this.Convert = new Convert();


        this.Convert.Init();




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
        this.Result = null;





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




        ulong size;


        size = this.Convert.ByteListULong(u, 0);




        

        byte[] d;


        d = new byte[size];




        f = fileStream.Read(d, 0, d.Length);

        

        if (f < d.Length)
        {
            return true;
        }
        



        fileStream.Dispose();






        Data data;


        data = new Data();


        data.Value = d;



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