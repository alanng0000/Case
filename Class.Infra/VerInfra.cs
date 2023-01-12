namespace Class.Infra;




public class VerInfra : Object
{
    public ModuleVer GetCurrentVer(ModuleIntent intent)
    {
        string u;
        
        u = this.ModulePath(intent);




        string s;


        s = File.ReadAllText(u);




        ulong? uu;

        uu = this.StringVerValue(s);


        if (!uu.HasValue)
        {
            return null;
        }
      



        ulong value;

        value = uu.Value;





        ModuleVer a;

        a = new ModuleVer();

        a.Init();

        a.Value = value;



        ModuleVer ret;

        ret = a;

        return ret;
    }




    private ulong? StringVerValue(string s)
    {
        ulong o;



        bool b;

        b = ulong.TryParse(s, out o);
        


        if (!b)
        {
            return null;
        }



        ulong ret;

        ret = o;

        return ret;
    }





    private string ModulePath(ModuleIntent intent)
    {
        Convert convert;

        convert = Convert.This;




        ulong o;

        o = intent.Value;




        string u;

        u = convert.Int60BitListString(o);




        

        ModuleRoot moduleRoot;


        moduleRoot = ModuleRoot.This;





        string s;


        s = Path.Combine(moduleRoot.Path, u);


        s = Path.Combine(s, this.VerFileName);




        string ret;

        ret = s;


        return ret;
    }




    private string VerFileName
    {
        get
        {
            return "_";
        }
    }
}