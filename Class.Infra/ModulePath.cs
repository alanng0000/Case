namespace Class.Infra;




public class ModulePath : Object
{
    public static ModulePath This { get; } = CreateGlobal();




    private static ModulePath CreateGlobal()
    {
        ModulePath global;


        global = new ModulePath();


        global.Init();



        return global;
    }


    




    public override bool Init()
    {
        EnvironmentSpecialFolder fold;

        fold = EnvironmentSpecialFolder.UserProfile;



        string s;
        

        s = Environment.GetFolderPath(fold);



        s = Path.Combine(s, "Module");



        this.RootData = s;



        return true;
    }











    public string Module(ulong intent, ulong ver)
    {
        Convert convert;


        convert = Convert.This;





        string u;

        u = convert.Int60BitListString(intent);




        string v;

        v = convert.Int60BitListString(ver);





        string s;


        s = Path.Combine(this.Root, u, v);




        string ret;

        ret = s;


        return ret;
    }






    public string ModuleDataName
    {
        get
        {
            return "_";
        }
        set
        {
        }
    }





    public string Root
    {
        get
        {
            return this.RootData;
        }
    }




    private string RootData { get; set; }
}