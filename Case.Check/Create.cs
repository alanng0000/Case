namespace Case.Check;






public class Create : InfraCreate
{
    public SourceArray SourceList { get; set; }




    public NodeResult NodeResult { get; set; }




    public Refer PortRefer { get; set; }



    
    public ConstantClass PortConstantClass { get; set; }




    public ModuleRefer PortConstantRefer { get; set; }





    internal CheckMap Check { get; set; }




    internal Refer Refer { get; set; }





    public Result Result { get; set; }





    internal Infra Infra { get; set; }





    internal ConstantClass ConstantClass { get; set; }





    private ulong ClassNewId { get; set; }





    private ErrorKindList ErrorKind { get; set; }




    private AccessList Access { get; set; }





    private Map BaseMap { get; set; }







    public override bool Init()
    {
        base.Init();




        this.ErrorKind = ErrorKindList.This;




        this.Access = AccessList.This;




        this.Infra = new Infra();


        this.Infra.Init();





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








        this.InitConstantClass();





        this.InitRefer();








        this.ErrorList = new ErrorList();





        this.ErrorList.Init();






        this.Result.Check = this.Check;




        this.Result.Refer = this.Refer;




        this.Result.Error = this.ErrorList;






        

        this.ClassNewId = 0;






        Traverse traverse;




        traverse = this.InitTraverse();




        this.Traverse(traverse);







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





        traverse.Create = this;





        traverse.Init();





        return traverse;
    }







    private bool InitConstantClass()
    {
        this.ConstantClass.Object = this.CreateConstantClass(this.PortConstantClass.Object);





        this.ConstantClass.Bool = this.CreateConstantClass(this.PortConstantClass.Bool);




        this.ConstantClass.Int = this.CreateConstantClass(this.PortConstantClass.Int);




        this.ConstantClass.String = this.CreateConstantClass(this.PortConstantClass.String);




        return true;
    }







    private Class CreateConstantClass(Class varClass)
    {
        this.Infra.Module = null;





        Class constantClass;


        constantClass = this.Infra.CreateClass(varClass);






        Class ret;

        ret = constantClass;


        return ret;
    }





    private bool InitRefer()
    {
        this.Infra.ConstantClass = this.ConstantClass;



        this.Infra.PortConstantClass = this.PortConstantClass;



        this.Infra.PortConstantRefer = this.PortConstantRefer;
        




        this.Refer = this.Infra.CreateRefer(this.PortRefer);




        ClassMap varClass;




        varClass = new ClassMap();

        varClass.Init();



        this.Refer.Class = varClass;





        varClass = new ClassMap();

        varClass.Init();



        this.Refer.Module.Class = varClass;






        this.InitReferImport();






        return true;
    }







    private bool InitReferImport()
    {
        MapIter moduleIter;

        moduleIter = this.Refer.Import.Iter();


        while (moduleIter.Next())
        {
            Module module;

            module = (Module)moduleIter.Valu;




            MapIter classIter;

            classIter = module.Class.Iter();


            while (classIter.Next())
            {
                string name;

                name = (string)classIter.Key;



                Class varClass;

                varClass = (Class)classIter.Valu;



                varClass.Id = this.NewClassId();




                Pair pair;

                pair = new Pair();

                pair.Init();

                pair.Key = name;

                pair.Valu = varClass;



                this.Refer.Class.Add(pair);
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




        int ret;


        ret = index;


        return ret;
    }







    private bool ExecuteClass()
    {
        Traverse traverse;




        traverse = this.ClassTraverse();




        this.Traverse(traverse);






        this.ExecuteClassBase();
        





        return true;
    }








    protected virtual bool ExecuteClassBase()
    {
        this.SetBaseMap();




        
        this.AddBase();





        return true;
    }





    protected virtual Traverse ClassTraverse()
    {
        ClassTraverse traverse;



        traverse = new ClassTraverse();



        traverse.Create = this;



        traverse.Init();



        return traverse;
    }







    private bool SetBaseMap()
    {
        ClassCompare compare;


        compare = new ClassCompare();


        compare.Init();




        this.BaseMap = new Map();



        this.BaseMap.Compare = compare;



        this.BaseMap.Init();






        MapIter iter;



        iter = this.Refer.Module.Class.Iter();




        while (iter.Next())
        {
            Class varClass;



            varClass = (Class)iter.Valu;






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
        ConstantClass o;

        o = this.ConstantClass;




        bool b;


        b = false;



        if (varClass == o.Object)
        {
            b = true;
        }


        if (varClass == o.Bool)
        {
            b = true;
        }


        if (varClass == o.Int)
        {
            b = true;
        }


        if (varClass == o.String)
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


        basePair.Valu = varClass.Base;




        this.BaseMap.Add(basePair);



        return true;
    }







    private bool BaseMapAdd(Class varClass)
    {
        NodeClas nodeClass;



        nodeClass = varClass.Node;





        CaseName nodeBase;



        nodeBase = nodeClass.Base;






        string baseName;


        

        baseName = nodeBase.Valu;
        




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
            t = this.ConstantClass.Object;
        }
        




        Pair basePair;


        basePair = new Pair();


        basePair.Init();


        basePair.Key = varClass;


        basePair.Valu = t;




        this.BaseMap.Add(basePair);



        return true;
    }






    protected virtual bool CheckBase(Class varClass)
    {
        return true;
    }







    private bool AddBase()
    {
        MapIter iter;



        iter = this.BaseMap.Iter();




        while (iter.Next())
        {
            Class varClass;


            varClass = (Class)iter.Key;




            bool b;


            b = this.CheckClassDependency(varClass);



            if (!b)
            {
                this.Error(this.ErrorKind.BaseUndefined, varClass.Node, varClass.Source);
            }




            Class t;



            t = this.ConstantClass.Object;




            if (b)
            {
                t = (Class)iter.Valu;
            }




            varClass.Base = t;
        }




        return true;
    }






    private bool CheckClassDependency(Class varClass)
    {
        ClassCompare compare;

        compare = new ClassCompare();

        compare.Init();





        Map map;



        map = new Map();



        map.Compare = compare;



        map.Init();






        Pair t;



        t = new Pair();


        t.Init();


        t.Key = varClass;



        t.Valu = null;





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



            pair.Valu = null;





            map.Add(pair);





            currentClass = (Class)this.BaseMap.Get(currentClass);
        }




        return true;
    }





    private bool ThisModule(Class varClass)
    {
        return (varClass.Module == this.Refer.Module);
    }





    private bool SystemObject(Class varClass)
    {
        return (varClass == this.ConstantClass.Object);
    }






    private bool Null(object o)
    {
        ObjectInfra infra;

        infra = ObjectInfra.This;


        return infra.Null(o);
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




        traverse.Create = this;




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



        traverse.Create = this;



        traverse.Init();



        return traverse;
    }








    private bool Traverse(Traverse traverse)
    {
        ArrayIter treeIter;


        treeIter = this.NodeResult.Tree.Iter();




        ArrayIter sourceIter;


        sourceIter = this.SourceList.Iter();




        
        while (treeIter.Next() & sourceIter.Next())
        {
            Tree tree;


            tree = (Tree)treeIter.Valu;




            Source source;


            source = (Source)sourceIter.Valu;




            
            this.TreeTraverse(traverse, tree, source);
        }




        return true;
    }





    private bool TreeTraverse(Traverse traverse, Tree tree, Source source)
    {
        NodeNode node;


        node = tree.Root;




        if (this.Null(node))
        {
            return true;
        }




        NodeClas nodeClass;



        nodeClass = (NodeClas)node;



        traverse.Source = source;



        traverse.ExecuteClass(nodeClass);




        return true;
    }
}