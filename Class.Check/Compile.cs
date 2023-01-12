namespace Class.Check;






public class Compile : InfraCompile
{
    public SourceArray SourceList { get; set; }




    public NodeResult NodeResult { get; set; }




    public Refer PortRefer { get; set; }




    internal CheckMap Check { get; set; }




    internal Refer Refer { get; set; }




    public Result Result { get; set; }





    internal ConstantClass ConstantClass { get; set; }





    private Class ObjectClass { get; set; }





    private ulong ClassNewId { get; set; }






    private ErrorKindList ErrorKind { get; set; }




    private AccessList Access { get; set; }







    private bool IsSystem { get; set; }








    private bool PortError { get; set; }








    public override bool Init()
    {
        base.Init();




        this.ErrorKind = ErrorKindList.This;




        this.Access = AccessList.This;




        this.ConstantClass = new ConstantClass();



        this.ConstantClass.Init();

        




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







        this.InitRefer();






        this.ErrorList = new ErrorList();





        this.ErrorList.Init();






        this.Result.Check = this.Check;




        this.Result.Refer = this.Refer;




        this.Result.Error = this.ErrorList;






        bool b;

        b = true;



        if (!b)
        {
            this.PortError = true;


            return true;
        }




        

        this.ClassNewId = 0;






        Traverse traverse;




        traverse = this.InitTraverse();




        this.Traverse(traverse);













        this.ReferImport();







        return true;
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
        this.Refer = new Refer();



        this.Refer.Init();




        




        this.Refer.Import = new ModuleMap();



        this.Refer.Import.Init();









        this.Refer.Class = new ClassMap();



        this.Refer.Class.Init();








        return true;
    }







    private bool SetConstantClass(Class varClass)
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
        ClassName u;

        u = new ClassName();

        u.Init();

        u.Value = "Object";




        Class varClass;



        varClass = new Class();



        varClass.Name = u;



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









    private bool ReferImport()
    {
        MapIter iter;



        iter = this.PortRefer.Import.Iter();




        while (iter.Next())
        {
            Pair pair;




            pair = (Pair)iter.Value;




            Module module;




            module = (Module)pair.Value;






            this.Refer.Import.Add(pair);





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










        this.Refer.Module = this.Module;





        this.IsSystem = (this.Module.Refer.Intent.Value == this.SystemModuleIntent);






        if (this.IsSystem)
        {
            Class varClass;



            varClass = this.CreateObjectClass();



            varClass.Module = this.Module;



            varClass.Index = this.Module.Class.Count;






            this.AddSystemClass(varClass);






            this.ObjectClass = varClass;







            this.SetConstantClass(this.ConstantClass.Bool);



            this.AddSystemClass(this.ConstantClass.Bool);





            this.SetConstantClass(this.ConstantClass.Int);



            this.AddSystemClass(this.ConstantClass.Int);





            this.SetConstantClass(this.ConstantClass.String);


            
            this.AddSystemClass(this.ConstantClass.String);
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
        if (this.PortError)
        {
            return true;
        }
        



        Traverse traverse;




        traverse = this.ClassTraverse();




        this.Traverse(traverse);






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


        method = this.CreateMethod(this.ConstantClass.Bool, name, this.Access.Public);


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



        if (varClass == this.ConstantClass.Bool)
        {
            b = true;
        }


        if (varClass == this.ConstantClass.Int)
        {
            b = true;
        }


        if (varClass == this.ConstantClass.String)
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





        NodeClassName nodeBase;



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








    private ulong SystemModuleIntent
    {
        get
        {
            return 0;
        }
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
        if (this.PortError)
        {
            return true;
        }




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
        if (this.PortError)
        {
            return true;
        }




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