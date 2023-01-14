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





    public Module Module { get; set; }





    public Refer CreateRefer(Refer refer)
    {
        Refer a;

        a = new Refer();

        a.Init();



        Module module;

        module = this.CreateModule(refer.Module);



        a.Module = module;




        ModuleMap import;

        import = this.CreateModuleMap(refer.Import);



        a.Import = import;




        Refer ret;

        ret = a;


        return ret;
    }





    private ModuleMap CreateModuleMap(ModuleMap moduleMap)
    {
        ModuleMap a;

        a = new ModuleMap();

        a.Init();



        MapIter iter;

        iter = moduleMap.Iter();

        while (iter.Next())
        {
            Pair pair;

            pair = (Pair)iter.Value;




            Module module;

            module = (Module)pair.Value;




            Module u;

            u = this.CreateModule(module);



            Pair h;

            h = new Pair();

            h.Init();

            h.Key = u.Refer;

            h.Value = u;



            a.Add(h);
        }




        ModuleMap ret;

        ret = a;


        return ret;
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




        if (this.Null(a.Refer.Ver))
        {
            ModuleVer ver;


            ver = this.VerInfra.GetCurrentVer(a.Refer.Intent);



            a.Refer.Ver = ver;
        }





        ClassMap varClass;


        varClass = null;




        if (!this.Null(module.Class))
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




            string name;

            name = (string)pair.Key;



            Class varClass;

            varClass = (Class)pair.Value;




            string o;

            o = name;



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





    public Class CreateClass(Class varClass)
    {
        Class a;


        a = new Class();


        a.Init();


        a.Name = varClass.Name;


        a.Module = this.Module;


        a.Index = varClass.Index;



        Class ret;

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








    public bool VarMapAdd(VarMap map, Var varVar)
    {
        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = varVar.Name;


        pair.Value = varVar;




        map.Add(pair);



        return true;
    }





    public bool VarMapMapAdd(VarMap map, VarMap other)
    {
        MapIter iter;


        iter = other.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            Var varVar;


            varVar = (Var)pair.Value;




            this.VarMapAdd(map, varVar);
        }



        return true;
    }






    private bool Null(object o)
    {
        ObjectInfra infra;


        infra = ObjectInfra.This;



        return infra.Null(o);
    }
}