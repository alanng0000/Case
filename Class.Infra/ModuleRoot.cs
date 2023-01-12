namespace Class.Infra;




public class ModuleRoot : Object
{
    public override bool Init()
    {
        string s;


        s = File.ReadAllText(this.PathFileName);



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