namespace Class;




class ModuleHeadLoad : Object
{
    private Convert Convert { get; set; }
    



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




    public ModuleRefer Refer { get; set; }





    public Data Result { get; set; }






    public bool Execute()
    {
        this.Result = null;





        string dataPath;

        dataPath = this.DataPath();




        byte[] u;

        u = new byte[Constant.This.IntByteCount];





        FileStream fileStream;


        fileStream = new FileStream(dataPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);




        int f;



        f = fileStream.Read(u, 0, u.Length);



        if (f < u.Length)
        {
            return false;
        }




        ulong size;


        size = this.Convert.ByteListULong(u, 0);




        

        byte[] d;


        d = new byte[size];




        f = fileStream.Read(d, 0, d.Length);

        

        if (f < d.Length)
        {
            return false;
        }
        



        fileStream.Dispose();






        Data data;


        data = new Data();


        data.Init();


        data.Value = d;



        this.Result = data;


        return true;
    }









    private string DataPath()
    {
        ModulePath modulePath;


        modulePath = ModulePath.This;





        ulong oo;

        oo = this.Refer.Intent.Value;




        ulong ou;

        ou = this.Refer.Ver.Value;



        
        string s;


        s = modulePath.Module(oo, ou);




        s = Path.Combine(s, this.DataFileName);




        string ret;

        ret = s;


        return ret;
    }
}