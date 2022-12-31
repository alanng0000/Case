namespace Class.Node;





public class Compile : InfraCompile
{
    public SourceArray SourceList { get; set; }




    public TokenResult TokenResult { get; set; }




    public string TaskNode { get; set; }




    public Result Result { get; set; }




    protected Keyword Keyword { get; set; }




    protected Delimiter Delimiter { get; set; }




    protected ErrorKindList ErrorKind { get; set; }




    private NodeMethodMap NodeMethodList { get; set; }




    private Code Code { get; set; }




    private NodeMethod NodeMethod { get; set; }




    private Token TokenNull;





    public override bool Init()
    {
        base.Init();






        this.Keyword = this.CreateKeyword();




        this.Delimiter = Delimiter.This;





        this.ErrorKind = this.CreateErrorKind();








        this.RangeNull = new Range();


        this.RangeNull.Start = IntNull;


        this.RangeNull.End = IntNull;





        this.TokenNull = new Token();


        this.TokenNull.Range = this.RangeNull;






        this.InitNodeMethodList();





        return true;
    }





    protected virtual Keyword CreateKeyword()
    {
        return Keyword.Instance;
    }




    protected virtual ErrorKindList CreateErrorKind()
    {
        return ErrorKindList.This;
    }





    protected virtual bool InitNodeMethodList()
    {
        this.NodeMethodList = new NodeMethodMap();



        this.NodeMethodList.Init();




        this.AddNodeMethod(nameof(this.Class), this.Class);


        this.AddNodeMethod(nameof(this.MemberList), this.MemberList);


        this.AddNodeMethod(nameof(this.Member), this.Member);


        this.AddNodeMethod(nameof(this.Field), this.Field);


        this.AddNodeMethod(nameof(this.Method), this.Method);


        this.AddNodeMethod(nameof(this.ParamList), this.ParamList);


        this.AddNodeMethod(nameof(this.Param), this.Param);


        this.AddNodeMethod(nameof(this.Var), this.Var);


        this.AddNodeMethod(nameof(this.Access), this.Access);


        this.AddNodeMethod(nameof(this.PublicAccess), this.PublicAccess);


        this.AddNodeMethod(nameof(this.LocalAccess), this.LocalAccess);


        this.AddNodeMethod(nameof(this.DeriveAccess), this.DeriveAccess);


        this.AddNodeMethod(nameof(this.PrivateAccess), this.PrivateAccess);


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


        this.AddNodeMethod(nameof(this.GlobalExpress), this.GlobalExpress);


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



        pair.Value = nodeMethod;




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





        this.Result.Tree = new TreeList();




        this.Result.Tree.Init();





        this.ErrorList = new ErrorList();



        this.ErrorList.Init();



        this.Result.Error = this.ErrorList;





        this.NewId = 0;






        NodeMethod nodeMethod;



        nodeMethod = (NodeMethod)this.NodeMethodList.Get(this.TaskNode);




        if (nodeMethod == null)
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
            this.Code = (Code)codeIter.Value;





            this.Source = (Source)sourceIter.Value;





            this.TextInfra.Text = this.Source.Text;






            Tree tree;


            tree = this.ExecuteTree();




            this.Result.Tree.Add(tree);
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


        rangeEnd = this.Code.Token.Count;



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






    protected virtual Class Class(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Token classToken;
        
        
        classToken = this.Token(this.Keyword.Class, this.IndexRange(range.Start));




        if (this.NullToken(classToken))
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







        Token colon;


        colon = this.Token(this.Delimiter.BaseSign, this.IndexRange(nameRange.End));




        if (this.NullToken(colon))
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






        Token leftBrace;


        leftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(baseRange.End));



        if (this.NullToken(leftBrace))
        {
            return null;
        }





        Token rightBrace;


        rightBrace = this.TokenMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));



        if (this.NullToken(rightBrace))
        {
            return null;
        }




        if (!this.Zero(this.Count(this.Range(rightBrace.Range.End, range.End))))
        {
            return null;
        }






        ClassName name;



        name = this.ClassName(nameRange);




        if (this.Null(name))
        {
            this.Error(this.ErrorKind.NameInvalid, range);
        }





        ClassName varBase;



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






        Class ret;


        ret = new Class();


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






        Token leftBrace;



        leftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(nameRange.End));





        if (this.NullToken(leftBrace))
        {
            return null;
        }





        Token rightBrace;



        rightBrace = this.TokenMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));





        if (this.NullToken(rightBrace))
        {
            return null;
        }






        if (!this.Zero(this.Count(this.Range(rightBrace.Range.End, range.End))))
        {
            return null;
        }






        if (this.Zero(this.Count(this.Range(leftBrace.Range.End, rightBrace.Range.Start))))
        {
            return null;
        }






        Token getToken;



        getToken = this.Token(this.Keyword.Get, this.IndexRange(leftBrace.Range.End));




        if (this.NullToken(getToken))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(getToken.Range.End, rightBrace.Range.Start))))
        {
            return null;
        }





        Token getLeftBrace;



        getLeftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(getToken.Range.End));





        if (this.NullToken(getLeftBrace))
        {
            return null;
        }






        Token getRightBrace;



        getRightBrace = this.TokenMatchLeftBrace(this.Range(getLeftBrace.Range.End, rightBrace.Range.Start));





        if (this.NullToken(getRightBrace))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(getRightBrace.Range.End, rightBrace.Range.Start))))
        {
            return null;
        }





        Token setToken;



        setToken = this.Token(this.Keyword.Set, this.IndexRange(getRightBrace.Range.End));





        if (this.NullToken(setToken))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(setToken.Range.End, rightBrace.Range.Start))))
        {
            return null;
        }





        Token setLeftBrace;



        setLeftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(setToken.Range.End));





        if (this.NullToken(setLeftBrace))
        {
            return null;
        }





        Token setRightBrace;



        setRightBrace = this.TokenMatchLeftBrace(this.Range(setLeftBrace.Range.End, rightBrace.Range.Start));





        if (this.NullToken(setRightBrace))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(setRightBrace.Range.End, rightBrace.Range.Start))))
        {
            return null;
        }







        Access access;



        access = this.Access(accessRange);




        if (this.Null(access))
        {
            this.Error(this.ErrorKind.AccessInvalid, range);
        }





        ClassName varClass;



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
        

        ret.Get = varGet;
        

        ret.Set = varSet;
        

        ret.Access = access;


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






        Token leftBracket;



        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(nameRange.End));




        if (this.NullToken(leftBracket))
        {
            return null;
        }





        Token rightBracket;



        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));




        if (this.NullToken(rightBracket))
        {
            return null;
        }






        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }






        Token leftBrace;



        leftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));




        if (this.NullToken(leftBrace))
        {
            return null;
        }





        Token rightBrace;



        rightBrace = this.TokenMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));




        if (this.NullToken(rightBrace))
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





        ClassName varClass;



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
        

        ret.Class = varClass;


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









        ClassName varClass;



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
            ret = this.LocalAccess(range);
        }
        




        if (this.Null(ret))
        {
            ret = this.DeriveAccess(range);
        }

        



        if (this.Null(ret))
        {
            ret = this.PrivateAccess(range);
        }





        return ret;
    }






    protected virtual PublicAccess PublicAccess(Range range)
    {
        Token publicToken;



        publicToken = this.Token(this.Keyword.Public, range);




        if (this.NullToken(publicToken))
        {
            return null;
        }





        PublicAccess ret;


        ret = new PublicAccess();


        ret.Init();


        this.NodeInfo(ret, range);


        return ret;
    }





    protected virtual LocalAccess LocalAccess(Range range)
    {
        Token localToken;



        localToken = this.Token(this.Keyword.Local, range);




        if (this.NullToken(localToken))
        {
            return null;
        }





        LocalAccess ret;


        ret = new LocalAccess();


        ret.Init();


        this.NodeInfo(ret, range);


        return ret;
    }






    protected virtual DeriveAccess DeriveAccess(Range range)
    {
        Token deriveToken;



        deriveToken = this.Token(this.Keyword.Derive, range);




        if (this.NullToken(deriveToken))
        {
            return null;
        }





        DeriveAccess ret;


        ret = new DeriveAccess();


        ret.Init();


        this.NodeInfo(ret, range);


        return ret;
    }








    protected virtual PrivateAccess PrivateAccess(Range range)
    {
        Token privateToken;



        privateToken = this.Token(this.Keyword.Private, range);




        if (this.NullToken(privateToken))
        {
            return null;
        }





        PrivateAccess ret;


        ret = new PrivateAccess();


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




        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(lastIndex));



        if (this.NullToken(semicolon))
        {
            return null;
        }




        Express express;
        
        

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


    



    protected virtual Express Express(Range range)
    {
        Express ret;



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


        L(this.GlobalExpress);


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
        Token thisToken;




        thisToken = this.Token(this.Keyword.This, range);





        if (this.NullToken(thisToken))
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
        Token baseToken;



        baseToken = this.Token(this.Keyword.Base, range);




        if (this.NullToken(baseToken))
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




        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(lastIndex));



        if (this.NullToken(semicolon))
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




        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(lastIndex));



        if (this.NullToken(semicolon))
        {
            return null;
        }






        Token colon;



        colon = this.TokenForward(this.Delimiter.BaseSign, this.Range(range.Start, semicolon.Range.Start));




        if (this.NullToken(colon))
        {
            return null;
        }
        





        Target target;


        target = this.Target(this.Range(range.Start, colon.Range.Start));
        


        if (this.Null(target))
        {
            this.Error(this.ErrorKind.TargetInvalid, range);
        }




        Express value;


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




        Token newToken;


        newToken = this.Token(this.Keyword.New, this.IndexRange(range.Start));

        

        if (this.NullToken(newToken))
        {
            return null;
        }




        ClassName varClass;
        
        
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






    protected virtual GlobalExpress GlobalExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Token globalToken;


        globalToken = this.Token(this.Keyword.Global, this.IndexRange(range.Start));

        

        if (this.NullToken(globalToken))
        {
            return null;
        }




        ClassName varClass;
        
        
        varClass = this.ClassName(this.Range(globalToken.Range.End, range.End));
            


        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassInvalid, range);
        }




        GlobalExpress ret;
        

        ret = new GlobalExpress();


        ret.Init();

        
        ret.Class = varClass;
        
        
        this.NodeInfo(ret, range);
        

        return ret;
    }







    private AndExpress AndExpress(Range range)
    {
        Token op;



        op = this.TokenBackward(this.Delimiter.AndSign, range);




        if (this.NullToken(op))
        {
            return null;
        }




        bool hasOperandInvalid;



        hasOperandInvalid = false;





        Express left;
        


        left = this.Express(this.Range(range.Start, op.Range.Start));
            


        if (this.Null(left))
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }




        Express right;
        
        

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
        Token op;



        op = this.TokenBackward(this.Delimiter.OrnSign, range);




        if (this.NullToken(op))
        {
            return null;
        }





        bool hasOperandInvalid;



        hasOperandInvalid = false;





        Express left;
        
        

        left = this.Express(this.Range(range.Start, op.Range.Start));
            



        if (left == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }





        Express right;
        
        

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




        Token op;



        op = this.Token(this.Delimiter.NotSign, this.IndexRange(range.Start));




        if (this.NullToken(op))
        {
            return null;
        }




        Express varBool;
        
        

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
        Token op;
        


        op = this.TokenBackward(this.Delimiter.AddSign, range);




        if (this.NullToken(op))
        {
            return null;
        }




        bool hasOperandInvalid;



        hasOperandInvalid = false;




        Express left;



        left = this.Express(this.Range(range.Start, op.Range.Start));

        
        

        if (left == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }





        Express right;
        
        


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
        Token op;




        op = this.TokenBackward(this.Delimiter.SubSign, range);





        if (this.NullToken(op))
        {
            return null;
        }




        bool hasOperandInvalid;




        hasOperandInvalid = false;




        Express left;
        
        


        left = this.Express(this.Range(range.Start, op.Range.Start));




        if (left == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }





        Express right;
        



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
        Token op;



        op = this.TokenBackward(this.Delimiter.MulSign, range);




        if (this.NullToken(op))
        {
            return null;
        }





        bool hasOperandInvalid;



        hasOperandInvalid = false;





        Express left;
        



        left = this.Express(this.Range(range.Start, op.Range.Start));
            



        if (left == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }





        Express right;
        



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
        Token op;




        op = this.TokenBackward(this.Delimiter.DivSign, range);




        if (this.NullToken(op))
        {
            return null;
        }




        bool hasOperandInvalid;

        hasOperandInvalid = false;




        Express left;
            
        left = this.Express(this.Range(range.Start, op.Range.Start));
            

        if (left == null)
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }



        Express right;
                        
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
        Token op;



        op = this.TokenBackward(this.Delimiter.EqualSign, range);




        if (this.NullToken(op))
        {
            return null;
        }




        bool hasOperandInvalid;

        hasOperandInvalid = false;




        Express left;
            
        left = this.Express(this.Range(range.Start, op.Range.Start));
            

        if (this.Null(left))
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }



        Express right;
            
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
        Token op;
        

        op = this.TokenBackward(this.Delimiter.LessSign, range);




        if (this.NullToken(op))
        {
            return null;
        }




        bool hasOperandInvalid;

        hasOperandInvalid = false;




        Express left;
        

        left = this.Express(this.Range(range.Start, op.Range.Start));
        

        if (this.Null(left))
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }



        Express right;
        

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
        Token op;
        



        op = this.TokenBackward(this.Delimiter.JoinSign, range);




        if (this.NullToken(op))
        {
            return null;
        }




        bool hasOperandInvalid;

        hasOperandInvalid = false;




        Express left;
            
        left = this.Express(this.Range(range.Start, op.Range.Start));
            

        if (this.Null(left))
        {
            this.UniqueError(this.ErrorKind.OperandInvalid, range, ref hasOperandInvalid);
        }



        Express right;
            
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
        Token dot;
        


        dot = this.TokenBackward(this.Delimiter.StopSign, range);




        if (this.NullToken(dot))
        {
            return null;
        }




        Express varThis;




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





        Token rightBracket;
        


        rightBracket = this.Token(this.Delimiter.RightBracket, this.IndexRange(range.End - 1));




        if (this.NullToken(rightBracket))
        {
            return null;
        }




        Token leftBracket;
        
        

        leftBracket = this.TokenMatchRightBracket(this.Range(range.Start, rightBracket.Range.Start));




        if (this.NullToken(leftBracket))
        {
            return null;
        }





        Token dot;
        


        dot = this.TokenBackward(this.Delimiter.StopSign, this.Range(range.Start, leftBracket.Range.Start));
            



        if (this.NullToken(dot))
        {
            return null;
        }





        Express varThis;
            
        
        
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




        Token ifToken;
        
        
        ifToken = this.Token(this.Keyword.If, this.IndexRange(range.Start));



        if (this.NullToken(ifToken))
        {
            return null;
        }




        if (this.Zero(this.Count(this.Range(ifToken.Range.End, range.End))))
        {
            return null;
        }




        Token leftBracket;
        
        

        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(ifToken.Range.End));



        if (this.NullToken(leftBracket))
        {
            return null;
        }





        Token rightBracket;
        
        

        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));




        if (this.NullToken(rightBracket))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }




        Token leftBrace;


        leftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));



        if (this.NullToken(leftBrace))
        {
            return null;
        }




        Token rightBrace;
        
        
        rightBrace = this.TokenMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));



        if (this.NullToken(rightBrace))
        {
            return null;
        }




        if (!this.Zero(this.Count(this.Range(rightBrace.Range.End, range.End))))
        {
            return null;
        }


            


        Express cond;

        
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




        Token whileToken;
        

        whileToken = this.Token(this.Keyword.While, this.IndexRange(range.Start));



        if (this.NullToken(whileToken))
        {
            return null;
        }




        if (this.Zero(this.Count(this.Range(whileToken.Range.End, range.End))))
        {
            return null;
        }




        Token leftBracket;
        
        
        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(whileToken.Range.End));



        if (this.NullToken(leftBracket))
        {
            return null;
        }



        Token rightBracket;
        
        
        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));



        if (this.NullToken(rightBracket))
        {
            return null;
        }



        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }




        Token leftBrace;
        
        
        leftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));



        if (this.NullToken(leftBrace))
        {
            return null;
        }



        Token rightBrace;
        
        
        rightBrace = this.TokenMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));
            


        if (this.NullToken(rightBrace))
        {
            return null;
        }




        if (!this.Zero(this.Count(this.Range(rightBrace.Range.End, range.End))))
        {
            return null;
        }




        Express cond;
        
        
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




        Token returnToken;
        

        returnToken = this.Token(this.Keyword.Return, this.IndexRange(range.Start));



        if (this.NullToken(returnToken))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(returnToken.Range.End, range.End))))
        {
            return null;
        }




        int lastIndex;


        lastIndex = range.End - 1;




        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(lastIndex));



        if (this.NullToken(semicolon))
        {
            return null;
        }






        Express result;


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





        Token castToken;


        castToken = this.Token(this.Keyword.Cast, this.IndexRange(range.Start));




        if (this.NullToken(castToken))
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





        Token leftBracket;


        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(classRange.End));




        if (this.NullToken(leftBracket))
        {
            return null;
        }





        Token rightBracket;


        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));



        if (this.NullToken(rightBracket))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }







        ClassName varClass;


        varClass = this.ClassName(classRange);




        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassInvalid, range);
        }





        Express varObject;


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




        Token leftBracket;
        
        
        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(range.Start));




        if (this.NullToken(leftBracket))
        {
            return null;
        }





        Token rightBracket;


        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));



        if (this.NullToken(rightBracket))
        {
            return null;
        }




        if (!this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }





        Express express;


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
        Token nullToken;
        


        nullToken = this.Token(this.Keyword.Null, range);




        if (this.NullToken(nullToken))
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
        Express express;

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
        Token dot;
        


        dot = this.TokenBackward(this.Delimiter.StopSign, range);




        if (this.NullToken(dot))
        {
            return null;
        }




        Express varThis;
        
        

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






        NullableBool o;


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
            if (this.TextInfra.Equal(s.Row, s.Range, this.Keyword.False))
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



        value = this.TextInfra.Value(s.Row, s.Range);




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








    protected ClassName ClassName(Range range)
    {
        string value;

        value = this.NameValue(range);


        if (this.Null(value))
        {
            return null;
        }


        ClassName ret;
        
        ret = new ClassName();

        ret.Init();
        
        ret.Value = value;
        
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
        
        ret.Value = value;
        
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
        
        ret.Value = value;
        
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
        
        ret.Value = value;
        
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
                    Token delimiterToken;


                    delimiterToken = this.Token(delimiter, this.IndexRange(currentRange.Start));



                    if (this.NullToken(delimiterToken))
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





        Token returnToken;
        

        returnToken = this.Token(this.Keyword.Return, this.IndexRange(range.Start));



        if (this.NullToken(returnToken))
        {
            return this.RangeNull;
        }





        Token semicolon;



        semicolon = this.TokenForward(this.Delimiter.StateSign, this.Range(returnToken.Range.End, range.End));



        if (this.NullToken(semicolon))
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




        Token ifToken;
        
        
        ifToken = this.Token(this.Keyword.If, this.IndexRange(range.Start));



        if (this.NullToken(ifToken))
        {
            return this.RangeNull;
        }




        if (this.Zero(this.Count(this.Range(ifToken.Range.End, range.End))))
        {
            return this.RangeNull;
        }




        Token leftBracket;
        
        

        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(ifToken.Range.End));



        if (this.NullToken(leftBracket))
        {
            return this.RangeNull;
        }





        Token rightBracket;
        
        

        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));




        if (this.NullToken(rightBracket))
        {
            return this.RangeNull;
        }





        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return this.RangeNull;
        }




        Token leftBrace;


        leftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));



        if (this.NullToken(leftBrace))
        {
            return this.RangeNull;
        }




        Token rightBrace;
        
        
        rightBrace = this.TokenMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));



        if (this.NullToken(rightBrace))
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




        Token whileToken;
        
        
        whileToken = this.Token(this.Keyword.While, this.IndexRange(range.Start));



        if (this.NullToken(whileToken))
        {
            return this.RangeNull;
        }




        if (this.Zero(this.Count(this.Range(whileToken.Range.End, range.End))))
        {
            return this.RangeNull;
        }




        Token leftBracket;
        
        

        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(whileToken.Range.End));



        if (this.NullToken(leftBracket))
        {
            return this.RangeNull;
        }





        Token rightBracket;
        
        

        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));




        if (this.NullToken(rightBracket))
        {
            return this.RangeNull;
        }





        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return this.RangeNull;
        }




        Token leftBrace;


        leftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));



        if (this.NullToken(leftBrace))
        {
            return this.RangeNull;
        }




        Token rightBrace;
        
        
        rightBrace = this.TokenMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));



        if (this.NullToken(rightBrace))
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




        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(varRange.End));



        if (this.NullToken(semicolon))
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
        Token semicolon;



        semicolon = this.TokenForward(this.Delimiter.StateSign, range);




        if (this.NullToken(semicolon))
        {
            return this.RangeNull;
        }





        Token colon;



        colon = this.TokenForward(this.Delimiter.BaseSign, this.Range(range.Start, semicolon.Range.Start));




        if (this.NullToken(colon))
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
        Token semicolon;
        

        semicolon = this.TokenForward(this.Delimiter.StateSign, range);
        



        if (this.NullToken(semicolon))
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
        Token comma;
            

        comma = this.TokenForward(this.Delimiter.PauseSign, range);
        
        


        if (this.NullToken(comma))
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






        Token leftBrace;



        leftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(nameRange.End));





        if (this.NullToken(leftBrace))
        {
            return this.RangeNull;
        }





        Token rightBrace;



        rightBrace = this.TokenMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));





        if (this.NullToken(rightBrace))
        {
            return this.RangeNull;
        }







        if (this.Zero(this.Count(this.Range(leftBrace.Range.End, rightBrace.Range.Start))))
        {
            return this.RangeNull;
        }






        Token getToken;



        getToken = this.Token(this.Keyword.Get, this.IndexRange(leftBrace.Range.End));




        if (this.NullToken(getToken))
        {
            return this.RangeNull;
        }





        if (this.Zero(this.Count(this.Range(getToken.Range.End, rightBrace.Range.Start))))
        {
            return this.RangeNull;
        }





        Token getLeftBrace;



        getLeftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(getToken.Range.End));





        if (this.NullToken(getLeftBrace))
        {
            return this.RangeNull;
        }






        Token getRightBrace;



        getRightBrace = this.TokenMatchLeftBrace(this.Range(getLeftBrace.Range.End, rightBrace.Range.Start));





        if (this.NullToken(getRightBrace))
        {
            return this.RangeNull;
        }





        if (this.Zero(this.Count(this.Range(getRightBrace.Range.End, rightBrace.Range.Start))))
        {
            return this.RangeNull;
        }





        Token setToken;



        setToken = this.Token(this.Keyword.Set, this.IndexRange(getRightBrace.Range.End));





        if (this.NullToken(setToken))
        {
            return this.RangeNull;
        }





        if (this.Zero(this.Count(this.Range(setToken.Range.End, rightBrace.Range.Start))))
        {
            return this.RangeNull;
        }





        Token setLeftBrace;



        setLeftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(setToken.Range.End));





        if (this.NullToken(setLeftBrace))
        {
            return this.RangeNull;
        }





        Token setRightBrace;



        setRightBrace = this.TokenMatchLeftBrace(this.Range(setLeftBrace.Range.End, rightBrace.Range.Start));





        if (this.NullToken(setRightBrace))
        {
            return this.RangeNull;
        }





        if (!this.Zero(this.Count(this.Range(setRightBrace.Range.End, rightBrace.Range.Start))))
        {
            return this.RangeNull;
        }






        Range t;

        t = this.Range(range.Start, rightBrace.Range.End);




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






        Token leftBracket;



        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(nameRange.End));




        if (this.NullToken(leftBracket))
        {
            return this.RangeNull;
        }





        Token rightBracket;



        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));




        if (this.NullToken(rightBracket))
        {
            return this.RangeNull;
        }






        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return this.RangeNull;
        }






        Token leftBrace;



        leftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));




        if (this.NullToken(leftBrace))
        {
            return this.RangeNull;
        }





        Token rightBrace;



        rightBrace = this.TokenMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));




        if (this.NullToken(rightBrace))
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


        token = this.Code.Token.Get(index);
            

        return token.Range;
    }






    protected int Count(Range range)
    {
        return this.RangeInfra.Count(range);
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


            s = (string)iter.Value;



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
            throw new Exception("Compile Node Info New Id Cannot Increment Further");
        }



        this.NewId = this.NewId + 1;




        return true;
    }



    private ulong NewId { get; set; }




    private bool IsToken(string value, int index)
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






    protected bool NullToken(Token token)
    {
        return this.NullRange(token.Range);
    }






    protected bool NullRange(Range range)
    {
        return range.Start == IntNull;
    }








    protected bool Null(object o)
    {
        return o == null;
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



    protected Token Token(string value, Range range)
    {
        if (!(this.Count(range) == 1))
        {
            return this.TokenNull;
        }



        if (!this.IsToken(value, range.Start))
        {
            return this.TokenNull;
        }




        Token ret;
        
        
        ret = new Token();
        
        
        ret.Range = range;


        return ret;
    }





    protected Token TokenBackward(string value, Range range)
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


                if (this.IsToken(value, j))
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
            return this.TokenNull;
        }




        Token ret;

        ret = new Token();

        ret.Range = this.IndexRange(index);

        return ret;
    }





    protected Token TokenForward(string value, Range range)
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
                if (this.IsToken(value, i))
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
            return this.TokenNull;
        }




        Token ret;
            
        ret = new Token();

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
            Token rightBracket;

            rightBracket = this.TokenMatchLeftBracket(this.Range(index + 1, range.End));
                

            if (this.NullToken(rightBracket))
            {
                return ret;
            }


            ret = rightBracket.Range.End;
        }
        else if (this.TextInfra.Equal(s.Row, s.Range, this.Delimiter.LeftBrace))
        {
            Token rightBrace;

            rightBrace = this.TokenMatchLeftBrace(this.Range(index + 1, range.End));


            if (this.NullToken(rightBrace))
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
            Token leftBracket;

            leftBracket = this.TokenMatchRightBracket(this.Range(range.Start, t));


            if (this.NullToken(leftBracket))
            {
                return ret;
            }


            ret = leftBracket.Range.Start;
        }
        else if (this.TextInfra.Equal(s.Row, s.Range, this.Delimiter.RightBrace))
        {
            Token leftBrace;

            leftBrace = this.TokenMatchRightBrace(this.Range(range.Start, t));


            if (this.NullToken(leftBrace))
            {
                return ret;
            }


            ret = leftBrace.Range.Start;
        }
        


        return ret;
    }



    protected Token TokenMatchLeftBrace(Range range)
    {   
        return this.TokenMatchLeftToken(this.Delimiter.LeftBrace, this.Delimiter.RightBrace, range);
    }


    protected Token TokenMatchRightBrace(Range range)
    {
        return this.TokenMatchRightToken(this.Delimiter.LeftBrace, this.Delimiter.RightBrace, range);
    }


    protected Token TokenMatchLeftBracket(Range range)
    {
        return this.TokenMatchLeftToken(this.Delimiter.LeftBracket, this.Delimiter.RightBracket, range);
    }


    protected Token TokenMatchRightBracket(Range range)
    {
        return this.TokenMatchRightToken(this.Delimiter.LeftBracket, this.Delimiter.RightBracket, range);
    }



    private Token TokenMatchLeftToken(string leftToken, string rightToken, Range range)
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
            return this.TokenNull;
        }



        Token ret;

        ret = new Token();

        ret.Init();

        ret.Range = this.IndexRange(index);

        return ret;
    }




    private Token TokenMatchRightToken(string leftToken, string rightToken, Range range)
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
            return this.TokenNull;
        }



        Token ret;
            
        ret = new Token();

        ret.Init();

        ret.Range = this.IndexRange(index);

        return ret;
    }
}