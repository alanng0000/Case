namespace Class.Check;




public class ModuleHeadLoad : Object
{
    private Convert Convert { get; set; }



    public string RootPath { get; set; }
    



    public override bool Init()
    {
        base.Init();




        this.Convert = new Convert();


        this.Convert.Init();




        return true;
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




    public ModuleIntent Intent { get; set; }



    public ModuleVer Ver { get; set; }





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

        u = this.Intent.Value.ToString("x15");



        string v;

        v = this.Ver.Value.ToString("x15");




        string s;


        s = Path.Combine(this.RootPath, u, v);


        s = Path.Combine(s, this.DataFileName);




        string ret;

        ret = s;


        return ret;
    }
}