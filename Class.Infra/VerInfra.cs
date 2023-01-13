namespace Class.Infra;




public class VerInfra : Object
{
    public ModuleVer GetCurrentVer(ModuleIntent intent)
    {
        string u;
        
        u = this.VerPath(intent);




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

        b = ulong.TryParse(s, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out o);



        if (!b)
        {
            return null;
        }



        ulong ret;

        ret = o;

        return ret;
    }





    private string VerPath(ModuleIntent intent)
    {
        Convert convert;

        convert = Convert.This;




        ulong o;

        o = intent.Value;




        string u;

        u = convert.Int60BitListString(o);




        

        ModulePath modulePath;


        modulePath = ModulePath.This;





        string s;


        s = Path.Combine(modulePath.Root, u);


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