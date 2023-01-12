namespace Class.Check;



class Infra : Object
{
    public Compile Compile { get; set; }



    public Refer CreateRefer()
    {
        return null;
    }



    private Module CreateReferModule(Module module)
    {
        Module m;

        m = new Module();

        m.Init();

        

        ModuleName name;

        name = this.CreateReferModuleName(module.Name);


        m.Name = name;



        




        return null;
    }



    private ModuleName CreateReferModuleName(ModuleName name)
    {
        ModuleName a;

        a = new ModuleName();

        a.Init();

        a.Value = name.Value;


        return a;
    }
}