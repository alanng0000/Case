namespace Class.Check;






public class Compile : InfraCompile
{
    public SourceArray SourceList { get; set; }




    public NodeResult NodeResult { get; set; }




    public PortPort Port { get; set; }




    public ModuleMap SystemModules { get; set; }




    public CheckMap Check { get; set; }




    public Refer Refer { get; set; }
        
        


    public Module Module { get; set; }




    public Result Result { get; set; }





    public SystemModule SystemModule { get; set; }





    private Class ObjectClass { get; set; }





    private ulong ClassNewId { get; set; }






    public ErrorKindList ErrorKind { get; set; }




    public AccessList Access { get; set; }





    private Load Load { get; set; }





    private bool IsSystem { get; set; }






    private ModuleDataMap ModuleHead { get; set; }






    public override bool Init()
    {
        base.Init();




        this.ErrorKind = this.CreateErrorKind();




        this.Access = this.CreateAccess();





        this.Load = new Load();


        this.Load.Init();





        this.ModuleHead = new ModuleDataMap();


        this.ModuleHead.Init();





        this.SystemModule = new SystemModule();



        this.SystemModule.Init();






        return true;
    }






    public override bool Execute()
    {
        this.ExecuteInit();



        this.ExecuteClass();



        this.ExecuteMember();



        this.ExecuteState();




        return true;
    }






    private bool ExecuteInit()
    {
        this.Result = new Result();


        this.Result.Init();







        this.Check = new CheckMap();





        this.Check.Init();






        this.Refer = new Refer();



        this.Refer.Init();





        this.ErrorList = new ErrorList();





        this.ErrorList.Init();






        this.Result.Check = this.Check;




        this.Result.Refer = this.Refer;




        this.Result.Error = this.ErrorList;







        Traverse traverse;




        traverse = this.InitTraverse();




        this.Traverse(traverse);







        this.Module = new Module();



        this.Module.Init();



        this.Module.Class = new ClassMap();



        this.Module.Class.Init();







        this.InitRefer();





        return true;
    }





    protected virtual ErrorKindList CreateErrorKind()
    {
        return ErrorKindList.This;
    }




    protected virtual AccessList CreateAccess()
    {
        return AccessList.This;
    }





    public virtual Check CreateCheck()
    {
        Check check;



        check = new Check();



        check.Init();




        Check ret;

        ret = check;


        return ret;
    }





    protected virtual Traverse InitTraverse()
    {
        InitTraverse traverse;




        traverse = new InitTraverse();





        traverse.Compile = this;





        traverse.Init();





        return traverse;
    }







    private bool InitRefer()
    {
        this.Refer.Module = new ModuleMap();



        this.Refer.Module.Init();









        this.Refer.Class = new ClassMap();



        this.Refer.Class.Init();






        this.ClassNewId = 0;






        this.InitReferImport();








        Pair t;


        t = new Pair();


        t.Init();


        t.Key = this.Module.Intent;


        t.Value = this.Module;



        this.Refer.Module.Add(t);





        this.IsSystem = (this.Module.Intent.Name.Value == 0);





        if (this.Null(this.SystemModules))
        {
            if (this.IsSystem)
            {
                Class varClass;



                varClass = this.CreateObjectClass();



                varClass.Module = this.Module;



                varClass.Index = this.Module.Class.Count;






                this.AddSystemClass(varClass);






                this.ObjectClass = varClass;







                this.ConstantClass(this.SystemModule.Bool);



                this.AddSystemClass(this.SystemModule.Bool);





                this.ConstantClass(this.SystemModule.Int);



                this.AddSystemClass(this.SystemModule.Int);





                this.ConstantClass(this.SystemModule.String);


                
                this.AddSystemClass(this.SystemModule.String);
            }
        }




        return true;
    }







    private bool ConstantClass(Class varClass)
    {
        varClass.Base = this.ObjectClass;



        varClass.Field = new FieldMap();



        varClass.Field.Init();



        varClass.Method = new MethodMap();



        varClass.Method.Init();



        varClass.Node = null;

        

        varClass.Source = null;



        varClass.Id = this.NewClassId();






        varClass.Module = this.Module;



        varClass.Index = this.Module.Class.Count;







        return true;
    }








    private bool AddSystemClass(Class varClass)
    {
        Pair m;


        m = new Pair();


        m.Init();


        m.Key = varClass.Name;


        m.Value = varClass;



        this.Refer.Class.Add(m);






        Pair tt;


        tt = new Pair();


        tt.Init();


        tt.Key = varClass.Name;


        tt.Value = varClass;



        this.Module.Class.Add(tt);




        return true;
    }







    protected virtual Class CreateObjectClass()
    {
        Class varClass;



        varClass = new Class();



        varClass.Name = "Object";



        varClass.Base = null;



        varClass.Field = new FieldMap();



        varClass.Field.Init();



        varClass.Method = new MethodMap();



        varClass.Method.Init();



        varClass.Node = null;

        

        varClass.Source = null;



        varClass.Id = this.NewClassId();





        Class ret;


        ret = varClass;


        return ret;
    }





    protected virtual Method CreateMethod(Class varClass, string name, Access access)
    {
        Method method;


        method = new Method();


        method.Init();


        method.Class = varClass;


        method.Name = name;


        method.Access = access;








        VarMap varParams;


        varParams = new VarMap();


        varParams.Init();




        method.Params = varParams;







        VarMap call;


        call = new VarMap();


        call.Init();



        method.Call = call;
        




        Method ret;


        ret = method;


        return ret;
    }






    private bool LoadModuleHead(ModuleIntent intent)
    {
        if (!this.Null(this.ModuleHead.Get(intent)))
        {
            return true;
        }
        



        this.Load.Intent = intent;



        this.Load.Execute();





        Data data;


        data = this.Load.Result;





        Pair pair;

        pair = new Pair();

        pair.Init();

        pair.Key = intent;

        pair.Value = data;



        this.ModuleHead.Add(pair);



        return true;
    }






    private bool ImportModule(string name, ulong ver)
    {   
        Module module;


        module = new Module();

        module.Init();



        module.Class = new ClassMap();

        module.Class.Init();




        Pair pair;

        pair = new Pair();

        pair.Init();

        pair.Key = name;

        pair.Value = module;




        this.Refer.Module.Add(pair);
        


        return true;
    }







    private bool InitReferImport()
    {
        if (!this.Null(this.SystemModules))
        {
            MapIter iter;



            iter = this.SystemModules.Iter();




            while (iter.Next())
            {
                Pair pair;




                pair = (Pair)iter.Value;




                Module module;




                module = (Module)pair.Value;






                this.Refer.Module.Add(pair);





                MapIter classIter;


                classIter = module.Class.Iter();


                while (classIter.Next())
                {
                    Pair classPair;


                    classPair = (Pair)classIter.Value;




                    Class varClass;



                    varClass = (Class)classPair.Value;



                    varClass.Id = this.NewClassId();




                    this.Refer.Class.Add(classPair);
                }
            }
        }



        return true;
    }






    public ulong NewClassId()
    {
        ulong t;


        t = this.ClassNewId;



        this.ClassNewId = this.ClassNewId + 1;




        ulong ret;


        ret = t;


        return ret;
    }





    internal int ClassIndex(Source source)
    {
        int index;


        index = source.Index;



        if (this.IsSystem)
        {
            index = index + 1;
        }




        int ret;


        ret = index;


        return ret;
    }







    private bool ExecuteClass()
    {
        Traverse traverse;




        traverse = this.ClassTraverse();




        this.Traverse(traverse);






        this.SetSystemModule();





        this.SetObjectClassMembers();






        this.ExecuteClassBase();
        





        return true;
    }





    protected virtual bool SetObjectClassMembers()
    {
        this.AddObjectClassMethod("Init");




        return true;
    }





    protected bool AddObjectClassMethod(string name)
    {
        Method method;


        method = this.CreateMethod(this.SystemModule.Bool, name, this.Access.Public);


        method.Parent = this.ObjectClass;


        method.Index = this.ObjectClass.Method.Count;





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = method.Name;


        pair.Value = method;





        this.ObjectClass.Method.Add(pair);




        return true;
    }






    protected virtual bool ExecuteClassBase()
    {
        this.SetBaseMap();




        
        this.AddBases();





        return true;
    }





    protected virtual Traverse ClassTraverse()
    {
        ClassTraverse traverse;



        traverse = new ClassTraverse();



        traverse.Compile = this;



        traverse.Init();



        return traverse;
    }








    private Map BaseMap { get; set; }





    private bool SetBaseMap()
    {
        ClassCompare compare;


        compare = new ClassCompare();


        compare.Init();




        this.BaseMap = new Map();



        this.BaseMap.Compare = compare;



        this.BaseMap.Init();






        MapIter iter;



        iter = this.Module.Class.Iter();




        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            Class varClass;



            varClass = (Class)pair.Value;






            bool b;


            b = this.IsConstantClass(varClass);
            


            if (b)
            {
                this.ConstantBaseMapAdd(varClass);
            }




            if (!b)
            {
                bool ba;


                ba = this.SystemObject(varClass);



                if (!ba)
                {
                    this.BaseMapAdd(varClass);
                }
            }
        }




        return true;
    }







    private bool IsConstantClass(Class varClass)
    {
        bool b;


        b = false;



        if (varClass == this.SystemModule.Bool)
        {
            b = true;
        }


        if (varClass == this.SystemModule.Int)
        {
            b = true;
        }


        if (varClass == this.SystemModule.String)
        {
            b = true;
        }



        bool ret;

        ret = b;


        return ret;
    }







    private bool ConstantBaseMapAdd(Class varClass)
    {
        Pair basePair;


        basePair = new Pair();


        basePair.Init();


        basePair.Key = varClass;


        basePair.Value = varClass.Base;




        this.BaseMap.Add(basePair);



        return true;
    }







    private bool BaseMapAdd(Class varClass)
    {
        NodeClass nodeClass;



        nodeClass = varClass.Node;





        ClassName nodeBase;



        nodeBase = nodeClass.Base;






        string baseName;


        

        baseName = nodeBase.Value;
        




        Class varBase;


        

        varBase = this.Class(baseName);
        




        bool b;


        b = false;




        if (this.Null(varBase))
        {
            this.Error(this.ErrorKind.BaseUndefined, nodeClass, varClass.Source);


            b = true;
        }




        if (!this.Null(varBase))
        {
            if (!this.CheckBase(varBase))
            {
                this.Error(this.ErrorKind.BaseUndefined, nodeClass, varClass.Source);


                b = true;
            }
        }
        






        Class t;



        t = varBase;




        if (b)
        {
            t = this.ObjectClass;
        }
        




        Pair basePair;


        basePair = new Pair();


        basePair.Init();


        basePair.Key = varClass;


        basePair.Value = t;




        this.BaseMap.Add(basePair);



        return true;
    }






    protected virtual bool CheckBase(Class varClass)
    {
        return true;
    }







    private bool AddBases()
    {
        MapIter iter;



        iter = this.BaseMap.Iter();




        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;





            Class varClass;


            varClass = (Class)pair.Key;




            bool b;


            b = this.CheckClassDependency(varClass);



            if (!b)
            {
                this.Error(this.ErrorKind.BaseUndefined, varClass.Node, varClass.Source);
            }




            Class t;



            t = this.ObjectClass;




            if (b)
            {
                t = (Class)pair.Value;
            }




            varClass.Base = t;
        }




        return true;
    }






    private bool CheckClassDependency(Class varClass)
    {
        Map map;




        map = new Map();




        map.Compare = new ClassCompare();




        map.Init();






        Pair t;



        t = new Pair();


        t.Init();


        t.Key = varClass;



        t.Value = null;





        map.Add(t);






        Class currentClass;




        currentClass = (Class)this.BaseMap.Get(varClass);





        while (this.ThisModule(currentClass))
        {
            if (this.SystemObject(currentClass))
            {
                return true;
            }






            if (map.Contain(currentClass))
            {
                return false;
            }






            Pair pair;



            pair = new Pair();



            pair.Init();



            pair.Key = currentClass;



            pair.Value = null;





            map.Add(pair);





            currentClass = (Class)this.BaseMap.Get(currentClass);
        }




        return true;
    }





    private bool ThisModule(Class varClass)
    {
        return (varClass.Module == this.Module);
    }





    private bool SystemObject(Class varClass)
    {
        return (varClass == this.ObjectClass);
    }





    private bool Null(object o)
    {
        return o == null;
    }






    public bool Error(ErrorKind kind, NodeNode node, Source source)
    {
        Error error;




        error = new Error();



        
        error.Init();




        error.Stage = this.Stage;




        error.Kind = kind;




        error.Range = node.Range;




        error.Source = source;




        this.Result.Error.Add(error);




        return true;
    }






    public Class Class(string name)
    {
        Class varClass;


        
        varClass = (Class)this.Refer.Class.Get(name);
        



        Class ret;


        ret = varClass;


        return ret;
    }





    protected virtual bool ExecuteMember()
    {
        Traverse traverse;




        traverse = this.MemberTraverse();




        this.Traverse(traverse);




        return true;
    }





    protected virtual Traverse MemberTraverse()
    {
        MemberTraverse traverse;




        traverse = new MemberTraverse();




        traverse.Compile = this;




        traverse.Init();





        return traverse;
    }







    private bool ExecuteState()
    {
        Traverse traverse;



        traverse = this.StateTraverse();




        this.Traverse(traverse);




        return true;
    }






    protected virtual Traverse StateTraverse()
    {
        StateTraverse traverse;


        traverse = new StateTraverse();



        traverse.Compile = this;



        traverse.Init();



        return traverse;
    }






    private bool SetSystemModule()
    {
        Module m;



        m = (Module)this.Refer.Module.Get("System");





        this.SystemModule.Module = m;




        return true;
    }





    private bool Traverse(Traverse traverse)
    {
        ListIter treeIter;


        treeIter = this.NodeResult.Tree.Iter();




        ArrayIter sourceIter;


        sourceIter = this.SourceList.Iter();




        
        while (treeIter.Next() & sourceIter.Next())
        {
            Tree tree;


            tree = (Tree)treeIter.Value;




            Source source;


            source = (Source)sourceIter.Value;




            
            this.TreeTraverse(traverse, tree, source);
        }




        return true;
    }





    private bool TreeTraverse(Traverse traverse, Tree tree, Source source)
    {
        NodeNode node;


        node = tree.Root;




        if (node == null)
        {
            return true;
        }




        NodeClass nodeClass;



        nodeClass = (NodeClass)node;



        traverse.Source = source;



        traverse.ExecuteClass(nodeClass);




        return true;
    }
}