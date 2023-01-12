namespace Class.Check;



class Infra : Object
{
    public override bool Init()
    {
        base.Init();



        this.VerInfra = new VerInfra();


        this.VerInfra.Init();



        return true;
    }





    private VerInfra VerInfra { get; set; }





    private Module Module { get; set; }




    public Refer CreateRefer(Refer refer)
    {
        return null;
    }





    private Module CreateModule(Module module)
    {
        Module a;

        a = new Module();

        a.Init();

        

        ModuleName name;

        name = this.CreateModuleName(module.Name);


        a.Name = name;



        ModuleRefer refer;

        refer = this.CreateModuleRefer(module.Refer);


        a.Refer = refer;





        ClassMap varClass;


        varClass = null;




        if (this.Null(module.Class))
        {
            this.Module = a;


            varClass = this.CreateClassMap(module.Class);



            this.Module = null;
        }
        




        a.Class = varClass;



        Module ret;

        ret = a;


        return ret;
    }







    private ClassMap CreateClassMap(ClassMap classMap)
    {
        ClassMap a;

        a = new ClassMap();

        a.Init();



        MapIter iter;

        iter = classMap.Iter();


        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            ClassName name;

            name = (ClassName)pair.Key;



            Class varClass;

            varClass = (Class)pair.Value;




            ClassName o;

            o = this.CreateClassName(name);



            Class u;

            u = this.CreateClass(varClass);




            Pair h;

            h = new Pair();

            h.Init();

            h.Key = o;

            h.Value = u;



            a.Add(h);
        }





        ClassMap ret;

        ret = a;


        return ret;
    }





    private Class CreateClass(Class varClass)
    {
        Class a;


        a = new Class();


        a.Init();


        a.Name = this.CreateClassName(varClass.Name);


        a.Module = this.Module;


        a.Index = varClass.Index;



        Class ret;

        ret = a;

        return ret;
    }







    private ClassName CreateClassName(ClassName name)
    {
        ClassName a;

        a = new ClassName();

        a.Init();

        a.Value = name.Value;



        ClassName ret;

        ret = a;

        return ret;
    }





    private ModuleRefer CreateModuleRefer(ModuleRefer refer)
    {
        ModuleRefer a;

        a = new ModuleRefer();

        a.Init();




        ModuleIntent intent;


        intent = this.CreateModuleIntent(refer.Intent);



        a.Intent = intent;





        ModuleVer ver;


        ver = null;




        bool b;


        b = this.Null(refer.Ver);


        if (b)
        {
            ver = this.VerInfra.GetCurrentVer(a.Intent);
        }



        if (!b)
        {
            ver = this.CreateModuleVer(refer.Ver);
        }


        
        a.Ver = ver;





        ModuleRefer ret;

        ret = a;

        return ret;
    }





    private ModuleVer CreateModuleVer(ModuleVer ver)
    {
        ModuleVer a;

        a = new ModuleVer();

        a.Init();

        a.Value = ver.Value;



        ModuleVer ret;

        ret = a;

        return ret;
    }





    private ModuleIntent CreateModuleIntent(ModuleIntent intent)
    {
        ModuleIntent a;

        a = new ModuleIntent();

        a.Init();

        a.Value = intent.Value;


        return a;
    }



    private ModuleName CreateModuleName(ModuleName name)
    {
        ModuleName a;

        a = new ModuleName();

        a.Init();

        a.Value = name.Value;


        return a;
    }




    private bool Null(object o)
    {
        return ObjectInfra.This.Null(o);
    }
}