namespace Class.Check;





public class Traverse
{
    public virtual bool Init()
    {
        this.Refer = this.Compile.Refer;




        this.ErrorKinds = this.Compile.ErrorKinds;



        this.Access = this.Compile.Access;




        return true;
    }





    public virtual Compile Compile
    {
        get; set;
    }




    protected Refer Refer { get; set; }





    protected ErrorKinds ErrorKinds { get; set; }





    protected AccessList Access { get; set; }





    public Source Source { get; set; }





    public virtual bool ExecuteClass(NodeClass nodeClass)
    {
        if (this.Null(nodeClass))
        {
            return true;
        }




        this.ExecuteNode(nodeClass);




        this.ExecuteClassName(nodeClass.Name);



        this.ExecuteClassName(nodeClass.Base);



        this.ExecuteMemberList(nodeClass.Member);



        return true;
    }




    public virtual bool ExecuteClassName(ClassName className)
    {
        if (this.Null(className))
        {
            return true;
        }



        this.ExecuteNode(className);



        return true;
    }





    public virtual bool ExecuteMemberList(MemberList memberList)
    {
        if (this.Null(memberList))
        {
            return true;
        }



        this.ExecuteNode(memberList);




        ListIter iter;


        iter = memberList.Value.Iter();



        while (iter.Next())
        {
            Member member;


            member = (Member)iter.Value;



            this.ExecuteMember(member);
        }



        return true;
    }




    public virtual bool ExecuteMember(Member member)
    {
        if (this.Null(member))
        {
            return true;
        }




        if (member is NodeField)
        {
            this.ExecuteField((NodeField)member);
        }
        
        

        if (member is NodeMethod)
        {
            this.ExecuteMethod((NodeMethod)member);
        }
        



        return true;
    }




    public virtual bool ExecuteField(NodeField field)
    {
        if (this.Null(field))
        {
            return true;
        }




        this.ExecuteNode(field);







        this.ExecuteAccess(field.Access);




        this.ExecuteClassName(field.Class);




        this.ExecuteFieldName(field.Name);




        this.ExecuteStateList(field.Get);




        this.ExecuteStateList(field.Set);





        return true;
    }




    public virtual bool ExecuteFieldName(FieldName fieldName)
    {
        if (this.Null(fieldName))
        {
            return true;
        }




        this.ExecuteNode(fieldName);




        return true;
    }




    public virtual bool ExecuteMethod(NodeMethod method)
    {
        if (this.Null(method))
        {
            return true;
        }




        this.ExecuteNode(method);





        this.ExecuteAccess(method.Access);


        this.ExecuteClassName(method.Class);


        this.ExecuteMethodName(method.Name);


        this.ExecuteParamList(method.Param);


        this.ExecuteStateList(method.Call);




        return true;
    }





    public virtual bool ExecuteMethodName(MethodName methodName)
    {
        if (this.Null(methodName))
        {
            return true;
        }




        this.ExecuteNode(methodName);




        return true;
    }





    public virtual bool ExecuteParamList(ParamList paramList)
    {
        if (this.Null(paramList))
        {
            return true;
        }




        this.ExecuteNode(paramList);





        ListIter iter;


        iter = paramList.Value.Iter();



        while (iter.Next())
        {
            Param param;


            param = (Param)iter.Value;



            this.ExecuteParam(param);
        }




        return true;
    }





    public virtual bool ExecuteParam(Param param)
    {
        if (this.Null(param))
        {
            return true;
        }




        this.ExecuteNode(param);




        this.ExecuteVar(param.Var);




        return true;
    }





    public virtual bool ExecuteAccess(NodeAccess access)
    {
        if (this.Null(access))
        {
            return true;
        }




        if (access is PublicAccess)
        {
            this.ExecutePublicAccess((PublicAccess)access);
        }
        
        

        if (access is LocalAccess)
        {
            this.ExecuteLocalAccess((LocalAccess)access);
        }



        if (access is DeriveAccess)
        {
            this.ExecuteDeriveAccess((DeriveAccess)access);
        }


        
        if (access is PrivateAccess)
        {
            this.ExecutePrivateAccess((PrivateAccess)access);
        }




        return true;
    }





    public virtual bool ExecutePublicAccess(PublicAccess publicAccess)
    {
        if (this.Null(publicAccess))
        {
            return true;
        }




        this.ExecuteNode(publicAccess);




        return true;
    }






    public virtual bool ExecuteLocalAccess(LocalAccess localAccess)
    {
        if (this.Null(localAccess))
        {
            return true;
        }




        this.ExecuteNode(localAccess);




        return true;
    }





    public virtual bool ExecuteDeriveAccess(DeriveAccess deriveAccess)
    {
        if (this.Null(deriveAccess))
        {
            return true;
        }




        this.ExecuteNode(deriveAccess);




        return true;
    }





    public virtual bool ExecutePrivateAccess(PrivateAccess privateAccess)
    {
        if (this.Null(privateAccess))
        {
            return true;
        }




        this.ExecuteNode(privateAccess);




        return true;
    }

        



    public virtual bool ExecuteStateList(StateList stateList)
    {
        if (this.Null(stateList))
        {
            return true;
        }





        this.ExecuteNode(stateList);






        ListIter iter;


        iter = stateList.Value.Iter();



        while (iter.Next())
        {
            State state;


            state = (State)iter.Value;



            this.ExecuteState(state);
        }




        return true;
    }






    public virtual bool ExecuteState(State state)
    {
        if (this.Null(state))
        {
            return true;
        }




        if (state is ReturnState)
        {
            this.ExecuteReturnState((ReturnState)state);
        }



        if (state is IfState)
        {
            this.ExecuteIfState((IfState)state);
        }



        if (state is WhileState)
        {
            this.ExecuteWhileState((WhileState)state);
        }




        if (state is DeclareState)
        {
            this.ExecuteDeclareState((DeclareState)state);
        }




        if (state is AssignState)
        {
            this.ExecuteAssignState((AssignState)state);
        }




        if (state is ExpressState)
        {
            this.ExecuteExpressState((ExpressState)state);
        }



        return true;
    }






    public virtual bool ExecuteExpressState(ExpressState expressState)
    {
        if (this.Null(expressState))
        {
            return true;
        }




        this.ExecuteNode(expressState);




        this.ExecuteExpress(expressState.Express);




        return true;
    }





    public virtual bool ExecuteExpress(Express express)
    {
        if (this.Null(express))
        {
            return true;
        }




        if (express is ThisExpress)
        {
            this.ExecuteThisExpress((ThisExpress)express);
        }



        if (express is BaseExpress)
        {
            this.ExecuteBaseExpress((BaseExpress)express);
        }



        if (express is NewExpress)
        {
            this.ExecuteNewExpress((NewExpress)express);
        }



        if (express is GlobalExpress)
        {
            this.ExecuteGlobalExpress((GlobalExpress)express);
        }



        if (express is BracketExpress)
        {
            this.ExecuteBracketExpress((BracketExpress)express);
        }



        if (express is AndExpress)
        {
            this.ExecuteAndExpress((AndExpress)express);
        }



        if (express is OrnExpress)
        {
            this.ExecuteOrnExpress((OrnExpress)express);
        }



        if (express is NotExpress)
        {
            this.ExecuteNotExpress((NotExpress)express);
        }



        if (express is AddExpress)
        {
            this.ExecuteAddExpress((AddExpress)express);
        }



        if (express is SubExpress)
        {
            this.ExecuteSubExpress((SubExpress)express);
        }



        if (express is MulExpress)
        {
            this.ExecuteMulExpress((MulExpress)express);
        }



        if (express is DivExpress)
        {
            this.ExecuteDivExpress((DivExpress)express);
        }



        if (express is EqualExpress)
        {
            this.ExecuteEqualExpress((EqualExpress)express);
        }



        if (express is LessExpress)
        {
            this.ExecuteLessExpress((LessExpress)express);
        }



        if (express is JoinExpress)
        {
            this.ExecuteJoinExpress((JoinExpress)express);
        }



        if (express is GetExpress)
        {
            this.ExecuteGetExpress((GetExpress)express);
        }



        if (express is CallExpress)
        {
            this.ExecuteCallExpress((CallExpress)express);
        }



        if (express is CastExpress)
        {
            this.ExecuteCastExpress((CastExpress)express);
        }



        if (express is NullExpress)
        {
            this.ExecuteNullExpress((NullExpress)express);
        }



        if (express is VarExpress)
        {
            this.ExecuteVarExpress((VarExpress)express);
        }



        if (express is ConstantExpress)
        {
            this.ExecuteConstantExpress((ConstantExpress)express);
        }
        



        return true;
    }





    public virtual bool ExecuteThisExpress(ThisExpress thisExpress)
    {
        if (this.Null(thisExpress))
        {
            return true;
        }




        this.ExecuteNode(thisExpress);




        return true;
    }





    public virtual bool ExecuteBaseExpress(BaseExpress baseExpress)
    {
        if (this.Null(baseExpress))
        {
            return true;
        }




        this.ExecuteNode(baseExpress);




        return true;
    }






    public virtual bool ExecuteDeclareState(DeclareState declareState)
    {
        if (this.Null(declareState))
        {
            return true;
        }




        this.ExecuteNode(declareState);




        this.ExecuteVar(declareState.Var);




        return true;
    }






    public virtual bool ExecuteAssignState(AssignState assignState)
    {
        if (this.Null(assignState))
        {
            return true;
        }





        this.ExecuteNode(assignState);





        this.ExecuteTarget(assignState.Target);




        this.ExecuteExpress(assignState.Value);




        return true;
    }






    public virtual bool ExecuteNewExpress(NewExpress newExpress)
    {
        if (this.Null(newExpress))
        {
            return true;
        }




        this.ExecuteNode(newExpress);

        


        this.ExecuteClassName(newExpress.Class);



        return true;
    }





    public virtual bool ExecuteGlobalExpress(GlobalExpress globalExpress)
    {
        if (this.Null(globalExpress))
        {
            return true;
        }




        this.ExecuteNode(globalExpress);

            


        this.ExecuteClassName(globalExpress.Class);



        return true;
    }





    public virtual bool ExecuteBracketExpress(BracketExpress bracketExpress)
    {
        if (this.Null(bracketExpress))
        {
            return true;
        }




        this.ExecuteNode(bracketExpress);

            


        this.ExecuteExpress(bracketExpress.Express);



        return true;
    }





    public virtual bool ExecuteAndExpress(AndExpress andExpress)
    {
        if (this.Null(andExpress))
        {
            return true;
        }




        this.ExecuteNode(andExpress);





        this.ExecuteExpress(andExpress.Left);




        this.ExecuteExpress(andExpress.Right);




        return true;
    }





    public virtual bool ExecuteOrnExpress(OrnExpress ornExpress)
    {
        if (this.Null(ornExpress))
        {
            return true;
        }




        this.ExecuteNode(ornExpress);




        this.ExecuteExpress(ornExpress.Left);




        this.ExecuteExpress(ornExpress.Right);




        return true;
    }





    public virtual bool ExecuteNotExpress(NotExpress notExpress)
    {
        if (this.Null(notExpress))
        {
            return true;
        }




        this.ExecuteNode(notExpress);




        this.ExecuteExpress(notExpress.Bool);




        return true;
    }





    public virtual bool ExecuteAddExpress(AddExpress addExpress)
    {
        if (this.Null(addExpress))
        {
            return true;
        }




        this.ExecuteNode(addExpress);




        this.ExecuteExpress(addExpress.Left);




        this.ExecuteExpress(addExpress.Right);




        return true;
    }






    public virtual bool ExecuteSubExpress(SubExpress subExpress)
    {
        if (this.Null(subExpress))
        {
            return true;
        }




        this.ExecuteNode(subExpress);




        this.ExecuteExpress(subExpress.Left);




        this.ExecuteExpress(subExpress.Right);




        return true;
    }






    public virtual bool ExecuteMulExpress(MulExpress mulExpress)
    {
        if (this.Null(mulExpress))
        {
            return true;
        }





        this.ExecuteNode(mulExpress);




        this.ExecuteExpress(mulExpress.Left);




        this.ExecuteExpress(mulExpress.Right);




        return true;
    }






    public virtual bool ExecuteDivExpress(DivExpress divExpress)
    {
        if (this.Null(divExpress))
        {
            return true;
        }





        this.ExecuteNode(divExpress);





        this.ExecuteExpress(divExpress.Left);





        this.ExecuteExpress(divExpress.Right);




        return true;
    }





    public virtual bool ExecuteEqualExpress(EqualExpress equalExpress)
    {
        if (this.Null(equalExpress))
        {
            return true;
        }





        this.ExecuteNode(equalExpress);





        this.ExecuteExpress(equalExpress.Left);





        this.ExecuteExpress(equalExpress.Right);





        return true;
    }





    public virtual bool ExecuteLessExpress(LessExpress lessExpress)
    {
        if (this.Null(lessExpress))
        {
            return true;
        }




        this.ExecuteNode(lessExpress);




        this.ExecuteExpress(lessExpress.Left);




        this.ExecuteExpress(lessExpress.Right);





        return true;
    }






    public virtual bool ExecuteJoinExpress(JoinExpress joinExpress)
    {
        if (this.Null(joinExpress))
        {
            return true;
        }





        this.ExecuteNode(joinExpress);




        this.ExecuteExpress(joinExpress.Left);




        this.ExecuteExpress(joinExpress.Right);





        return true;
    }






    public virtual bool ExecuteGetExpress(GetExpress getExpress)
    {
        if (this.Null(getExpress))
        {
            return true;
        }





        this.ExecuteNode(getExpress);





        this.ExecuteExpress(getExpress.This);





        this.ExecuteFieldName(getExpress.Field);





        return true;
    }






    public virtual bool ExecuteCallExpress(CallExpress callExpress)
    {
        if (this.Null(callExpress))
        {
            return true;
        }





        this.ExecuteNode(callExpress);





        this.ExecuteExpress(callExpress.This);




        this.ExecuteMethodName(callExpress.Method);




        this.ExecuteArgueList(callExpress.Argue);





        return true;
    }






    public virtual bool ExecuteIfState(IfState ifState)
    {
        if (this.Null(ifState))
        {
            return true;
        }





        this.ExecuteNode(ifState);





        this.ExecuteExpress(ifState.Cond);





        this.ExecuteStateList(ifState.Then);





        return true;
    }






    public virtual bool ExecuteWhileState(WhileState whileState)
    {
        if (this.Null(whileState))
        {
            return true;
        }





        this.ExecuteNode(whileState);





        this.ExecuteExpress(whileState.Cond);





        this.ExecuteStateList(whileState.Body);





        return true;
    }





    public virtual bool ExecuteReturnState(ReturnState returnState)
    {
        if (this.Null(returnState))
        {
            return true;
        }





        this.ExecuteNode(returnState);





        this.ExecuteExpress(returnState.Result);





        return true;
    }





    public virtual bool ExecuteCastExpress(CastExpress castExpress)
    {
        if (this.Null(castExpress))
        {
            return true;
        }





        this.ExecuteNode(castExpress);





        this.ExecuteClassName(castExpress.Class);




        this.ExecuteExpress(castExpress.Object);





        return true;
    }





    public virtual bool ExecuteNullExpress(NullExpress nullExpress)
    {
        if (this.Null(nullExpress))
        {
            return true;
        }





        this.ExecuteNode(nullExpress);





        return true;
    }







    public virtual bool ExecuteVarExpress(VarExpress varExpress)
    {
        if (this.Null(varExpress))
        {
            return true;
        }





        this.ExecuteNode(varExpress);





        this.ExecuteVarName(varExpress.Var);





        return true;
    }







    public virtual bool ExecuteConstantExpress(ConstantExpress constantExpress)
    {
        if (this.Null(constantExpress))
        {
            return true;
        }





        this.ExecuteNode(constantExpress);





        this.ExecuteConstant(constantExpress.Constant);





        return true;
    }






    public virtual bool ExecuteArgueList(ArgueList argueList)
    {
        if (this.Null(argueList))
        {
            return true;
        }





        this.ExecuteNode(argueList);





        ListIter iter;


        iter = argueList.Value.Iter();




        while (iter.Next())
        {
            Argue argue;


            argue = (Argue)iter.Value;



            this.ExecuteArgue(argue);
        }





        return true;
    }






    public virtual bool ExecuteArgue(Argue argue)
    {
        if (this.Null(argue))
        {
            return true;
        }





        this.ExecuteNode(argue);





        this.ExecuteExpress(argue.Express);





        return true;
    }







    public virtual bool ExecuteTarget(Target target)
    {
        if (this.Null(target))
        {
            return true;
        }






        if (target is VarTarget)
        {
            this.ExecuteVarTarget((VarTarget)target);
        }
        
        



        if (target is SetTarget)
        {
            this.ExecuteSetTarget((SetTarget)target);
        }
        




        return true;
    }






    public virtual bool ExecuteVarTarget(VarTarget varTarget)
    {
        if (this.Null(varTarget))
        {
            return true;
        }




        this.ExecuteNode(varTarget);




        this.ExecuteVarName(varTarget.Var);




        return true;
    }






    public virtual bool ExecuteSetTarget(SetTarget setTarget)
    {
        if (this.Null(setTarget))
        {
            return true;
        }





        this.ExecuteNode(setTarget);





        this.ExecuteExpress(setTarget.This);





        this.ExecuteFieldName(setTarget.Field);





        return true;
    }





    public virtual bool ExecuteVar(NodeVar varVar)
    {
        if (this.Null(varVar))
        {
            return true;
        }





        this.ExecuteNode(varVar);





        this.ExecuteVarName(varVar.Name);





        this.ExecuteClassName(varVar.Class);





        return true;
    }







    public virtual bool ExecuteVarName(VarName varName)
    {
        if (this.Null(varName))
        {
            return true;
        }





        this.ExecuteNode(varName);





        return true;
    }






    public virtual bool ExecuteConstant(Constant constant)
    {
        if (this.Null(constant))
        {
            return true;
        }




        if (constant is BoolConstant)
        {
            this.ExecuteBoolConstant((BoolConstant)constant);
        }
        
        


        if (constant is IntConstant)
        {
            this.ExecuteIntConstant((IntConstant)constant);
        }
        
        


        if (constant is StringConstant)
        {
            this.ExecuteStringConstant((StringConstant)constant);
        }
        



        return true;
    }






    public virtual bool ExecuteBoolConstant(BoolConstant boolConstant)
    {
        if (this.Null(boolConstant))
        {
            return true;
        }




        this.ExecuteNode(boolConstant);




        return true;
    }






    public virtual bool ExecuteIntConstant(IntConstant intConstant)
    {
        if (this.Null(intConstant))
        {
            return true;
        }




        this.ExecuteNode(intConstant);




        return true;
    }






    public virtual bool ExecuteStringConstant(StringConstant stringConstant)
    {
        if (this.Null(stringConstant))
        {
            return true;
        }





        this.ExecuteNode(stringConstant);





        return true;
    }







    protected virtual bool ExecuteNode(NodeNode node)
    {
        return true;
    }





    protected virtual Check Check(NodeNode node)
    {
        return (Check)this.Compile.Checks.Get(node);
    }




    protected Class Class(string name)
    {
        Class ret;


        ret = this.Compile.Class(name);


        return ret;
    }




    protected Access GetAccess(NodeAccess nodeAccess)
    {
        Access t;


        t = null;




        if (nodeAccess is PublicAccess)
        {
            t = this.Access.Public;
        }


        if (nodeAccess is LocalAccess)
        {
            t = this.Access.Local;
        }


        if (nodeAccess is DeriveAccess)
        {
            t = this.Access.Derive;
        }


        if (nodeAccess is PrivateAccess)
        {
            t = this.Access.Private;
        }




        Access ret;


        ret = t;


        return ret;
    }




    protected bool Null(object o)
    {
        return o == null;
    }




    protected bool UniqueError(ErrorKind kind, NodeNode node, ref bool hasAdded)
    {
        if (!hasAdded)
        {
            this.Error(kind, node);


            hasAdded = true;
        }



        return true;
    }





    protected bool Error(ErrorKind kind, NodeNode node)
    {
        this.Compile.Error(kind, node, this.Source);



        return true;
    }
}