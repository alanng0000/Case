namespace Case.Check;






public class StateTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();




        this.InitNullClass();




        this.VarStack = new VarStack();



        this.VarStack.Init();





        this.Sema = this.Create.ConstantClass;





        return true;
    }






    private bool InitNullClass()
    {
        Class c;


        c = new Class();


        c.Init();


        c.Name = null;


        c.Base = null;


        c.Field = null;


        c.Method = null;


        c.Module = null;


        c.Node = null;


        c.Source = null;


        c.Id = 0;




        this.NullClass = c;




        return true;
    }





    public Class CurrentClass { get; set; }




    public Class CurrentResultClass { get; set; }





    private bool IsFieldSet { get; set; }





    public ConstantClass Sema { get; set; }





    public VarMap Vars { get; set; }





    public VarMap StateVars { get; set; }




        
    public VarStack VarStack { get; set; }






    public override bool ExecuteClass(NodeClas varClass)
    {
        if (this.Null(varClass))
        {
            return true;
        }





        this.CurrentClass = this.Check(varClass).Class;




        if (this.Null(this.CurrentClass))
        {
            return true;
        }





        base.ExecuteClass(varClass);




        return true;
    }





    public override bool ExecuteField(NodeField nodeField)
    {
        if (this.Null(nodeField))
        {
            return true;
        }




        StateList nodeGet;

        nodeGet = nodeField.Get;




        StateList nodeSet;

        nodeSet = nodeField.Set;





        Field field;


        field = this.Check(nodeField).Field;




        if (this.Null(field))
        {
            return true;
        }





        this.FieldGet(field, nodeGet);
            




        this.FieldSet(field, nodeSet);




        return true;
    }





    private bool FieldGet(Field field, StateList nodeGet)
    {
        if (this.Null(nodeGet))
        {
            return true;
        }






        

        this.CurrentResultClass = field.Class;






        this.StateVars = field.Get;





        VarMap f;



        f = new VarMap();



        f.Init();




        this.Vars = f;






        VarMap o;



        o = new VarMap();



        o.Init();





        Var dataVar;


        dataVar = new Var();


        dataVar.Init();


        dataVar.Name = "data";


        dataVar.Class = field.Class;






        this.VarMapAdd(o, dataVar);





        this.VarMapMapAdd(this.Vars, o);






        this.VarStack.Push(o);




        this.ExecuteStateList(nodeGet);




        this.VarStack.Pop();






        this.Vars = null;





        this.StateVars = null;




        this.CurrentResultClass = null;




        return true;
    }






    private bool FieldSet(Field field, StateList nodeSet)
    {
        if (this.Null(nodeSet))
        {
            return true;
        }






        this.CurrentResultClass = this.Sema.Bool;





        this.IsFieldSet = true;





        this.StateVars = field.Set;





        VarMap f;



        f = new VarMap();



        f.Init();




        this.Vars = f;






        VarMap o;



        o = new VarMap();



        o.Init();





        Var dataVar;


        dataVar = new Var();


        dataVar.Init();


        dataVar.Name = "data";


        dataVar.Class = field.Class;






        Var valuVar;


        valuVar = new Var();


        valuVar.Init();


        valuVar.Name = "valu";


        valuVar.Class = field.Class;





        this.VarMapAdd(o, dataVar);




        this.VarMapAdd(o, valuVar);





        this.VarMapMapAdd(this.Vars, o);






        this.VarStack.Push(o);




        this.ExecuteStateList(nodeSet);




        this.VarStack.Pop();






        this.Vars = null;





        this.StateVars = null;




        this.IsFieldSet = false;




        this.CurrentResultClass = null;




        return true;
    }



        

    public override bool ExecuteMethod(NodeMethod nodeMethod)
    {
        if (this.Null(nodeMethod))
        {
            return true;
        }





        ParamList paramList;


        paramList = nodeMethod.Param;





        StateList call;


        call = nodeMethod.Call;






        Method method;


        method = this.Check(nodeMethod).Method;




        if (this.Null(method))
        {
            return true;
        }





        this.CurrentResultClass = method.Class;





        this.StateVars = method.Call;





        VarMap f;



        f = new VarMap();



        f.Init();




        this.Vars = f;
        





        VarMap o;



        o = new VarMap();



        o.Init();





        this.VarMapMapAdd(o, method.Params);




        
        this.VarMapMapAdd(this.Vars, o);







        this.VarStack.Push(o);





        this.ExecuteStateList(call);





        this.VarStack.Pop();





        this.Vars = null;





        this.StateVars = null;





        this.CurrentResultClass = null;





        return true;
    }





    public override bool ExecuteVar(NodeVar nodeVar)
    {
        if (this.Null(nodeVar))
        {
            return true;
        }





        VarName name;

        name = nodeVar.Name;




        CaseName nodeClass;

        nodeClass = nodeVar.Class;
            




        string varName;


        varName = name.Valu;
        




        string className;


        className = null;



        if (!this.Null(nodeClass))
        {
            className = nodeClass.Valu;
        }






        if (!this.Null(this.Vars.Get(varName)))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeVar);


            return true;
        }





        Class varClass;


        varClass = null;




        if (!this.Null(className))
        {
            varClass = this.Class(className);
        }

        


        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeVar);


            return true;
        }





        Var varVar;


        varVar = new Var();


        varVar.Init();


        varVar.Name = varName;


        varVar.Class = varClass;


        varVar.Node = nodeVar;





        this.VarMapAdd(this.Vars, varVar);





        this.VarMapAdd(this.VarStack.Top, varVar);





        this.VarMapAdd(this.StateVars, varVar);
        




        this.Check(nodeVar).Var = varVar;




        return true;
    }





    public override bool ExecuteStateList(StateList stateList)
    {
        if (this.Null(stateList))
        {
            return true;
        }





        VarMap vars;




        vars = new VarMap();




        vars.Init();





        this.VarStack.Push(vars);




        base.ExecuteStateList(stateList);




        this.VarStack.Pop();




        return true;
    }








    public override bool ExecuteThisExpress(ThisExpress thisExpress)
    {
        if (this.Null(thisExpress))
        {
            return true;
        }





        this.Check(thisExpress).ExpressClass = this.CurrentClass;




        return true;
    }





    public override bool ExecuteBaseExpress(BaseExpress baseExpress)
    {
        if (this.Null(baseExpress))
        {
            return true;
        }




        Class baseClass;



        baseClass = this.CurrentClass.Base;




        this.Check(baseExpress).ExpressClass = baseClass;




        return true;
    }






    public override bool ExecuteDeclareState(DeclareState declareState)
    {
        if (this.Null(declareState))
        {
            return true;
        }





        NodeVar nodeVar;
        

        nodeVar = declareState.Var;





        base.ExecuteDeclareState(declareState);





        return true;
    }





    public override bool ExecuteAssignState(AssignState assignState)
    {
        if (this.Null(assignState))
        {
            return true;
        }




        Target target;
            
        target = assignState.Target;
            
            
            
        Expre value;
            
        value = assignState.Value;





        base.ExecuteAssignState(assignState);




        Class targetClass;


        targetClass = null;


        if (! this.Null(target))
        {
            targetClass = this.Check(target).TargetClass;
        }




        Class valueClass;


        valueClass = null;


        if (! this.Null(value))
        {
            valueClass = this.Check(value).ExpressClass;
        }




        if (this.Null(targetClass))
        {
            this.Error(this.ErrorKind.TargetUndefined, assignState);
        }



        if (this.Null(valueClass))
        {
            this.Error(this.ErrorKind.ValueUndefined, assignState);
        }





        if (! this.Null(targetClass) & ! this.Null(valueClass))
        {
            if (! this.CheckClass(valueClass, targetClass))
            {
                this.Error(this.ErrorKind.ValueUnassignable, assignState);
            }
        }






        return true;
    }





    public override bool ExecuteNewExpress(NewExpress newExpress)
    {
        if (this.Null(newExpress))
        {
            return true;
        }




        CaseName nodeClass;
        

        nodeClass = newExpress.Class;





        string className;


        className = null;




        if (! this.Null(nodeClass))
        {
            className = nodeClass.Valu;
        }




        Class varClass;



        varClass = null;




        if (! this.Null(className))
        {
            varClass = this.Class(className);
        }





        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassUndefined, newExpress);
        }





        this.Check(newExpress).NewClass = varClass;



        this.Check(newExpress).ExpressClass = varClass;




        return true;
    }





    public override bool ExecuteGlobExpress(GlobExpress globExpress)
    {
        if (this.Null(globExpress))
        {
            return true;
        }




        CaseName nodeClass;
        

        nodeClass = globExpress.Class;





        string className;


        className = null;




        if (! this.Null(nodeClass))
        {
            className = nodeClass.Valu;
        }




        Class varClass;



        varClass = null;




        if (! this.Null(className))
        {
            varClass = this.Class(className);
        }





        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassUndefined, globExpress);
        }





        this.Check(globExpress).GlobClass = varClass;



        this.Check(globExpress).ExpressClass = varClass;




        return true;
    }






    public override bool ExecuteBracketExpress(BracketExpress bracketExpress)
    {
        if (this.Null(bracketExpress))
        {
            return true;
        }





        Expre express;

        express = bracketExpress.Express;





        base.ExecuteBracketExpress(bracketExpress);





        Class expressClass;

        expressClass = null;



        if (! this.Null(express))
        {
            expressClass = this.Check(express).ExpressClass;
        }



            

        this.Check(bracketExpress).ExpressClass = expressClass;




        return true;
    }







    public override bool ExecuteAndExpress(AndExpress andExpress)
    {
        if (this.Null(andExpress))
        {
            return true;
        }





        Expre left;
            
        left = andExpress.Left;



        Expre right;
            
        right = andExpress.Right;





        base.ExecuteAndExpress(andExpress);






        Class leftClass;

        leftClass = null;




        if (! this.Null(left))
        {
            leftClass = this.Check(left).ExpressClass;
        }





        Class rightClass;

        rightClass = null;




        if (! this.Null(right))
        {
            rightClass = this.Check(right).ExpressClass;
        }






        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, andExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (!this.CheckClass(leftClass, this.Sema.Bool))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, andExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, andExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (!this.CheckClass(rightClass, this.Sema.Bool))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, andExpress, ref hasOperandUnassignable);
            }
        }




        this.Check(andExpress).ExpressClass = this.Sema.Bool;




        return true;
    }
    




    public override bool ExecuteOrnExpress(OrnExpress ornExpress)
    {
        if (this.Null(ornExpress))
        {
            return true;
        }





        Expre left;

        left = ornExpress.Left;



        Expre right;

        right = ornExpress.Right;





        base.ExecuteOrnExpress(ornExpress);





        Class leftClass;

        leftClass = null;



        if (! this.Null(left))
        {
            leftClass = this.Check(left).ExpressClass;
        }



        Class rightClass;

        rightClass = null;



        if (! this.Null(right))
        {
            rightClass = this.Check(right).ExpressClass;
        }





        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, ornExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.Sema.Bool))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, ornExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, ornExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.Sema.Bool))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, ornExpress, ref hasOperandUnassignable);
            }
        }




        this.Check(ornExpress).ExpressClass = this.Sema.Bool;




        return true;
    }





    public override bool ExecuteNotExpress(NotExpress notExpress)
    {
        if (this.Null(notExpress))
        {
            return true;
        }





        Expre nodeBool;

        nodeBool = notExpress.Bool;





        base.ExecuteNotExpress(notExpress);





        Class boolClass;

        boolClass = null;



        if (! this.Null(nodeBool))
        {
            boolClass = this.Check(nodeBool).ExpressClass;
        }





        if (this.Null(boolClass))
        {
            this.Error(this.ErrorKind.OperandUndefined, notExpress);
        }




        if (! this.Null(boolClass))
        {
            if (! this.CheckClass(boolClass, this.Sema.Bool))
            {
                this.Error(this.ErrorKind.OperandUnassignable, notExpress);
            }
        }


            

        this.Check(notExpress).ExpressClass = this.Sema.Bool;




        return true;
    }






    public override bool ExecuteAddExpress(AddExpress addExpress)
    {
        if (this.Null(addExpress))
        {
            return true;
        }





        Expre left;

        left = addExpress.Left;



        Expre right;

        right = addExpress.Right;





        base.ExecuteAddExpress(addExpress);





        Class leftClass;

        leftClass = null;



        if (! this.Null(left))
        {
            leftClass = this.Check(left).ExpressClass;
        }



        Class rightClass;

        rightClass = null;



        if (! this.Null(right))
        {
            rightClass = this.Check(right).ExpressClass;
        }





        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, addExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.Sema.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, addExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, addExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.Sema.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, addExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(addExpress).ExpressClass = this.Sema.Int;




        return true;
    }






    public override bool ExecuteSubExpress(SubExpress subExpress)
    {
        if (this.Null(subExpress))
        {
            return true;
        }





        Expre left;

        left = subExpress.Left;



        Expre right;

        right = subExpress.Right;





        base.ExecuteSubExpress(subExpress);





        Class leftClass;

        leftClass = null;



        if (! this.Null(left))
        {
            leftClass = this.Check(left).ExpressClass;
        }



        Class rightClass;

        rightClass = null;



        if (! this.Null(right))
        {
            rightClass = this.Check(right).ExpressClass;
        }





        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, subExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.Sema.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, subExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, subExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.Sema.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, subExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(subExpress).ExpressClass = this.Sema.Int;




        return true;
    }





    public override bool ExecuteMulExpress(MulExpress mulExpress)
    {
        if (this.Null(mulExpress))
        {
            return true;
        }





        Expre left;

        left = mulExpress.Left;



        Expre right;

        right = mulExpress.Right;





        base.ExecuteMulExpress(mulExpress);





        Class leftClass;

        leftClass = null;



        if (! this.Null(left))
        {
            leftClass = this.Check(left).ExpressClass;
        }



        Class rightClass;

        rightClass = null;



        if (! this.Null(right))
        {
            rightClass = this.Check(right).ExpressClass;
        }





        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, mulExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.Sema.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, mulExpress, ref hasOperandUnassignable);
            }
        }





        if (rightClass == null)
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, mulExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.Sema.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, mulExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(mulExpress).ExpressClass = this.Sema.Int;




        return true;
    }





    public override bool ExecuteDivExpress(DivExpress divExpress)
    {
        if (this.Null(divExpress))
        {
            return true;
        }





        Expre left;

        left = divExpress.Left;



        Expre right;

        right = divExpress.Right;





        base.ExecuteDivExpress(divExpress);





        Class leftClass;

        leftClass = null;



        if (! this.Null(left))
        {
            leftClass = this.Check(left).ExpressClass;
        }



        Class rightClass;

        rightClass = null;



        if (! this.Null(right))
        {
            rightClass = this.Check(right).ExpressClass;
        }





        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, divExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.Sema.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, divExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, divExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.Sema.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, divExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(divExpress).ExpressClass = this.Sema.Int;




        return true;
    }





    public override bool ExecuteEqualExpress(EqualExpress equalExpress)
    {
        if (this.Null(equalExpress))
        {
            return true;
        }





        Expre left;

        left = equalExpress.Left;




        Expre right;

        right = equalExpress.Right;




        base.ExecuteEqualExpress(equalExpress);





        Class leftClass;

        leftClass = null;



        if (! this.Null(left))
        {
            leftClass = this.Check(left).ExpressClass;
        }




        Class rightClass;

        rightClass = null;



        if (! this.Null(right))
        {
            rightClass = this.Check(right).ExpressClass;
        }







        bool hasOperandUndefined;



        hasOperandUndefined = false;





        if (this.Null(leftClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, equalExpress, ref hasOperandUndefined);
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, equalExpress, ref hasOperandUndefined);
        }



        


        this.Check(equalExpress).ExpressClass = this.Sema.Bool;




        return true;
    }





    public override bool ExecuteLessExpress(LessExpress lessExpress)
    {
        if (this.Null(lessExpress))
        {
            return true;
        }





        Expre left;

        left = lessExpress.Left;



        Expre right;

        right = lessExpress.Right;





        base.ExecuteLessExpress(lessExpress);





        Class leftClass;

        leftClass = null;



        if (! this.Null(left))
        {
            leftClass = this.Check(left).ExpressClass;
        }



        Class rightClass;

        rightClass = null;



        if (! this.Null(right))
        {
            rightClass = this.Check(right).ExpressClass;
        }






        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, lessExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.Sema.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, lessExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, lessExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.Sema.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, lessExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(lessExpress).ExpressClass = this.Sema.Bool;




        return true;
    }





    public override bool ExecuteJoinExpress(JoinExpress joinExpress)
    {
        if (this.Null(joinExpress))
        {
            return true;
        }





        Expre left;

        left = joinExpress.Left;



        Expre right;

        right = joinExpress.Right;





        base.ExecuteJoinExpress(joinExpress);





        Class leftClass;

        leftClass = null;



        if (! this.Null(left))
        {
            leftClass = this.Check(left).ExpressClass;
        }



        Class rightClass;

        rightClass = null;



        if (! this.Null(right))
        {
            rightClass = this.Check(right).ExpressClass;
        }





        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, joinExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.Sema.String))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, joinExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, joinExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.Sema.String))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, joinExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(joinExpress).ExpressClass = this.Sema.String;




        return true;
    }




    public override bool ExecuteGetExpress(GetExpress getExpress)
    {
        if (this.Null(getExpress))
        {
            return true;
        }





        Expre varThis;

        varThis = getExpress.This;




        FieldName nodeField;

        nodeField = getExpress.Field;





        base.ExecuteGetExpress(getExpress);





        Class thisClass;


        thisClass = null;



        if (! this.Null(varThis))
        {
            thisClass = this.Check(varThis).ExpressClass;
        }




        string fieldName;


        fieldName = null;



        if (! this.Null(nodeField))
        {
            fieldName = nodeField.Valu;
        }




        if (this.Null(thisClass))
        {
            this.Error(this.ErrorKind.ThisUndefined, getExpress);
        }





        Field field;


        field = null;




        if (! this.Null(thisClass))
        {
            if (! this.Null(fieldName))
            {
                field = this.Field(thisClass, fieldName);
            }



            if (this.Null(field))
            {
                this.Error(this.ErrorKind.FieldUndefined, getExpress);
            }
        }





        Class expressClass;


        expressClass = null;




        if (! this.Null(field))
        {
            expressClass = field.Class;
        }




        this.Check(getExpress).GetField = field;



        this.Check(getExpress).ExpressClass = expressClass;




        return true;
    }




    public override bool ExecuteCallExpress(CallExpress callExpress)
    {
        if (this.Null(callExpress))
        {
            return true;
        }





        Expre varThis;

        varThis = callExpress.This;




        MethodName nodeMethod;

        nodeMethod = callExpress.Method;




        ArgueList argueList;

        argueList = callExpress.Argue;





        base.ExecuteCallExpress(callExpress);





        Class thisClass;


        thisClass = null;


            
        if (! this.Null(varThis))
        {
            thisClass = this.Check(varThis).ExpressClass;
        }




        string methodName;


        methodName = null;



        if (! this.Null(nodeMethod))
        {
            methodName = nodeMethod.Valu;
        }




        if (this.Null(thisClass))
        {
            this.Error(this.ErrorKind.ThisUndefined, callExpress);
        }





        Method method;


        method = null;




        if (! this.Null(thisClass))
        {
            if (! this.Null(methodName))
            {
                method = this.Method(thisClass, methodName);
            }



            if (this.Null(method))
            {
                this.Error(this.ErrorKind.MethodUndefined, callExpress);
            }
        }






        if (!this.Null(method))
        {
            if (!this.ArgueListMatch(method, argueList))
            {
                this.Error(this.ErrorKind.ArgueUnassignable, callExpress);
            }
        }





        Class expressClass;


        expressClass = null;




        if (! this.Null(method))
        {
            expressClass = method.Class;
        }




        this.Check(callExpress).CallMethod = method;



        this.Check(callExpress).ExpressClass = expressClass;




        return true;
    }








    public override bool ExecuteCastExpress(CastExpress castExpress)
    {
        if (this.Null(castExpress))
        {
            return true;
        }






        CaseName nodeClass;

        nodeClass = castExpress.Class;




        Expre nodeObject;

        nodeObject = castExpress.Object;







        base.ExecuteCastExpress(castExpress);





        Class objectClass;


        objectClass = null;



        if (!this.Null(nodeObject))
        {
            objectClass = this.Check(nodeObject).ExpressClass;
        }



        if (this.Null(objectClass))
        {
            this.Error(this.ErrorKind.ObjectUndefined, castExpress);
        }




        string className;

        className = null;



        if (!this.Null(nodeClass))
        {
            className = nodeClass.Valu;
        }




        Class varClass;

        varClass = null;


        if (!this.Null(className))
        {
            varClass = this.Class(className);
        }



        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassUndefined, castExpress);
        }





        this.Check(castExpress).CastClass = varClass;



        this.Check(castExpress).ExpressClass = varClass;




        return true;
    }





    public override bool ExecuteIfState(IfState ifState)
    {
        if (this.Null(ifState))
        {
            return true;
        }




        Expre cond;
            
        cond = ifState.Cond;



        StateList then;
        
        then = ifState.Then;





        base.ExecuteIfState(ifState);





        Class condClass;


        condClass = null;



        if (!this.Null(cond))
        {
            condClass = this.Check(cond).ExpressClass;
        }





        if (this.Null(condClass))
        {
            this.Error(this.ErrorKind.CondUndefined, ifState);
        }





        if (!this.Null(condClass))
        {
            if (!this.CheckClass(condClass, this.Sema.Bool))
            {
                this.Error(this.ErrorKind.CondUnassignable, ifState);
            }
        }






        return true;
    }





    public override bool ExecuteWhileState(WhileState whileState)
    {
        if (this.Null(whileState))
        {
            return true;
        }





        Expre cond;

        cond = whileState.Cond;



        StateList loop;

        loop = whileState.Loop;





        base.ExecuteWhileState(whileState);





        Class condClass;


        condClass = null;



        if (!this.Null(cond))
        {
            condClass = this.Check(cond).ExpressClass;
        }





        if (this.Null(condClass))
        {
            this.Error(this.ErrorKind.CondUndefined, whileState);
        }





        if (!this.Null(condClass))
        {
            if (!this.CheckClass(condClass, this.Sema.Bool))
            {
                this.Error(this.ErrorKind.CondUnassignable, whileState);
            }
        }






        return true;
    }






    public override bool ExecuteReturnState(ReturnState returnState)
    {
        if (this.Null(returnState))
        {
            return true;
        }





        Expre result;
            
        result = returnState.Result;





        base.ExecuteReturnState(returnState);




            
        Class resultClass;


        resultClass = null;




        if (! this.Null(result))
        {
            resultClass = this.Check(result).ExpressClass;
        }




        
        
        if (this.Null(resultClass))
        {
            this.Error(this.ErrorKind.ResultUndefined, returnState);
        }
        



        if (! this.Null(resultClass))
        {
            if (!this.IsFieldSet)
            {
                if (! this.CheckClass(resultClass, this.CurrentResultClass))
                {
                    this.Error(this.ErrorKind.ResultUnassignable, returnState);
                }
            }
        }





        return true;
    }





    public override bool ExecuteNullExpress(NullExpress nullExpress)
    {
        if (this.Null(nullExpress))
        {
            return true;
        }

        


        this.Check(nullExpress).ExpressClass = this.NullClass;




        return true;
    }






    public override bool ExecuteVarExpress(VarExpress varExpress)
    {
        if (this.Null(varExpress))
        {
            return true;
        }




        VarName name;


        name = varExpress.Var;




        string varName;


        varName = name.Valu;




        Var varVar;


        varVar = (Var)this.Vars.Get(varName);




        if (this.Null(varVar))
        {
            this.Error(this.ErrorKind.VarUndefined, varExpress);
        }




        Class varClass;

        varClass = null;
            

        if (! this.Null(varVar))
        {
            varClass = varVar.Class;
        }




        this.Check(varExpress).Var = varVar;



        this.Check(varExpress).ExpressClass = varClass;



        return true;
    }





    public override bool ExecuteConstantExpress(ConstantExpress constantExpress)
    {
        if (this.Null(constantExpress))
        {
            return true;
        }





        NodeConstant constant;
        

        constant = constantExpress.Constant;





        base.ExecuteConstantExpress(constantExpress);





        Class constantClass;


        constantClass = null;




        if (!this.Null(constant))
        {
            if (constant is BoolConstant)
            {
                constantClass = this.Sema.Bool;
            }

            if (constant is IntConstant)
            {
                constantClass = this.Sema.Int;
            }

            if (constant is StringConstant)
            {
                constantClass = this.Sema.String;
            }
        }




        this.Check(constantExpress).ExpressClass = constantClass;




        return true;
    }





    public override bool ExecuteVarTarget(VarTarget varTarget)
    {
        if (this.Null(varTarget))
        {
            return true;
        }




        VarName name;


        name = varTarget.Var;




        string varName;


        varName = name.Valu;




        Var varVar;


        varVar = (Var)this.Vars.Get(varName);




        if (this.Null(varVar))
        {
            this.Error(this.ErrorKind.VarUndefined, varTarget);
        }




        Class varClass;

        varClass = null;


        if (! this.Null(varVar))
        {
            varClass = varVar.Class;
        }




        this.Check(varTarget).Var = varVar;



        this.Check(varTarget).TargetClass = varClass;




        return true;
    }





    public override bool ExecuteSetTarget(SetTarget setTarget)
    {
        if (this.Null(setTarget))
        {
            return true;
        }





        Expre varThis;

        varThis = setTarget.This;




        FieldName nodeField;

        nodeField = setTarget.Field;





        base.ExecuteSetTarget(setTarget);





        Class thisClass;


        thisClass = null;



        if (! this.Null(varThis))
        {
            thisClass = this.Check(varThis).ExpressClass;
        }




        string fieldName;


        fieldName = null;



        if (! this.Null(nodeField))
        {
            fieldName = nodeField.Valu;
        }




        if (this.Null(thisClass))
        {
            this.Error(this.ErrorKind.ThisUndefined, setTarget);
        }





        Field field;


        field = null;




        if (! this.Null(thisClass))
        {
            if (! this.Null(fieldName))
            {
                field = this.Field(thisClass, fieldName);
            }



            if (this.Null(field))
            {
                this.Error(this.ErrorKind.FieldUndefined, setTarget);
            }
        }





        Class targetClass;


        targetClass = null;




        if (! this.Null(field))
        {
            targetClass = field.Class;
        }




        this.Check(setTarget).SetField = field;



        this.Check(setTarget).TargetClass = targetClass;



        return true;
    }







    protected bool CheckClass(Class varClass, Class requiredClass)
    {
        Class currentClass;



        currentClass = varClass;




        bool b;



        b = false;



        while (!b & !this.Null(currentClass))
        {


            if (currentClass == this.NullClass)
            {
                b = true;
            }



            if (currentClass == requiredClass)
            {
                b = true;
            }




            currentClass = currentClass.Base;
        }




        bool ret;


        ret = b;


        return ret;
    }





    private bool CheckAccess(Class varClass, Access access)
    {
        if (this.CurrentClass == varClass)
        {
            return true;
        }



        if (access == this.Access.Public)
        {
            return true;
        }



        if (access == this.Access.Proper)
        {
            if (this.Create.Refer.Module == varClass.Module)
            {
                return true;
            }


            return false;
        }


 
        if (access == this.Access.Parent)
        {
            if (this.CheckClass(this.CurrentClass, varClass))
            {
                return true;
            }


            return false;
        }



        if (access == this.Access.Privat)
        {
            return false;
        }



        return true;
    }






    private Field Field(Class varClass, string name)
    {
        Field field;


        field = (Field)varClass.Field.Get(name);



        if (!this.Null(field))
        {
            if (!this.CheckAccess(varClass, field.Access))
            {
                return null;
            }


            return field;
        }




        Class baseClass;


        baseClass = varClass.Base;



        if (!this.Null(baseClass))
        {
            field = this.Field(baseClass, name);



            if (!this.Null(field))
            {
                return field;
            }
        }



        return null;
    }





    protected Method Method(Class varClass, string name)
    {
        Method method;


        method = (Method)varClass.Method.Get(name);



        if (!this.Null(method))
        {
            if (!this.CheckAccess(varClass, method.Access))
            {
                return null;
            }


            return method;
        }




        Class baseClass;


        baseClass = varClass.Base;



        if (!this.Null(baseClass))
        {
            method = this.Method(baseClass, name);



            if (!this.Null(method))
            {
                return method;
            }
        }



        return null;
    }





    protected bool ArgueListMatch(Method method, ArgueList argueList)
    {
        int count;



        count = method.Params.Count;





        bool countEqual;



        countEqual = (count == argueList.Value.Count);




        if (!countEqual)
        {
            return false;
        }




        MapIter varIter;


        varIter = method.Params.Iter();




        ListIter argueIter;


        argueIter = argueList.Value.Iter();



        int i;


        i = 0;


        while (i < count)
        {
            varIter.Next();



            argueIter.Next();





            Argue argue;


            argue = (Argue)argueIter.Valu;




            if (this.Null(argue))
            {
                return false;
            }





            Var varVar;


            varVar = (Var)varIter.Valu;




            Class varClass;


            varClass = varVar.Class;




            Class expressClass;


            expressClass = this.Check(argue.Express).ExpressClass;



            if (this.Null(expressClass))
            {
                return false;
            }



            if (!this.CheckClass(expressClass, varClass))
            {
                return false;
            }




            i = i + 1;
        }



        return true;
    }





    private bool VarMapAdd(VarMap map, Var varVar)
    {
        return this.Create.Infra.VarMapAdd(map, varVar);
    }





    private bool VarMapMapAdd(VarMap map, VarMap other)
    {
        return this.Create.Infra.VarMapMapAdd(map, other);
    }







    private Var VarStackVar(string name)
    {
        ListIter iter;


        iter = this.VarStack.Iter();



        while (iter.Next())
        {
            VarMap varVars;


            varVars = (VarMap)iter.Valu;




            Var varVar;



            varVar = (Var)varVars.Get(name);



            if (!this.Null(varVar))
            {
                return varVar;
            }
        }




        return null;
    }







    public Class NullClass { get; set; }
}