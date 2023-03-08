namespace Case.Node;





public class Create : InfraCreate
{
    public SourceArray SourceList { get; set; }




    public TokenResult TokenResult { get; set; }




    public string TaskNode { get; set; }




    public Result Result { get; set; }




    protected Keytoken Keyword { get; set; }




    protected Delimiter Delimiter { get; set; }




    protected ErrorKindList ErrorKind { get; set; }




    private NodeMethodMap NodeMethodList { get; set; }




    private Code Code { get; set; }




    private NodeMethod NodeMethod { get; set; }




    private Toke TokeNull;




    private StringInfra StringInfra { get; set; }






    public override bool Init()
    {
        base.Init();






        this.Keyword = this.CreateKeytoken();




        this.Delimiter = Delimiter.This;





        this.ErrorKind = this.CreateErrorKind();





        this.StringInfra = new StringInfra();


        this.StringInfra.Init();






        this.RangeNull = new Range();


        this.RangeNull.Init();


        this.RangeNull.Start = IntNull;


        this.RangeNull.End = IntNull;





        this.TokeNull = new Toke();


        this.TokeNull.Init();


        this.TokeNull.Range = this.RangeNull;






        this.InitNodeMethodList();





        return true;
    }





    protected virtual Keytoken CreateKeytoken()
    {
        return Keytoken.Instance;
    }




    protected virtual ErrorKindList CreateErrorKind()
    {
        return ErrorKindList.This;
    }





    protected virtual bool InitNodeMethodList()
    {
        this.NodeMethodList = new NodeMethodMap();



        this.NodeMethodList.Init();




        this.AddNodeMethod(nameof(this.Case), this.Case);


        this.AddNodeMethod(nameof(this.MemberList), this.MemberList);


        this.AddNodeMethod(nameof(this.Member), this.Member);


        this.AddNodeMethod(nameof(this.Field), this.Field);


        this.AddNodeMethod(nameof(this.Method), this.Method);


        this.AddNodeMethod(nameof(this.ParamList), this.ParamList);


        this.AddNodeMethod(nameof(this.Param), this.Param);


        this.AddNodeMethod(nameof(this.Var), this.Var);


        this.AddNodeMethod(nameof(this.Access), this.Access);


        this.AddNodeMethod(nameof(this.PublicAccess), this.PublicAccess);


        this.AddNodeMethod(nameof(this.ProperAccess), this.ProperAccess);


        this.AddNodeMethod(nameof(this.ParentAccess), this.ParentAccess);


        this.AddNodeMethod(nameof(this.PrivatAccess), this.PrivatAccess);


        this.AddNodeMethod(nameof(this.StateList), this.StateList);


        this.AddNodeMethod(nameof(this.State), this.State);


        this.AddNodeMethod(nameof(this.ReturnState), this.ReturnState);


        this.AddNodeMethod(nameof(this.IfState), this.IfState);


        this.AddNodeMethod(nameof(this.WhileState), this.WhileState);


        this.AddNodeMethod(nameof(this.DeclareState), this.DeclareState);


        this.AddNodeMethod(nameof(this.AssignState), this.AssignState);


        this.AddNodeMethod(nameof(this.ExpressState), this.ExpressState);


        this.AddNodeMethod(nameof(this.Express), this.Express);


        this.AddNodeMethod(nameof(this.ThisExpress), this.ThisExpress);


        this.AddNodeMethod(nameof(this.BaseExpress), this.BaseExpress);


        this.AddNodeMethod(nameof(this.NewExpress), this.NewExpress);


        this.AddNodeMethod(nameof(this.GlobExpress), this.GlobExpress);


        this.AddNodeMethod(nameof(this.BracketExpress), this.BracketExpress);


        this.AddNodeMethod(nameof(this.AndExpress), this.AndExpress);


        this.AddNodeMethod(nameof(this.OrnExpress), this.OrnExpress);


        this.AddNodeMethod(nameof(this.NotExpress), this.NotExpress);


        this.AddNodeMethod(nameof(this.AddExpress), this.AddExpress);


        this.AddNodeMethod(nameof(this.SubExpress), this.SubExpress);


        this.AddNodeMethod(nameof(this.MulExpress), this.MulExpress);


        this.AddNodeMethod(nameof(this.DivExpress), this.DivExpress);


        this.AddNodeMethod(nameof(this.EqualExpress), this.EqualExpress);


        this.AddNodeMethod(nameof(this.LessExpress), this.LessExpress);


        this.AddNodeMethod(nameof(this.JoinExpress), this.JoinExpress);


        this.AddNodeMethod(nameof(this.GetExpress), this.GetExpress);


        this.AddNodeMethod(nameof(this.CallExpress), this.CallExpress);


        this.AddNodeMethod(nameof(this.CastExpress), this.CastExpress);


        this.AddNodeMethod(nameof(this.VarExpress), this.VarExpress);


        this.AddNodeMethod(nameof(this.ConstantExpress), this.ConstantExpress);


        this.AddNodeMethod(nameof(this.NullExpress), this.NullExpress);


        this.AddNodeMethod(nameof(this.ArgueList), this.ArgueList);


        this.AddNodeMethod(nameof(this.Argue), this.Argue);


        this.AddNodeMethod(nameof(this.Target), this.Target);


        this.AddNodeMethod(nameof(this.VarTarget), this.VarTarget);


        this.AddNodeMethod(nameof(this.SetTarget), this.SetTarget);


        this.AddNodeMethod(nameof(this.Constant), this.Constant);


        this.AddNodeMethod(nameof(this.BoolConstant), this.BoolConstant);


        this.AddNodeMethod(nameof(this.IntConstant), this.IntConstant);


        this.AddNodeMethod(nameof(this.StringConstant), this.StringConstant);


        this.AddNodeMethod(nameof(this.ClassName), this.ClassName);


        this.AddNodeMethod(nameof(this.FieldName), this.FieldName);


        this.AddNodeMethod(nameof(this.MethodName), this.MethodName);


        this.AddNodeMethod(nameof(this.VarName), this.VarName);




        return true;
    }




    protected bool AddNodeMethod(string name, NodeMethod nodeMethod)
    {
        Pair pair;



        pair = new Pair();



        pair.Init();



        pair.Key = name;



        pair.Valu = nodeMethod;




        this.NodeMethodList.Add(pair);




        return true;
    }




    protected bool RemoveNodeMethod(string name)
    {
        this.NodeMethodList.Remove(name);



        return true;
    }





    protected bool SetNodeMethod(string name, NodeMethod nodeMethod)
    {
        this.NodeMethodList.Set(name, nodeMethod);




        return true;
    }







    public override bool Execute()
    {
        this.Result = new Result();



        this.Result.Init();





        TreeArray treeArray;



        treeArray = new TreeArray();



        treeArray.Count = this.TokenResult.Code.Count;



        treeArray.Init();




        this.Result.Tree = treeArray;





        this.ErrorList = new ErrorList();



        this.ErrorList.Init();



        this.Result.Error = this.ErrorList;





        this.NewId = 0;






        NodeMethod nodeMethod;



        nodeMethod = (NodeMethod)this.NodeMethodList.Get(this.TaskNode);




        if (this.Null(nodeMethod))
        {
            return false;
        }




        this.NodeMethod = nodeMethod;






        ArrayIter codeIter;


        codeIter = this.TokenResult.Code.Iter();




        ArrayIter sourceIter;


        sourceIter = this.SourceList.Iter();



        
        while (codeIter.Next() & sourceIter.Next())
        {
            this.Code = (Code)codeIter.Valu;





            this.Source = (Source)sourceIter.Valu;




            Text text;


            text = this.Source.Text;



            this.TextInfra.Text = text;



            this.StringInfra.Text = text;






            Tree tree;


            tree = this.ExecuteTree();




            this.Result.Tree.Set(this.Source.Index, tree);
        }




        return true;
    }




    private Tree ExecuteTree()
    {
        Node root;



        root = this.ExecuteNode();




        Tree tree;


        tree = new Tree();


        tree.Init();


        tree.Root = root;




        Tree ret;


        ret = tree;


        return ret;
    }




    private Node ExecuteNode()
    {
        int rangeEnd;


        rangeEnd = this.Code.Toke.Count;



        Range range;


        range = this.Range(0, rangeEnd);




        Node node;


        node = this.NodeMethod(range);



        if (this.Null(node))
        {
            this.Error(this.ErrorKind.Invalid, range);
        }




        Node ret;

        ret = node;


        return ret;
    }






    protected virtual Case Case(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Toke classToken;
        
        
        classToken = this.Toke(this.Keyword.Case, this.IndexRange(range.Start));




        if (this.NullToke(classToken))
        {
            return null;
        }







        Range nameRange;


        nameRange = this.ClassNameRange(this.Range(classToken.Range.End, range.End));






        if (this.NullRange(nameRange))
        {
            return null;
        }






        if (this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return null;
        }







        Toke colon;


        colon = this.Toke(this.Delimiter.BaseSign, this.IndexRange(nameRange.End));




        if (this.NullToke(colon))
        {
            return null;
        }





        Range baseRange;


        baseRange = this.ClassNameRange(this.Range(colon.Range.End, range.End));





        if (this.NullRange(baseRange))
        {
            return null;
        }






        if (this.Zero(this.Count(this.Range(baseRange.End, range.End))))
        {
            return null;
        }






        Toke leftBrace;


        leftBrace = this.Toke(this.Delimiter.LeftBrace, this.IndexRange(baseRange.End));



        if (this.NullToke(leftBrace))
        {
            return null;
        }





        Toke rightBrace;


        rightBrace = this.TokeMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));



        if (this.NullToke(rightBrace))
        {
            return null;
        }




        if (!this.Zero(this.Count(this.Range(rightBrace.Range.End, range.End))))
        {
            return null;
        }






        CaseName name;



        name = this.ClassName(nameRange);




        if (this.Null(name))
        {
            this.Error(this.ErrorKind.NameInvalid, range);
        }





        CaseName varBase;



        varBase = this.ClassName(baseRange);




        if (this.Null(varBase))
        {
            this.Error(this.ErrorKind.BaseInvalid, range);
        }





        MemberList member;



        member = this.MemberList(this.Range(leftBrace.Range.End, rightBrace.Range.Start));



        if (this.Null(member))
        {
            this.Error(this.ErrorKind.MemberInvalid, range);
        }






        Case ret;


        ret = new Case();


        ret.Init();


        ret.Name = name;


        ret.Base = varBase;


        ret.Member = member;



        this.NodeInfo(ret, range);



        return ret;
    }





    protected virtual MemberList MemberList(Range range)
    {
        List list;
        
        list = this.List(this.Member, this.MemberRange, range, null);




        if (this.Null(list))
        {
            return null;
        }





        MemberList ret;


        ret = new MemberList();


        ret.Init();

        
        ret.Value = list;
        

        this.NodeInfo(ret, range);
        

        return ret;
    }





    protected virtual Member Member(Range range)
    {
        Member ret;

        
        ret = null;




        
        
        if (this.Null(ret))
        {
            ret = this.Field(range);
        }
        




        if (this.Null(ret))
        {
            ret = this.Method(range);
        }






        return ret;
    }







    protected virtual Field Field(Range range)
    {
        Range accessRange;



        accessRange = this.AccessRange(range);






        if (this.NullRange(accessRange))
        {
            return null;
        }







        Range classRange;



        classRange = this.ClassNameRange(this.Range(accessRange.End, range.End));






        if (this.NullRange(classRange))
        {
            return null;
        }






        Range nameRange;



        nameRange = this.FieldNameRange(this.Range(classRange.End, range.End));






        if (this.NullRange(nameRange))
        {
            return null;
        }




            


        if (this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return null;
        }






        Toke getLeftBrace;



        getLeftBrace = this.Toke(this.Delimiter.LeftBrace, this.IndexRange(nameRange.End));




        if (this.NullToke(getLeftBrace))
        {
            return null;
        }





        Toke getRightBrace;



        getRightBrace = this.TokeMatchLeftBrace(this.Range(getLeftBrace.Range.End, range.End));




        if (this.NullToke(getRightBrace))
        {
            return null;
        }








        if (this.Zero(this.Count(this.Range(getRightBrace.Range.End, range.End))))
        {
            return null;
        }






        Toke setLeftBrace;



        setLeftBrace = this.Toke(this.Delimiter.LeftBrace, this.IndexRange(getRightBrace.Range.End));




        if (this.NullToke(setLeftBrace))
        {
            return null;
        }





        Toke setRightBrace;



        setRightBrace = this.TokeMatchLeftBrace(this.Range(setLeftBrace.Range.End, range.End));




        if (this.NullToke(setRightBrace))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(setRightBrace.Range.End, range.End))))
        {
            return null;
        }






        Access access;



        access = this.Access(accessRange);




        if (this.Null(access))
        {
            this.Error(this.ErrorKind.AccessInvalid, range);
        }





        CaseName varClass;



        varClass = this.ClassName(classRange);




        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassInvalid, range);
        }





        FieldName name;



        name = this.FieldName(nameRange);




        if (this.Null(name))
        {
            this.Error(this.ErrorKind.NameInvalid, range);
        }






        StateList varGet;


        varGet = this.StateList(this.Range(getLeftBrace.Range.End, getRightBrace.Range.Start));




        if (this.Null(varGet))
        {
            this.Error(this.ErrorKind.GetInvalid, range);
        }






        StateList varSet;


        varSet = this.StateList(this.Range(setLeftBrace.Range.End, setRightBrace.Range.Start));




        if (this.Null(varSet))
        {
            this.Error(this.ErrorKind.SetInvalid, range);
        }






        Field ret;
        

        ret = new Field();


        ret.Init();
        

        ret.Name = name;
        

        ret.Class = varClass;


        ret.Access = access;


        ret.Get = varGet;


        ret.Set = varSet;


        this.NodeInfo(ret, range);


        return ret;
    }








    protected virtual Method Method(Range range)
    {
        Range accessRange;



        accessRange = this.AccessRange(range);






        if (this.NullRange(accessRange))
        {
            return null;
        }







        Range classRange;



        classRange = this.ClassNameRange(this.Range(accessRange.End, range.End));






        if (this.NullRange(classRange))
        {
            return null;
        }






        Range nameRange;



        nameRange = this.MethodNameRange(this.Range(classRange.End, range.End));






        if (this.NullRange(nameRange))
        {
            return null;
        }




            


        if (this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return null;
        }






        Toke leftBracket;



        leftBracket = this.Toke(this.Delimiter.LeftBracket, this.IndexRange(nameRange.End));




        if (this.NullToke(leftBracket))
        {
            return null;
        }





        Toke rightBracket;



        rightBracket = this.TokeMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));




        if (this.NullToke(rightBracket))
        {
            return null;
        }






        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }






        Toke leftBrace;



        leftBrace = this.Toke(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));




        if (this.NullToke(leftBrace))
        {
            return null;
        }





        Toke rightBrace;



        rightBrace = this.TokeMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));




        if (this.NullToke(rightBrace))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(rightBrace.Range.End, range.End))))
        {
            return null;
        }






        Access access;



        access = this.Access(accessRange);




        if (this.Null(access))
        {
            this.Error(this.ErrorKind.AccessInvalid, range);
        }





        CaseName varClass;



        varClass = this.ClassName(classRange);




        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassInvalid, range);
        }





        MethodName name;



        name = this.MethodName(nameRange);




        if (this.Null(name))
        {
            this.Error(this.ErrorKind.NameInvalid, range);
        }






        ParamList param;


        param = this.ParamList(this.Range(leftBracket.Range.End, rightBracket.Range.Start));




        if (this.Null(param))
        {
            this.Error(this.ErrorKind.ParamInvalid, range);
        }






        StateList call;


        call = this.StateList(this.Range(leftBrace.Range.End, rightBrace.Range.Start));




        if (this.Null(call))
        {
            this.Error(this.ErrorKind.CallInvalid, range);
        }






        Method ret;
        

        ret = new Method();


        ret.Init();
        

        ret.Name = name;
        

        ret.Clas = varClass;


        ret.Param = param;


        ret.Call = call;
        

        ret.Access = access;


        this.NodeInfo(ret, range);


        return ret;
    }





    protected virtual ParamList ParamList(Range range)
    {
        List list;
        


        list = this.List(this.Param, this.ParamRange, range, this.Delimiter.PauseSign);




        if (this.Null(list))
        {
            return null;
        }




        ParamList ret;


        ret = new ParamList();


        ret.Init();

            
        ret.Value = list;
        

        this.NodeInfo(ret, range);


        return ret;
    }





    protected virtual Param Param(Range range)
    {
        Var varVar;


        varVar = this.Var(range);



        if (this.Null(varVar))
        {
            return null;
        }





        Param ret;


        ret = new Param();


        ret.Init();
        
        
        ret.Var = varVar;
            
            
        this.NodeInfo(ret, range);


        return ret;
    }







    protected virtual Var Var(Range range)
    {
        Range classRange;



        classRange = this.ClassNameRange(range);





        if (this.NullRange(classRange))
        {
            return null;
        }







        Range nameRange;



        nameRange = this.VarNameRange(this.Range(classRange.End, range.End));






        if (this.NullRange(nameRange))
        {
            return null;
        }







        if (!this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return null;
        }









        CaseName varClass;



        varClass = this.ClassName(classRange);





        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassInvalid, range);
        }







        VarName name;



        name = this.VarName(nameRange);





        if (this.Null(name))
        {
            this.Error(this.ErrorKind.NameInvalid, range);
        }
        









        Var ret;


        ret = new Var();


        ret.Init();

        
        ret.Class = varClass;


        ret.Name = name;


        this.NodeInfo(ret, range);


        return ret;
    }






    protected Access Access(Range range)
    {
        Access ret;


        ret = null;







        if (this.Null(ret))
        {
            ret = this.PublicAccess(range);
        }





        if (this.Null(ret))
        {
            ret = this.ProperAccess(range);
        }
        




        if (this.Null(ret))
        {
            ret = this.ParentAccess(range);
        }

        



        if (this.Null(ret))
        {
            ret = this.PrivatAccess(range);
        }





        return ret;
    }






    protected virtual PublicAccess PublicAccess(Range range)
    {
        Toke publicToken;



        publicToken = this.Toke(this.Keyword.Publi, range);




        if (this.NullToke(publicToken))
        {
            return null;
        }





        PublicAccess ret;


        ret = new PublicAccess();


        ret.Init();


        this.NodeInfo(ret, range);


        return ret;
    }





    protected virtual ProperAccess ProperAccess(Range range)
    {
        Toke properToken;



        properToken = this.Toke(this.Keyword.Prope, range);




        if (this.NullToke(properToken))
        {
            return null;
        }





        ProperAccess ret;


        ret = new ProperAccess();


        ret.Init();


        this.NodeInfo(ret, range);


        return ret;
    }






    protected virtual ParentAccess ParentAccess(Range range)
    {
        Toke parentToken;



        parentToken = this.Toke(this.Keyword.Paren, range);




        if (this.NullToke(parentToken))
        {
            return null;
        }





        ParentAccess ret;


        ret = new ParentAccess();


        ret.Init();


        this.NodeInfo(ret, range);


        return ret;
    }








    protected virtual PrivatAccess PrivatAccess(Range range)
    {
        Toke privatToken;



        privatToken = this.Toke(this.Keyword.Priva, range);




        if (this.NullToke(privatToken))
        {
            return null;
        }





        PrivatAccess ret;


        ret = new PrivatAccess();


        ret.Init();


        this.NodeInfo(ret, range);


        return ret;
    }






    protected StateList StateList(Range range)
    {
        List list;
        


        list = this.List(this.State, this.StateRange, range, null);




        if (this.Null(list))
        {
            return null;
        }






        StateList ret;


        ret = new StateList();


        ret.Init();


        ret.Value = list;
        
        
        this.NodeInfo(ret, range);

            
        return ret;
    }







    protected virtual State State(Range range)
    {
        State ret;

        
        ret = null;





        if (this.Null(ret))
        {
            ret = this.ReturnState(range);
        }


        


        if (this.Null(ret))
        {
            ret = this.IfState(range);
        }




        if (this.Null(ret))
        {
            ret = this.WhileState(range);
        }




        if (this.Null(ret))
        {
            ret = this.DeclareState(range);
        }



        
        if (this.Null(ret))
        {
            ret = this.AssignState(range);
        }



        
        if (this.Null(ret))
        {
            ret = this.ExpressState(range);
        }






        return ret;
    }







    private ExpressState ExpressState(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        int lastIndex;


        lastIndex = range.End - 1;




        Toke semicolon;


        semicolon = this.Toke(this.Delimiter.StateSign, this.IndexRange(lastIndex));



        if (this.NullToke(semicolon))
        {
            return null;
        }




        Expre express;
        
        

        express = this.Express(this.Range(range.Start, semicolon.Range.Start));
        



        if (this.Null(express))
        {
            this.Error(this.ErrorKind.ExpressInvalid, range);
        }





        ExpressState ret;
        

        ret = new ExpressState();


        ret.Init();

        
        ret.Express = express;


        this.NodeInfo(ret, range);
        

        return ret;
    }


    



    protected virtual Expre Express(Range range)
    {
        Expre ret;



        ret = null;




        bool L(ExpressMethod method)
        {
            if (! this.Null(ret))
            {
                return true;
            }



            ret = method(range);



            return true;
        }





        L(this.ThisExpress);


        L(this.BaseExpress);
            

        L(this.NullExpress);


        L(this.NewExpress);


        L(this.GlobExpress);


        L(this.CastExpress);


        L(this.BracketExpress);


        L(this.VarExpress);


        L(this.ConstantExpress);


        L(this.JoinExpress);


        L(this.AndExpress);


        L(this.OrnExpress);
        
        
        L(this.NotExpress);
        
        
        L(this.EqualExpress);

        
        L(this.LessExpress);


        L(this.AddExpress);


        L(this.SubExpress);


        L(this.MulExpress);


        L(this.DivExpress);
            

        L(this.CallExpress);
            

        L(this.GetExpress);






        return ret;
    }







    protected virtual ThisExpress ThisExpress(Range range)
    {
        Toke thisToken;




        thisToken = this.Toke(this.Keyword.This, range);





        if (this.NullToke(thisToken))
        {
            return null;
        }






        ThisExpress ret;


        ret = new ThisExpress();


        ret.Init();


        this.NodeInfo(ret, range);


        return ret;
    }





    protected virtual BaseExpress BaseExpress(Range range)
    {
        Toke baseToken;



        baseToken = this.Toke(this.Keyword.Base, range);




        if (this.NullToke(baseToken))
        {
            return null;
        }




        BaseExpress ret;


        ret = new BaseExpress();


        ret.Init();


        this.NodeInfo(ret, range);


        return ret;
    }







    protected virtual DeclareState DeclareState(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        int lastIndex;


        lastIndex = range.End - 1;




        Toke semicolon;


        semicolon = this.Toke(this.Delimiter.StateSign, this.IndexRange(lastIndex));



        if (this.NullToke(semicolon))
        {
            return null;
        }





        Var varVar;
        


        varVar = this.Var(this.Range(range.Start, semicolon.Range.Start));
        



        if (this.Null(varVar))
        {
            return null;
        }





        DeclareState ret;


        ret = new DeclareState();


        ret.Init();

            
        ret.Var = varVar;
            
            
        this.NodeInfo(ret, range);


        return ret;
    }







    private AssignState AssignState(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }





        int lastIndex;


        lastIndex = range.End - 1;




        Toke semicolon;


        semicolon = this.Toke(this.Delimiter.StateSign, this.IndexRange(lastIndex));



        if (this.NullToke(semicolon))
        {
            return null;
        }






        Toke colon;



        colon = this.TokeForward(this.Delimiter.BaseSign, this.Range(range.Start, semicolon.Range.Start));




        if (this.NullToke(colon))
        {
            return null;
        }
        





        Target target;


        target = this.Target(this.Range(range.Start, colon.Range.Start));
        


        if (this.Null(target))
        {
            this.Error(this.ErrorKind.TargetInvalid, range);
        }




        Expre value;


        value = this.Express(this.Range(colon.Range.End, semicolon.Range.Start));
        


        if (this.Null(value))
        {
            this.Error(this.ErrorKind.ValueInvalid, range);
        }





        AssignState ret;


        ret = new AssignState();


        ret.Init();

            
        ret.Target = target;
        

        ret.Value = value;   


        this.NodeInfo(ret, range);


        return ret;
    }





    protected virtual NewExpress NewExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Toke newToken;


        newToken = this.Toke(this.Keyword.Newa, this.IndexRange(range.Start));

        

        if (this.NullToke(newToken))
        {
            return null;
        }




        CaseName varClass;
        
        
        varClass = this.ClassName(this.Range(newToken.Range.End, range.End));
            


        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassInvalid, range);
        }





        NewExpress ret;


        ret = new NewExpress();


        ret.Init();

            
        ret.Class = varClass;
            
            
        this.NodeInfo(ret, range);


        return ret;
    }






    protected virtual GlobExpress GlobExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Toke globToken;


        globToken = this.Toke(this.Keyword.Glob, this.IndexRange(range.Start));

        

        if (this.NullToke(globToken))
        {
            return null;
        }




        CaseName varClass;
        
        
        varClass = this.ClassName(this.Range(globToken.Range.End, range.End));
            


        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassInvalid, range);
        }




        GlobExpress ret;
        

        ret = new GlobExpress();


        ret.Init();

        
        ret.Class = varClass;
        
        
        this.NodeInfo(ret, range);
        

        return ret;
    }







    private AndExpress AndExpress(Range range)
    {
        Toke op;



        op = this.TokeBackward(this.Delimiter.AndSign, range);




        if (this.NullToke(op))
        {
            return null;
        }




        bool hasOperandInvalid;



        hasOperandInvalid = false;





        Expre left;
        


        left = this.Express(this.Range(range.Start, op.Range.Start));
            


        if (this.Null(left))
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }




        Expre right;
        
        

        right = this.Express(this.Range(op.Range.End, range.End));
            



        if (this.Null(right))
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }




        AndExpress ret;
            
        ret = new AndExpress();

        ret.Init();

        ret.Left = left;
            
        ret.Right = right;
        
        
        this.NodeInfo(ret, range);
            
        return ret;
    }





    private OrnExpress OrnExpress(Range range)
    {
        Toke op;



        op = this.TokeBackward(this.Delimiter.OrnSign, range);




        if (this.NullToke(op))
        {
            return null;
        }





        bool hasOperandInvalid;



        hasOperandInvalid = false;





        Expre left;
        
        

        left = this.Express(this.Range(range.Start, op.Range.Start));
            



        if (left == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }





        Expre right;
        
        

        right = this.Express(this.Range(op.Range.End, range.End));
            



        if (right == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }




        OrnExpress ret;

        ret = new OrnExpress();

        ret.Init();
            
        ret.Left = left;
            
        ret.Right = right;
            
        this.NodeInfo(ret, range);

        return ret;
    }





    private NotExpress NotExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Toke op;



        op = this.Toke(this.Delimiter.NotSign, this.IndexRange(range.Start));




        if (this.NullToke(op))
        {
            return null;
        }




        Expre varBool;
        
        

        varBool = this.Express(this.Range(op.Range.End, range.End));
            



        if (this.Null(varBool))
        {
            this.Error(this.ErrorKind.OperandInvalid, range);
        }




        NotExpress ret;

        ret = new NotExpress();
        
        ret.Bool = varBool;
        
        this.NodeInfo(ret, range);
            
        return ret;
    }





    private AddExpress AddExpress(Range range)
    {
        Toke op;
        


        op = this.TokeBackward(this.Delimiter.AddSign, range);




        if (this.NullToke(op))
        {
            return null;
        }




        bool hasOperandInvalid;



        hasOperandInvalid = false;




        Expre left;



        left = this.Express(this.Range(range.Start, op.Range.Start));

        
        

        if (left == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }





        Expre right;
        
        


        right = this.Express(this.Range(op.Range.End, range.End));
        



        if (right == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }





        AddExpress ret;

        ret = new AddExpress();
            
        ret.Left = left;
            
        ret.Right = right;
            
        this.NodeInfo(ret, range);

        return ret;
    }





    private SubExpress SubExpress(Range range)
    {
        Toke op;




        op = this.TokeBackward(this.Delimiter.SubSign, range);





        if (this.NullToke(op))
        {
            return null;
        }




        bool hasOperandInvalid;




        hasOperandInvalid = false;




        Expre left;
        
        


        left = this.Express(this.Range(range.Start, op.Range.Start));




        if (left == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }





        Expre right;
        



        right = this.Express(this.Range(op.Range.End, range.End));
            




        if (right == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }




        SubExpress ret;

        ret = new SubExpress();
            
        ret.Left = left;
            
        ret.Right = right;
            
        this.NodeInfo(ret, range);
            
        return ret;
    }





    private MulExpress MulExpress(Range range)
    {
        Toke op;



        op = this.TokeBackward(this.Delimiter.MulSign, range);




        if (this.NullToke(op))
        {
            return null;
        }





        bool hasOperandInvalid;



        hasOperandInvalid = false;





        Expre left;
        



        left = this.Express(this.Range(range.Start, op.Range.Start));
            



        if (left == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }





        Expre right;
        



        right = this.Express(this.Range(op.Range.End, range.End));
        



        if (right == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }




        MulExpress ret;
        
        ret = new MulExpress();
        
        ret.Left = left;
        
        ret.Right = right;
        
        this.NodeInfo(ret, range);
            
        return ret;
    }






    private DivExpress DivExpress(Range range)
    {
        Toke op;




        op = this.TokeBackward(this.Delimiter.DivSign, range);




        if (this.NullToke(op))
        {
            return null;
        }




        bool hasOperandInvalid;

        hasOperandInvalid = false;




        Expre left;
            
        left = this.Express(this.Range(range.Start, op.Range.Start));
            

        if (left == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }



        Expre right;
                        
        right = this.Express(this.Range(op.Range.End, range.End));
            

        if (right == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }

        

        DivExpress ret;

        ret = new DivExpress();
            
        ret.Left = left;
            
        ret.Right = right;
            
        this.NodeInfo(ret, range);
            
        return ret;
    }





    private EqualExpress EqualExpress(Range range)
    {
        Toke op;



        op = this.TokeBackward(this.Delimiter.EqualSign, range);




        if (this.NullToke(op))
        {
            return null;
        }




        bool hasOperandInvalid;

        hasOperandInvalid = false;




        Expre left;
            
        left = this.Express(this.Range(range.Start, op.Range.Start));
            

        if (this.Null(left))
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }



        Expre right;
            
        right = this.Express(this.Range(op.Range.End, range.End));
            

        if (this.Null(right))
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }



        EqualExpress ret;
            
        ret = new EqualExpress();

        ret.Init();
            
        ret.Left = left;
            
        ret.Right = right;
            
        this.NodeInfo(ret, range);
            
        return ret;
    }




    private LessExpress LessExpress(Range range)
    {
        Toke op;
        

        op = this.TokeBackward(this.Delimiter.LessSign, range);




        if (this.NullToke(op))
        {
            return null;
        }




        bool hasOperandInvalid;

        hasOperandInvalid = false;




        Expre left;
        

        left = this.Express(this.Range(range.Start, op.Range.Start));
        

        if (this.Null(left))
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }



        Expre right;
        

        right = this.Express(this.Range(op.Range.End, range.End));
        

        if (this.Null(right))
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }




        LessExpress ret;


        ret = new LessExpress();


        ret.Init();

            
        ret.Left = left;


        ret.Right = right;


        this.NodeInfo(ret, range);


        return ret;
    }





    protected virtual JoinExpress JoinExpress(Range range)
    {
        Toke op;
        



        op = this.TokeBackward(this.Delimiter.JoinSign, range);




        if (this.NullToke(op))
        {
            return null;
        }




        bool hasOperandInvalid;

        hasOperandInvalid = false;




        Expre left;
            
        left = this.Express(this.Range(range.Start, op.Range.Start));
            

        if (this.Null(left))
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }



        Expre right;
            
        right = this.Express(this.Range(op.Range.End, range.End));
            

        if (this.Null(right))
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }



        JoinExpress ret;

        ret = new JoinExpress();

        ret.Init();
            
        ret.Left = left;
            
        ret.Right = right;
            
        this.NodeInfo(ret, range);
            
        return ret;
    }





    private GetExpress GetExpress(Range range)
    {
        Toke dot;
        


        dot = this.TokeBackward(this.Delimiter.StopSign, range);




        if (this.NullToke(dot))
        {
            return null;
        }




        Expre varThis;




        varThis = this.Express(this.Range(range.Start, dot.Range.Start));





        if (this.Null(varThis))
        {
            this.Error(this.ErrorKind.ThisInvalid, range);
        }
        




        FieldName field;




        field = this.FieldName(this.Range(dot.Range.End, range.End));
            




        if (this.Null(field))
        {
            this.Error(this.ErrorKind.FieldInvalid, range);
        }





        GetExpress ret;
            
        ret = new GetExpress();

        ret.Init();
            
        ret.This = varThis;
            
        ret.Field = field;

        this.NodeInfo(ret, range);

        return ret;
    }





    protected virtual CallExpress CallExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }





        Toke rightBracket;
        


        rightBracket = this.Toke(this.Delimiter.RightBracket, this.IndexRange(range.End - 1));




        if (this.NullToke(rightBracket))
        {
            return null;
        }




        Toke leftBracket;
        
        

        leftBracket = this.TokeMatchRightBracket(this.Range(range.Start, rightBracket.Range.Start));




        if (this.NullToke(leftBracket))
        {
            return null;
        }





        Toke dot;
        


        dot = this.TokeBackward(this.Delimiter.StopSign, this.Range(range.Start, leftBracket.Range.Start));
            



        if (this.NullToke(dot))
        {
            return null;
        }





        Expre varThis;
            
        
        
        varThis = this.Express(this.Range(range.Start, dot.Range.Start));
            



        if (this.Null(varThis))
        {
            this.Error(this.ErrorKind.ThisInvalid, range);
        }

            



        MethodName method;



        method = this.MethodName(this.Range(dot.Range.End, leftBracket.Range.Start));
            



        if (this.Null(method))
        {
            this.Error(this.ErrorKind.MethodInvalid, range);
        }

            



        ArgueList argue;



        argue = this.ArgueList(this.Range(leftBracket.Range.End, rightBracket.Range.Start));
            



        if (this.Null(argue))
        {
            this.Error(this.ErrorKind.ArgueInvalid, range);
        }




        CallExpress ret;

        ret = new CallExpress();

        ret.Init();
        
        ret.This = varThis;
        
        ret.Method = method;
        
        ret.Argue = argue;
        
        this.NodeInfo(ret, range);
        
        return ret;
    }







    private IfState IfState(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Toke ifToken;
        
        
        ifToken = this.Toke(this.Keyword.Mifa, this.IndexRange(range.Start));



        if (this.NullToke(ifToken))
        {
            return null;
        }




        if (this.Zero(this.Count(this.Range(ifToken.Range.End, range.End))))
        {
            return null;
        }




        Toke leftBracket;
        
        

        leftBracket = this.Toke(this.Delimiter.LeftBracket, this.IndexRange(ifToken.Range.End));



        if (this.NullToke(leftBracket))
        {
            return null;
        }





        Toke rightBracket;
        
        

        rightBracket = this.TokeMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));




        if (this.NullToke(rightBracket))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }




        Toke leftBrace;


        leftBrace = this.Toke(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));



        if (this.NullToke(leftBrace))
        {
            return null;
        }




        Toke rightBrace;
        
        
        rightBrace = this.TokeMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));



        if (this.NullToke(rightBrace))
        {
            return null;
        }




        if (!this.Zero(this.Count(this.Range(rightBrace.Range.End, range.End))))
        {
            return null;
        }


            


        Expre cond;

        
        cond = this.Express(this.Range(leftBracket.Range.End, rightBracket.Range.Start));
            

        if (this.Null(cond))
        {
            this.Error(this.ErrorKind.CondInvalid, range);
        }




        StateList then;


        then = this.StateList(this.Range(leftBrace.Range.End, rightBrace.Range.Start));
            

        if (this.Null(then))
        {
            this.Error(this.ErrorKind.ThenInvalid, range);
        }

        





        IfState ret;


        ret = new IfState();


        ret.Init();

            
        ret.Cond = cond;


        ret.Then = then;
        
            
        this.NodeInfo(ret, range);


        return ret;
    }





    private WhileState WhileState(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Toke whileToken;
        

        whileToken = this.Toke(this.Keyword.Lope, this.IndexRange(range.Start));



        if (this.NullToke(whileToken))
        {
            return null;
        }




        if (this.Zero(this.Count(this.Range(whileToken.Range.End, range.End))))
        {
            return null;
        }




        Toke leftBracket;
        
        
        leftBracket = this.Toke(this.Delimiter.LeftBracket, this.IndexRange(whileToken.Range.End));



        if (this.NullToke(leftBracket))
        {
            return null;
        }



        Toke rightBracket;
        
        
        rightBracket = this.TokeMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));



        if (this.NullToke(rightBracket))
        {
            return null;
        }



        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }




        Toke leftBrace;
        
        
        leftBrace = this.Toke(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));



        if (this.NullToke(leftBrace))
        {
            return null;
        }



        Toke rightBrace;
        
        
        rightBrace = this.TokeMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));
            


        if (this.NullToke(rightBrace))
        {
            return null;
        }




        if (!this.Zero(this.Count(this.Range(rightBrace.Range.End, range.End))))
        {
            return null;
        }




        Expre cond;
        
        
        cond = this.Express(this.Range(leftBracket.Range.End, rightBracket.Range.Start));
            


        if (this.Null(cond))
        {
            this.Error(this.ErrorKind.CondInvalid, range);
        }




        StateList loop;
        

        loop = this.StateList(this.Range(leftBrace.Range.End, rightBrace.Range.Start));
        


        if (this.Null(loop))
        {
            this.Error(this.ErrorKind.LoopInvalid, range);
        }



        WhileState ret;

        ret = new WhileState();

        ret.Init();
        
        ret.Cond = cond;
        
        ret.Loop = loop;
        
        this.NodeInfo(ret, range);
        
        return ret;
    }





    private ReturnState ReturnState(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Toke returnToken;
        

        returnToken = this.Toke(this.Keyword.Retu, this.IndexRange(range.Start));



        if (this.NullToke(returnToken))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(returnToken.Range.End, range.End))))
        {
            return null;
        }




        int lastIndex;


        lastIndex = range.End - 1;




        Toke semicolon;


        semicolon = this.Toke(this.Delimiter.StateSign, this.IndexRange(lastIndex));



        if (this.NullToke(semicolon))
        {
            return null;
        }






        Expre result;


        result = this.Express(this.Range(returnToken.Range.End, semicolon.Range.Start));
        


        if (this.Null(result))
        {
            this.Error(this.ErrorKind.ResultInvalid, range);
        }
        



        ReturnState ret;

        ret = new ReturnState();

        ret.Init();
        
        ret.Result = result;
        
        this.NodeInfo(ret, range);
        
        return ret;
    }






    protected virtual CastExpress CastExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }





        Toke castToken;


        castToken = this.Toke(this.Keyword.Cast, this.IndexRange(range.Start));




        if (this.NullToke(castToken))
        {
            return null;
        }






        Range classRange;


        classRange = this.ClassNameRange(this.Range(castToken.Range.End, range.End));



        if (this.NullRange(classRange))
        {
            return null;
        }






        if (this.Zero(this.Count(this.Range(classRange.End, range.End))))
        {
            return null;
        }





        Toke leftBracket;


        leftBracket = this.Toke(this.Delimiter.LeftBracket, this.IndexRange(classRange.End));




        if (this.NullToke(leftBracket))
        {
            return null;
        }





        Toke rightBracket;


        rightBracket = this.TokeMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));



        if (this.NullToke(rightBracket))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }







        CaseName varClass;


        varClass = this.ClassName(classRange);




        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassInvalid, range);
        }





        Expre varObject;


        varObject = this.Express(this.Range(leftBracket.Range.End, rightBracket.Range.Start));




        if (this.Null(varObject))
        {
            this.Error(this.ErrorKind.ObjectInvalid, range);
        }






        
        CastExpress ret;

        ret = new CastExpress();

        ret.Init();
        
        ret.Class = varClass;
        
        ret.Object = varObject;
        

        this.NodeInfo(ret, range);
        
        return ret;
    }

    





    private BracketExpress BracketExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Toke leftBracket;
        
        
        leftBracket = this.Toke(this.Delimiter.LeftBracket, this.IndexRange(range.Start));




        if (this.NullToke(leftBracket))
        {
            return null;
        }





        Toke rightBracket;


        rightBracket = this.TokeMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));



        if (this.NullToke(rightBracket))
        {
            return null;
        }




        if (!this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }





        Expre express;


        express = this.Express(this.Range(leftBracket.Range.End, rightBracket.Range.Start));



        if (this.Null(express))
        {
            this.Error(this.ErrorKind.ExpressInvalid, range);
        }






        BracketExpress ret;
        

        ret = new BracketExpress();


        ret.Init();

        
        ret.Express = express;


        this.NodeInfo(ret, range);


        return ret;
    }






    private VarExpress VarExpress(Range range)
    {
        VarName varVar;



        varVar = this.VarName(range);
        


        if (this.Null(varVar))
        {
            return null;
        }




        VarExpress ret;
        
        ret = new VarExpress();
        
        ret.Var = varVar;


        this.NodeInfo(ret, range);

        return ret;
    }




    private ConstantExpress ConstantExpress(Range range)
    {
        Constant constant;

        constant = this.Constant(range);
            

        if (this.Null(constant))
        {
            return null;
        }



        ConstantExpress ret;
            
        ret = new ConstantExpress();

        ret.Init();
            
        ret.Constant = constant;

        this.NodeInfo(ret, range);

        return ret;
    }






    private NullExpress NullExpress(Range range)
    {
        Toke nullToken;
        


        nullToken = this.Toke(this.Keyword.Null, range);




        if (this.NullToke(nullToken))
        {
            return null;
        }




        NullExpress ret;
        
        
        ret = new NullExpress();


        ret.Init();


        this.NodeInfo(ret, range);
            
        return ret;
    }

    




    protected ArgueList ArgueList(Range range)
    {
        List list;



        list = this.List(this.Argue, this.ArgueRange, range, this.Delimiter.PauseSign);




        if (this.Null(list))
        {
            return null;
        }




        ArgueList ret;


        ret = new ArgueList();


        ret.Init();
        
        
        ret.Value = list;


        this.NodeInfo(ret, range);


        return ret;
    }



    



    private Argue Argue(Range range)
    {
        Expre express;

        express = this.Express(range);
            

        if (this.Null(express))
        {
            return null;
        }



        Argue ret;

        ret = new Argue();

        ret.Init();

        ret.Express = express;

        this.NodeInfo(ret, range);

        return ret;
    }




    private Target Target(Range range)
    {
        Target ret;

        
        ret = null;




        bool L(TargetMethod method)
        {
            if (!this.Null(ret))
            {
                return true;
            }


            ret = method(range);



            return true;
        }





        L(this.VarTarget);




        L(this.SetTarget);




        return ret;
    }





    private VarTarget VarTarget(Range range)
    {
        VarName varVar;
            
            
        varVar = this.VarName(range);
            

        if (this.Null(varVar))
        {
            return null;
        }



        VarTarget ret;
            
        ret = new VarTarget();

        ret.Init();
            
        ret.Var = varVar;
            
        this.NodeInfo(ret, range);

        return ret;
    }
    





    private SetTarget SetTarget(Range range)
    {
        Toke dot;
        


        dot = this.TokeBackward(this.Delimiter.StopSign, range);




        if (this.NullToke(dot))
        {
            return null;
        }




        Expre varThis;
        
        

        varThis = this.Express(this.Range(range.Start, dot.Range.Start));
        


        if (this.Null(varThis))
        {
            this.Error(this.ErrorKind.ThisInvalid, range);
        }





        FieldName field;



        field = this.FieldName(this.Range(dot.Range.End, range.End));




        if (this.Null(field))
        {
            this.Error(this.ErrorKind.FieldInvalid, range);
        }

            



        SetTarget ret;
            
        ret = new SetTarget();

        ret.Init();
            
        ret.This = varThis;
            
        ret.Field = field;
            
        this.NodeInfo(ret, range);
            
        return ret;
    }





    private Constant Constant(Range range)
    {
        Constant ret;
        

        ret = null;


        

        bool L(ConstantMethod method)
        {
            if (!this.Null(ret))
            {
                return true;
            }



            ret = method(range);



            return true;
        }




        L(this.BoolConstant);



        L(this.IntConstant);



        L(this.StringConstant);




        return ret;
    }







    private BoolConstant BoolConstant(Range range)
    {
        if (!(this.Count(range) == 1))
        {
            return null;
        }




        TextRange s;

        s = this.Text(range.Start);






        bool? o;


        o = null;



        if (!o.HasValue)
        {
            if (this.TextInfra.Equal(s.Row, s.Range, this.Keyword.True))
            {
                o = true;
            }
        }
        
        
        if (!o.HasValue)
        {
            if (this.TextInfra.Equal(s.Row, s.Range, this.Keyword.Fase))
            {
                o = false;
            }
        }
        


        if (!o.HasValue)
        {
            return null;
        }




        bool value;


        value = o.Value;
        



        BoolConstant ret;


        ret = new BoolConstant();


        ret.Init();

            
        ret.Value = value;
        

        this.NodeInfo(ret, range);

        return ret;
    }







    private IntConstant IntConstant(Range range)
    {
        if (!(this.Count(range) == 1))
        {
            return null;
        }





        TextRange s;

        

        s = this.Text(range.Start);




        if (!this.IsIntValue(s))
        {
            return null;
        }





        ulong value;

        

        value = this.IntValue(s);





        IntConstant ret;

        ret = new IntConstant();

        ret.Init();
            
        ret.Value = value;
        
        
        this.NodeInfo(ret, range);


        return ret;
    }







    protected virtual StringConstant StringConstant(Range range)
    {
        if (!(this.Count(range) == 1))
        {
            return null;
        }




        TextRange s;
        


        s = this.Text(range.Start);




        string value;



        value = this.StringInfra.Value(s.Row, s.Range);




        if (this.Null(value))
        {
            return null;
        }




        StringConstant ret;

        ret = new StringConstant();

        ret.Init();

        ret.Value = value;
        

        this.NodeInfo(ret, range);
        

        return ret;
    }








    protected CaseName ClassName(Range range)
    {
        string value;

        value = this.NameValue(range);


        if (this.Null(value))
        {
            return null;
        }


        CaseName ret;
        
        ret = new CaseName();

        ret.Init();
        
        ret.Valu = value;
        
        this.NodeInfo(ret, range);

        return ret;
    }





    protected FieldName FieldName(Range range)
    {
        string value;
            
        value = this.NameValue(range);


        if (this.Null(value))
        {
            return null;
        }


        FieldName ret;

        ret = new FieldName();

        ret.Init();
        
        ret.Valu = value;
        
        this.NodeInfo(ret, range);

        return ret;
    }





    protected MethodName MethodName(Range range)
    {
        string value;
            
        value = this.NameValue(range);


        if (this.Null(value))
        {
            return null;
        }


        MethodName ret;
        
        ret = new MethodName();

        ret.Init();
        
        ret.Valu = value;
        
        this.NodeInfo(ret, range);
            
        return ret;
    }





    protected VarName VarName(Range range)
    {
        string value;
            
        value = this.NameValue(range);


        if (this.Null(value))
        {
            return null;
        }


        VarName ret;

        ret = new VarName();

        ret.Init();
        
        ret.Valu = value;
        
        this.NodeInfo(ret, range);

        return ret;
    }






    protected List List(NodeMethod nodeMethod, RangeMethod rangeMethod, Range range, string delimiter)
    {
        List list;



        list = new List();


        list.Init();




        Range nodeRange;



        Node node;



        Range currentRange;




        if (this.Zero(this.Count(range)))
        {
            return list;
        }




        bool hasInvalid;



        hasInvalid = false;





        bool b;


        b = false;




        currentRange = range;




        Range t;


        t = currentRange;




        nodeRange = rangeMethod(t);



        if (this.Zero(this.Count(nodeRange)))
        {
            this.UniqueError(this.ErrorKind.Invalid, range, ref hasInvalid);



                     
            b = true;
        }
        else
        {
            node = nodeMethod(nodeRange);



            if (node == null)
            {
                this.Error(this.ErrorKind.Invalid, nodeRange);
            }




            list.Add(node);
        }




        if (!b)
        {
            currentRange = this.Range(nodeRange.End, range.End);



            while (!(this.Count(currentRange) == 0))
            {
                if (!(delimiter == null))
                {
                    Toke delimiterToken;


                    delimiterToken = this.Toke(delimiter, this.IndexRange(currentRange.Start));



                    if (this.NullToke(delimiterToken))
                    {
                        this.UniqueError(this.ErrorKind.Invalid, range, ref hasInvalid);

                        break;
                    }




                    Range o;


                    o = this.Range(delimiterToken.Range.End, range.End);



                    if (this.Count(o) == 0)
                    {
                        this.UniqueError(this.ErrorKind.Invalid, range, ref hasInvalid);

                        break;
                    }



                    t = o;
                }
                else
                {
                    t = currentRange;
                }




                nodeRange = rangeMethod(t);



                if (this.Count(nodeRange) == 0)
                {
                    this.UniqueError(this.ErrorKind.Invalid, range, ref hasInvalid);




                    b = true;
                }
                else
                {
                    node = nodeMethod(nodeRange);



                    if (node == null)
                    {
                        this.Error(this.ErrorKind.Invalid, nodeRange);
                    }



                        
                    list.Add(node);
                }




                if (b)
                {
                    break;
                }



                currentRange = this.Range(nodeRange.End, range.End);
            }
        }




        List ret;

        ret = list;
            
            
        return ret;
    }





    protected Range ClassNameRange(Range range)
    {
        return this.NameRange(range);
    }




    protected Range FieldNameRange(Range range)
    {
        return this.NameRange(range);
    }




    protected Range MethodNameRange(Range range)
    {
        return this.NameRange(range);
    }




    protected Range VarNameRange(Range range)
    {
        return this.NameRange(range);
    }





    protected Range NameRange(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return this.RangeNull;
        }




        if (!this.IsName(this.Text(range.Start)))
        {
            return this.RangeNull;
        }




        return this.IndexRange(range.Start);
    }





    protected virtual Range StateRange(Range range)
    {
        Range returnStateRange;


        returnStateRange = this.ReturnStateRange(range);




        if (!this.NullRange(returnStateRange))
        {
            return returnStateRange;
        }






        Range ifStateRange;


        ifStateRange = this.IfStateRange(range);




        if (!this.NullRange(ifStateRange))
        {
            return ifStateRange;
        }






        Range whileStateRange;


        whileStateRange = this.WhileStateRange(range);




        if (!this.NullRange(whileStateRange))
        {
            return whileStateRange;
        }






        Range declareStateRange;


        declareStateRange = this.DeclareStateRange(range);




        if (!this.NullRange(declareStateRange))
        {
            return declareStateRange;
        }







        Range assignStateRange;


        assignStateRange = this.AssignStateRange(range);




        if (!this.NullRange(assignStateRange))
        {
            return assignStateRange;
        }







        Range expressStateRange;


        expressStateRange = this.ExpressStateRange(range);




        if (!this.NullRange(expressStateRange))
        {
            return expressStateRange;
        }




        return this.RangeNull;
    }






    private Range ReturnStateRange(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return this.RangeNull;
        }





        Toke returnToken;
        

        returnToken = this.Toke(this.Keyword.Retu, this.IndexRange(range.Start));



        if (this.NullToke(returnToken))
        {
            return this.RangeNull;
        }





        Toke semicolon;



        semicolon = this.TokeForward(this.Delimiter.StateSign, this.Range(returnToken.Range.End, range.End));



        if (this.NullToke(semicolon))
        {
            return this.RangeNull;
        }





        Range t;


        t = this.Range(range.Start, semicolon.Range.End);





        Range ret;


        ret = t;



        return ret;
    }







    private Range IfStateRange(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return this.RangeNull;
        }




        Toke ifToken;
        
        
        ifToken = this.Toke(this.Keyword.Mifa, this.IndexRange(range.Start));



        if (this.NullToke(ifToken))
        {
            return this.RangeNull;
        }




        if (this.Zero(this.Count(this.Range(ifToken.Range.End, range.End))))
        {
            return this.RangeNull;
        }




        Toke leftBracket;
        
        

        leftBracket = this.Toke(this.Delimiter.LeftBracket, this.IndexRange(ifToken.Range.End));



        if (this.NullToke(leftBracket))
        {
            return this.RangeNull;
        }





        Toke rightBracket;
        
        

        rightBracket = this.TokeMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));




        if (this.NullToke(rightBracket))
        {
            return this.RangeNull;
        }





        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return this.RangeNull;
        }




        Toke leftBrace;


        leftBrace = this.Toke(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));



        if (this.NullToke(leftBrace))
        {
            return this.RangeNull;
        }




        Toke rightBrace;
        
        
        rightBrace = this.TokeMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));



        if (this.NullToke(rightBrace))
        {
            return this.RangeNull;
        }




        Range t;


        t = this.Range(range.Start, rightBrace.Range.End);




        Range ret;


        ret = t;


        return ret;
    }





    private Range WhileStateRange(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return this.RangeNull;
        }




        Toke whileToken;
        
        
        whileToken = this.Toke(this.Keyword.Lope, this.IndexRange(range.Start));



        if (this.NullToke(whileToken))
        {
            return this.RangeNull;
        }




        if (this.Zero(this.Count(this.Range(whileToken.Range.End, range.End))))
        {
            return this.RangeNull;
        }




        Toke leftBracket;
        
        

        leftBracket = this.Toke(this.Delimiter.LeftBracket, this.IndexRange(whileToken.Range.End));



        if (this.NullToke(leftBracket))
        {
            return this.RangeNull;
        }





        Toke rightBracket;
        
        

        rightBracket = this.TokeMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));




        if (this.NullToke(rightBracket))
        {
            return this.RangeNull;
        }





        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return this.RangeNull;
        }




        Toke leftBrace;


        leftBrace = this.Toke(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));



        if (this.NullToke(leftBrace))
        {
            return this.RangeNull;
        }




        Toke rightBrace;
        
        
        rightBrace = this.TokeMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));



        if (this.NullToke(rightBrace))
        {
            return this.RangeNull;
        }




        Range t;


        t = this.Range(range.Start, rightBrace.Range.End);
        



        Range ret;


        ret = t;


        return ret;
    }





    protected virtual Range DeclareStateRange(Range range)
    {
        Range varRange;


        varRange = this.VarRange(range);




        if (this.NullRange(varRange))
        {
            return this.RangeNull;
        }





        if (this.Zero(this.Count(this.Range(varRange.End, range.End))))
        {
            return this.RangeNull;
        }




        Toke semicolon;


        semicolon = this.Toke(this.Delimiter.StateSign, this.IndexRange(varRange.End));



        if (this.NullToke(semicolon))
        {
            return this.RangeNull;
        }





        Range t;


        t = this.Range(range.Start, semicolon.Range.End);





        Range ret;


        ret = t;



        return ret;
    }





    private Range AssignStateRange(Range range)
    {
        Toke semicolon;



        semicolon = this.TokeForward(this.Delimiter.StateSign, range);




        if (this.NullToke(semicolon))
        {
            return this.RangeNull;
        }





        Toke colon;



        colon = this.TokeForward(this.Delimiter.BaseSign, this.Range(range.Start, semicolon.Range.Start));




        if (this.NullToke(colon))
        {
            return this.RangeNull;
        }





        Range t;


        t = this.Range(range.Start, semicolon.Range.End);




        Range ret;


        ret = t;



        return ret;
    }





    private Range ExpressStateRange(Range range)
    {
        Toke semicolon;
        

        semicolon = this.TokeForward(this.Delimiter.StateSign, range);
        



        if (this.NullToke(semicolon))
        {
            return this.RangeNull;
        }
        



        Range t;
        
        
        t = this.Range(range.Start, semicolon.Range.End);




        Range ret;


        ret = t;


        return ret;
    }





    private Range VarRange(Range range)
    {
        Range classRange;


        classRange = this.ClassNameRange(range);



        if (this.NullRange(classRange))
        {
            return this.RangeNull;
        }




        Range nameRange;


        nameRange = this.VarNameRange(this.Range(classRange.End, range.End));



        if (this.NullRange(nameRange))
        {
            return this.RangeNull;
        }




        return this.Range(range.Start, nameRange.End);
    }







    private Range ParamRange(Range range)
    {
        return this.EndAtCommaRange(range);
    }


    private Range ArgueRange(Range range)
    {
        return this.EndAtCommaRange(range);
    }




    protected Range EndAtCommaRange(Range range)
    {
        Toke comma;
            

        comma = this.TokeForward(this.Delimiter.PauseSign, range);
        
        


        if (this.NullToke(comma))
        {
            return range;
        }
            


        return this.Range(range.Start, comma.Range.Start);
    }




    protected virtual Range AccessRange(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return this.RangeNull;
        }




        TextRange s;
        
        
        s = this.Text(range.Start);





        bool accessWord;


        
        accessWord = this.StringListContain(this.Keyword.Access, s);




        if (!accessWord)
        {
            return this.RangeNull;
        }




        Range ret;


        ret = this.IndexRange(range.Start);


        return ret;
    }





    protected virtual Range MemberRange(Range range)
    {
        Range fieldRange;


        fieldRange = this.FieldRange(range);




        if (!this.NullRange(fieldRange))
        {
            return fieldRange;
        }





        Range methodRange;


        methodRange = this.MethodRange(range);




        if (!this.NullRange(methodRange))
        {
            return methodRange;
        }




        return this.RangeNull;
    }






    private Range FieldRange(Range range)
    {
        Range accessRange;



        accessRange = this.AccessRange(range);






        if (this.NullRange(accessRange))
        {
            return this.RangeNull;
        }







        Range classRange;



        classRange = this.ClassNameRange(this.Range(accessRange.End, range.End));






        if (this.NullRange(classRange))
        {
            return this.RangeNull;
        }






        Range nameRange;



        nameRange = this.FieldNameRange(this.Range(classRange.End, range.End));






        if (this.NullRange(nameRange))
        {
            return this.RangeNull;
        }




            


        if (this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return this.RangeNull;
        }






        Toke getLeftBrace;



        getLeftBrace = this.Toke(this.Delimiter.LeftBrace, this.IndexRange(nameRange.End));




        if (this.NullToke(getLeftBrace))
        {
            return this.RangeNull;
        }





        Toke getRightBrace;



        getRightBrace = this.TokeMatchLeftBrace(this.Range(getLeftBrace.Range.End, range.End));




        if (this.NullToke(getRightBrace))
        {
            return this.RangeNull;
        }






        if (this.Zero(this.Count(this.Range(getRightBrace.Range.End, range.End))))
        {
            return this.RangeNull;
        }






        Toke setLeftBrace;



        setLeftBrace = this.Toke(this.Delimiter.LeftBrace, this.IndexRange(getRightBrace.Range.End));




        if (this.NullToke(setLeftBrace))
        {
            return this.RangeNull;
        }





        Toke setRightBrace;



        setRightBrace = this.TokeMatchLeftBrace(this.Range(setLeftBrace.Range.End, range.End));




        if (this.NullToke(setRightBrace))
        {
            return this.RangeNull;
        }







        Range t;

        t = this.Range(range.Start, setRightBrace.Range.End);




        Range ret;

        ret = t;


        return ret;
    }






    private Range MethodRange(Range range)
    {
        Range accessRange;



        accessRange = this.AccessRange(range);






        if (this.NullRange(accessRange))
        {
            return this.RangeNull;
        }







        Range classRange;



        classRange = this.ClassNameRange(this.Range(accessRange.End, range.End));






        if (this.NullRange(classRange))
        {
            return this.RangeNull;
        }






        Range nameRange;



        nameRange = this.MethodNameRange(this.Range(classRange.End, range.End));






        if (this.NullRange(nameRange))
        {
            return this.RangeNull;
        }




            


        if (this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return this.RangeNull;
        }






        Toke leftBracket;



        leftBracket = this.Toke(this.Delimiter.LeftBracket, this.IndexRange(nameRange.End));




        if (this.NullToke(leftBracket))
        {
            return this.RangeNull;
        }





        Toke rightBracket;



        rightBracket = this.TokeMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));




        if (this.NullToke(rightBracket))
        {
            return this.RangeNull;
        }






        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return this.RangeNull;
        }






        Toke leftBrace;



        leftBrace = this.Toke(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));




        if (this.NullToke(leftBrace))
        {
            return this.RangeNull;
        }





        Toke rightBrace;



        rightBrace = this.TokeMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));




        if (this.NullToke(rightBrace))
        {
            return this.RangeNull;
        }







        Range t;

        t = this.Range(range.Start, rightBrace.Range.End);




        Range ret;

        ret = t;


        return ret;
    }






    protected string NameValue(Range range)
    {
        if (!(this.Count(range) == 1))
        {
            return null;
        }



        TextRange s;
        
        s = this.Text(range.Start);




        bool valid;
        
        valid = this.IsName(s);


        if (!valid)
        {
            return null;
        }




        string t;

        t = this.TextInfra.Substring(s.Row, s.Range);



        string ret;

        ret = t;


        return ret;
    }


        




    private bool IsIntValue(TextRange s)
    {
        int charCount;


        charCount = this.Count(s.Range);




        int digitStart;

        digitStart = 0;




        int digitCount;

        digitCount = charCount;



        int digitCountMax;


        digitCountMax = 18;





        bool ba;


        ba = !(digitCount < 1);



        bool bb;

        bb = (digitCount < digitCountMax + 1);



        bool b;


        b = ba & bb;



        if (!b)
        {
            return false;
        }





        TextPos pos;


        pos = new TextPos();


        pos.Init();


        pos.Row = s.Row;




        int start;

        
        start = s.Range.Start + digitStart;




        int count;

        count = digitCount;



        

        int index;



        char oc;



        int i;


        i = 0;


        while (i < count)
        {
            index = i + start;



            pos.Col = index;



            oc = this.TextInfra.Char(pos);



            if (!this.TextInfra.IsDigit(oc))
            {
                return false;
            }




            i = i + 1;
        }



        return true;
    }




    private ulong IntValue(TextRange s)
    {
        ulong m;


        m = 10;




        int count;



        count = this.Count(s.Range);





        TextPos pos;


        pos = new TextPos();


        pos.Init();


        pos.Row = s.Row;





        int start;


        start = s.Range.Start;


        


        ulong total;



        total = 0;




        ulong n;



        n = 1;




        int h;



        int index;



        char code;



        ulong digit;



        ulong t;




        int i;

        
        i = 0;


        while (i < count)
        {
            h = count - 1 - i;


            
            index = start + h;



            pos.Col = index;



            
            code = this.TextInfra.Char(pos);



            
            digit = this.DigitValue(code);


            

            t = digit * n;



            total = total + t;



            n = n * m;



            i = i + 1;
        }




        ulong ret;


        ret = total;


        return ret;
    }







    private ulong DigitValue(char oc)
    {
        ulong k;

        k = 0;



        ulong t;

        t = oc;



        k = t - '0';



        ulong ret;

        ret = k;


        return ret;
    }







    protected TextRange Text(int index)
    {
        TokenToken token;


        token = this.Code.Toke.Get(index);
            

        return token.Range;
    }






    protected int Count(Range range)
    {
        RangeInfra infra;

        infra = RangeInfra.This;


        return infra.Count(range);
    }






    protected Range RangeNull;





    private bool IsName(TextRange s)
    {
        bool keyword;



        keyword = this.StringListContain(this.Keyword.All, s);




        if (keyword)
        {
            return false;
        }





        TextPos u;

        u = new TextPos();

        u.Init();

        u.Row = s.Row;

        u.Col = s.Range.Start;





        char oc;


        oc = this.TextInfra.Char(u);




        if (!this.TextInfra.IsLetter(oc))
        {
            return false;
        }







        bool valid;


        valid = true;






        int k;



        k = this.Count(s.Range);



        k = k - 1;





        int count;


        count = k;






        int start;


        start = s.Range.Start;


        start = start + 1;





        TextPos pos;


        pos = new TextPos();


        pos.Init();


        pos.Row = s.Row;




        int i;


        i = 0;



        while (valid & i < count)
        {
            pos.Col = start + i;



            char code;


            code = this.TextInfra.Char(pos);




            if (!this.TextInfra.IsAlphanumeric(code))
            {
                valid = false;
            }



            i = i + 1;
        }




        bool ret;


        ret = valid;


        return ret;
    }






    private bool StringListContain(List list, TextRange text)
    {
        ListIter iter;


        iter = list.Iter();



        while (iter.Next())
        {
            string s;


            s = (string)iter.Valu;



            if (this.TextInfra.Equal(text.Row, text.Range, s))
            {
                return true;
            }
        }



        return false;
    }





    protected bool NodeInfo(Node node, Range range)
    {
        node.Range = range;



        node.Id = this.NewId;




        if (this.NewId == ulong.MaxValue)
        {
            SystemConsole.Write("Error: Class.Node:Create NodeInfo New Id Fail\n");

            SystemEnvironment.Exit(11);
        }



        this.NewId = this.NewId + 1;




        return true;
    }



    private ulong NewId { get; set; }




    private bool IsToke(string value, int index)
    {
        TextRange t;

        t = this.Text(index);



        bool b;

        b = this.TextInfra.Equal(t.Row, t.Range, value);



        bool ret;

        ret = b;

        return ret;
    }




    protected Range Range(int start, int end)
    {
        Range ret;

        ret = new Range();
        
        ret.Start = start;
        
        ret.End = end;

        return ret;
    }






    protected Range IndexRange(int index)
    {
        return this.Range(index, index + 1);
    }






    protected bool NullToke(Toke toke)
    {
        return this.NullRange(toke.Range);
    }






    protected bool NullRange(Range range)
    {
        return range.Start == IntNull;
    }








    protected bool Null(object o)
    {
        ObjectInfra infra;

        infra = ObjectInfra.This;



        return infra.Null(o);
    }





    protected bool Zero(int i)
    {
        return i == 0;
    }






    protected bool Error(ErrorKind kind, Range range)
    {
        Error error;


        error = new Error();



        error.Init();



        error.Stage = this.Stage;



        error.Kind = kind;



        error.Range = range;



        error.Source = this.Source;



        this.ErrorList.Add(error);



        return true;
    }






    protected bool UniqueError(ErrorKind kind, Range range, ref bool hasAdded)
    {
        if (!hasAdded)
        {
            this.Error(kind, range);


            hasAdded = true;
        }




        return true;
    }



    protected Toke Toke(string value, Range range)
    {
        if (!(this.Count(range) == 1))
        {
            return this.TokeNull;
        }



        if (!this.IsToke(value, range.Start))
        {
            return this.TokeNull;
        }




        Toke ret;
        
        
        ret = new Toke();
        
        
        ret.Range = range;


        return ret;
    }





    protected Toke TokeBackward(string value, Range range)
    {
        int i;
        i = range.End;


        int index;
        index = IntNull;


        bool varContinue;
        varContinue = (range.Start < i);


        while (varContinue)
        {
            int skipBracketIndex;

            skipBracketIndex = this.BackwardSkipBracketList(i, range);

            if (!(skipBracketIndex == IntNull))
            {
                i = skipBracketIndex;
            }
            else
            {
                int j;

                j = i - 1;


                if (this.IsToke(value, j))
                {
                    index = j;

                    varContinue = false;
                }


                i = i - 1;
            }


            if (!(range.Start < i))
            {
                varContinue = false;
            }
        }



        if (index == IntNull)
        {
            return this.TokeNull;
        }




        Toke ret;

        ret = new Toke();

        ret.Range = this.IndexRange(index);

        return ret;
    }





    protected Toke TokeForward(string value, Range range)
    {
        int i;
            
        i = range.Start;


        int index;
            
        index = IntNull;


        bool varContinue;

        varContinue = i < range.End;


        while (varContinue)
        {
            int skipBracketIndex;

            skipBracketIndex = this.ForwardSkipBracketList(i, range);


            if (!(skipBracketIndex == IntNull))
            {
                i = skipBracketIndex;
            }
            else
            {
                if (this.IsToke(value, i))
                {
                    index = i;

                    varContinue = false;
                }
                else
                {
                    i = i + 1;
                }
            }


            if (!(i < range.End))
            {
                varContinue = false;
            }
        }




        if (index == IntNull)
        {
            return this.TokeNull;
        }




        Toke ret;
            
        ret = new Toke();

        ret.Range = this.IndexRange(index);

        return ret;
    }



    private int ForwardSkipBracketList(int index, Range range)
    {
        int ret;
            
        ret = IntNull;


        TextRange s;

        s = this.Text(index);


        if (this.TextInfra.Equal(s.Row, s.Range, this.Delimiter.LeftBracket))
        {
            Toke rightBracket;

            rightBracket = this.TokeMatchLeftBracket(this.Range(index + 1, range.End));
                

            if (this.NullToke(rightBracket))
            {
                return ret;
            }


            ret = rightBracket.Range.End;
        }
        else if (this.TextInfra.Equal(s.Row, s.Range, this.Delimiter.LeftBrace))
        {
            Toke rightBrace;

            rightBrace = this.TokeMatchLeftBrace(this.Range(index + 1, range.End));


            if (this.NullToke(rightBrace))
            {
                return ret;
            }


            ret = rightBrace.Range.End;
        }
        


        return ret;
    }






    private int BackwardSkipBracketList(int index, Range range)
    {
        int ret;

        ret = IntNull;


        int t;
        t = index - 1;


        TextRange s;

        s = this.Text(t);


        if (this.TextInfra.Equal(s.Row, s.Range, this.Delimiter.RightBracket))
        {
            Toke leftBracket;

            leftBracket = this.TokeMatchRightBracket(this.Range(range.Start, t));


            if (this.NullToke(leftBracket))
            {
                return ret;
            }


            ret = leftBracket.Range.Start;
        }
        else if (this.TextInfra.Equal(s.Row, s.Range, this.Delimiter.RightBrace))
        {
            Toke leftBrace;

            leftBrace = this.TokeMatchRightBrace(this.Range(range.Start, t));


            if (this.NullToke(leftBrace))
            {
                return ret;
            }


            ret = leftBrace.Range.Start;
        }
        


        return ret;
    }



    protected Toke TokeMatchLeftBrace(Range range)
    {   
        return this.TokeMatchLeftToken(this.Delimiter.LeftBrace, this.Delimiter.RightBrace, range);
    }


    protected Toke TokeMatchRightBrace(Range range)
    {
        return this.TokeMatchRightToken(this.Delimiter.LeftBrace, this.Delimiter.RightBrace, range);
    }


    protected Toke TokeMatchLeftBracket(Range range)
    {
        return this.TokeMatchLeftToken(this.Delimiter.LeftBracket, this.Delimiter.RightBracket, range);
    }


    protected Toke TokeMatchRightBracket(Range range)
    {
        return this.TokeMatchRightToken(this.Delimiter.LeftBracket, this.Delimiter.RightBracket, range);
    }



    private Toke TokeMatchLeftToken(string leftToken, string rightToken, Range range)
    {
        int openCount;
        openCount = 1;

        int index;
        index = IntNull;


        int i;
        i = range.Start;


        bool varContinue;
        varContinue = (i < range.End);

        while (varContinue)
        {
            TextRange s;

            s = this.Text(i);


            if (this.TextInfra.Equal(s.Row, s.Range, rightToken))
            {
                openCount = openCount - 1;

                if (openCount == 0)
                {
                    index = i;

                    varContinue = false;
                }
            }
            else if (this.TextInfra.Equal(s.Row, s.Range, leftToken))
            {
                openCount = openCount + 1;
            }

            if (index == IntNull)
            {
                i = i + 1;

                if (!(i < range.End))
                {
                    varContinue = false;
                }
            }
        }




        if (index == IntNull)
        {
            return this.TokeNull;
        }



        Toke ret;

        ret = new Toke();

        ret.Init();

        ret.Range = this.IndexRange(index);

        return ret;
    }




    private Toke TokeMatchRightToken(string leftToken, string rightToken, Range range)
    {
        int openCount;
        openCount = 1;

        int index;
        index = IntNull;

        int i;
        i = range.End;


        bool varContinue;
        varContinue = (i > range.Start);


        while (varContinue)
        {
            int t;
            t = i - 1;


            TextRange s;

            s = this.Text(t);


            if (this.TextInfra.Equal(s.Row, s.Range, leftToken))
            {
                openCount = openCount - 1;

                if (openCount == 0)
                {
                    index = t;

                    varContinue = false;
                }
            }
            else if (this.TextInfra.Equal(s.Row, s.Range, rightToken))
            {
                openCount = openCount + 1;
            }

            if (index == IntNull)
            {
                i = i - 1;

                if (!(i > range.Start))
                {
                    varContinue = false;
                }
            }
        }




        if (index == IntNull)
        {
            return this.TokeNull;
        }



        Toke ret;
            
        ret = new Toke();

        ret.Init();

        ret.Range = this.IndexRange(index);

        return ret;
    }
}