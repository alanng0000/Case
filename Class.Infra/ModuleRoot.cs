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



        this.PathData = s;



        return true;
    }





    public string Path
    {
        get
        {
            return this.PathData;
        }
    }




    private string PathData { get; set; }






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
}