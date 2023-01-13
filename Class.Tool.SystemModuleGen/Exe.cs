namespace Class.Tool.SystemModuleGen;




class Exe
{
    static int Main()
    {
        Gen gen;


        gen = new Gen();


        gen.Init();


        int o;

        o = gen.Execute();


        return o;
    }
}