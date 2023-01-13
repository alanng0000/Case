namespace Class.Infra;




public class ModuleRoot : Object
{
    public static ModuleRoot This { get; } = CreateGlobal();




    private static ModuleRoot CreateGlobal()
    {
        ModuleRoot global;


        global = new ModuleRoot();


        global.Init();



        return global;
    }


    




    public override bool Init()
    {
        EnvironmentSpecialFolder fold;

        fold = EnvironmentSpecialFolder.UserProfile;



        string s;
        

        s = Environment.GetFolderPath(fold);



        s = global::System.IO.Path.Combine(s, "Module");



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







    public string Root
    {
        get
        {
            return this.RootData;
        }
    }




    private string RootData { get; set; }
}