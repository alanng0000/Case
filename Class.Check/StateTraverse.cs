namespace Class.Check;






public class StateTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();




        this.InitNullClass();




        this.VarStack = new VarStack();



        this.VarStack.Init();





        this.System = this.Compile.SystemModule;





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





    public SystemModule System { get; set; }





    public VarMap Vars { get; set; }





    public VarMap StateVars { get; set; }




        
    public VarStack VarStack { get; set; }






    public override bool ExecuteClass(NodeClass varClass)
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






        this.CurrentResultClass = this.System.Bool;





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


        dataVar.Name = "data";


        dataVar.Class = field.Class;






        Var valueVar;


        valueVar = new Var();


        valueVar.Name = "value";


        valueVar.Class = field.Class;





        this.VarMapAdd(o, dataVar);




        this.VarMapAdd(o, valueVar);





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




        ClassName nodeClass;

        nodeClass = nodeVar.Class;
            




        string varName;


        varName = name.Value;
            




        string className;


        className = null;



        if (!this.Null(nodeClass))
        {
            className = nodeClass.Value;
        }






        if (!this.Null(this.Vars.Get(varName)))
        {
            this.Error(this.ErrorKinds.NameUnavailable, nodeVar);


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
            this.Error(this.ErrorKinds.ClassUndefined, nodeVar);


            return true;
        }





        Var varVar;


        varVar = new Var();


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
            
            
            
        Express value;
            
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
            this.Error(this.ErrorKinds.TargetUndefined, assignState);
        }



        if (this.Null(valueClass))
        {
            this.Error(this.ErrorKinds.ValueUndefined, assignState);
        }





        if (! this.Null(targetClass) & ! this.Null(valueClass))
        {
            if (! this.CheckClass(valueClass, targetClass))
            {
                this.Error(this.ErrorKinds.ValueUnassignable, assignState);
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




        ClassName nodeClass;
        

        nodeClass = newExpress.Class;





        string className;


        className = null;




        if (! this.Null(nodeClass))
        {
            className = nodeClass.Value;
        }




        Class varClass;



        varClass = null;




        if (! this.Null(className))
        {
            varClass = this.Class(className);
        }





        if (this.Null(varClass))
        {
            this.Error(this.ErrorKinds.ClassUndefined, newExpress);
        }





        this.Check(newExpress).NewClass = varClass;



        this.Check(newExpress).ExpressClass = varClass;




        return true;
    }





    public override bool ExecuteGlobalExpress(GlobalExpress globalExpress)
    {
        if (this.Null(globalExpress))
        {
            return true;
        }




        ClassName nodeClass;
        

        nodeClass = globalExpress.Class;





        string className;


        className = null;




        if (! this.Null(nodeClass))
        {
            className = nodeClass.Value;
        }




        Class varClass;



        varClass = null;




        if (! this.Null(className))
        {
            varClass = this.Class(className);
        }





        if (this.Null(varClass))
        {
            this.Error(this.ErrorKinds.ClassUndefined, globalExpress);
        }





        this.Check(globalExpress).GlobalClass = varClass;



        this.Check(globalExpress).ExpressClass = varClass;




        return true;
    }






    public override bool ExecuteBracketExpress(BracketExpress bracketExpress)
    {
        if (this.Null(bracketExpress))
        {
            return true;
        }





        Express express;

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





        Express left;
            
        left = andExpress.Left;



        Express right;
            
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
            this.UniqueError(this.ErrorKinds.OperandUndefined, andExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (!this.CheckClass(leftClass, this.System.Bool))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, andExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKinds.OperandUndefined, andExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (!this.CheckClass(rightClass, this.System.Bool))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, andExpress, ref hasOperandUnassignable);
            }
        }




        this.Check(andExpress).ExpressClass = this.System.Bool;




        return true;
    }
    




    public override bool ExecuteOrnExpress(OrnExpress ornExpress)
    {
        if (this.Null(ornExpress))
        {
            return true;
        }





        Express left;

        left = ornExpress.Left;



        Express right;

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
            this.UniqueError(this.ErrorKinds.OperandUndefined, ornExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.System.Bool))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, ornExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKinds.OperandUndefined, ornExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.System.Bool))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, ornExpress, ref hasOperandUnassignable);
            }
        }




        this.Check(ornExpress).ExpressClass = this.System.Bool;




        return true;
    }





    public override bool ExecuteNotExpress(NotExpress notExpress)
    {
        if (this.Null(notExpress))
        {
            return true;
        }





        Express nodeBool;

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
            this.Error(this.ErrorKinds.OperandUndefined, notExpress);
        }




        if (! this.Null(boolClass))
        {
            if (! this.CheckClass(boolClass, this.System.Bool))
            {
                this.Error(this.ErrorKinds.OperandUnassignable, notExpress);
            }
        }


            

        this.Check(notExpress).ExpressClass = this.System.Bool;




        return true;
    }






    public override bool ExecuteAddExpress(AddExpress addExpress)
    {
        if (this.Null(addExpress))
        {
            return true;
        }





        Express left;

        left = addExpress.Left;



        Express right;

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
            this.UniqueError(this.ErrorKinds.OperandUndefined, addExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.System.Int))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, addExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKinds.OperandUndefined, addExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.System.Int))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, addExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(addExpress).ExpressClass = this.System.Int;




        return true;
    }






    public override bool ExecuteSubExpress(SubExpress subExpress)
    {
        if (this.Null(subExpress))
        {
            return true;
        }





        Express left;

        left = subExpress.Left;



        Express right;

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
            this.UniqueError(this.ErrorKinds.OperandUndefined, subExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.System.Int))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, subExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKinds.OperandUndefined, subExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.System.Int))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, subExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(subExpress).ExpressClass = this.System.Int;




        return true;
    }





    public override bool ExecuteMulExpress(MulExpress mulExpress)
    {
        if (this.Null(mulExpress))
        {
            return true;
        }





        Express left;

        left = mulExpress.Left;



        Express right;

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
            this.UniqueError(this.ErrorKinds.OperandUndefined, mulExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.System.Int))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, mulExpress, ref hasOperandUnassignable);
            }
        }





        if (rightClass == null)
        {
            this.UniqueError(this.ErrorKinds.OperandUndefined, mulExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.System.Int))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, mulExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(mulExpress).ExpressClass = this.System.Int;




        return true;
    }





    public override bool ExecuteDivExpress(DivExpress divExpress)
    {
        if (this.Null(divExpress))
        {
            return true;
        }





        Express left;

        left = divExpress.Left;



        Express right;

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
            this.UniqueError(this.ErrorKinds.OperandUndefined, divExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.System.Int))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, divExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKinds.OperandUndefined, divExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.System.Int))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, divExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(divExpress).ExpressClass = this.System.Int;




        return true;
    }





    public override bool ExecuteEqualExpress(EqualExpress equalExpress)
    {
        if (this.Null(equalExpress))
        {
            return true;
        }





        Express left;

        left = equalExpress.Left;




        Express right;

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
            this.UniqueError(this.ErrorKinds.OperandUndefined, equalExpress, ref hasOperandUndefined);
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKinds.OperandUndefined, equalExpress, ref hasOperandUndefined);
        }



        


        this.Check(equalExpress).ExpressClass = this.System.Bool;




        return true;
    }





    public override bool ExecuteLessExpress(LessExpress lessExpress)
    {
        if (this.Null(lessExpress))
        {
            return true;
        }





        Express left;

        left = lessExpress.Left;



        Express right;

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
            this.UniqueError(this.ErrorKinds.OperandUndefined, lessExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.System.Int))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, lessExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKinds.OperandUndefined, lessExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.System.Int))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, lessExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(lessExpress).ExpressClass = this.System.Bool;




        return true;
    }





    public override bool ExecuteJoinExpress(JoinExpress joinExpress)
    {
        if (this.Null(joinExpress))
        {
            return true;
        }





        Express left;

        left = joinExpress.Left;



        Express right;

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
            this.UniqueError(this.ErrorKinds.OperandUndefined, joinExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftClass))
        {
            if (! this.CheckClass(leftClass, this.System.String))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, joinExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightClass))
        {
            this.UniqueError(this.ErrorKinds.OperandUndefined, joinExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightClass))
        {
            if (! this.CheckClass(rightClass, this.System.String))
            {
                this.UniqueError(this.ErrorKinds.OperandUnassignable, joinExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(joinExpress).ExpressClass = this.System.String;




        return true;
    }




    public override bool ExecuteGetExpress(GetExpress getExpress)
    {
        if (this.Null(getExpress))
        {
            return true;
        }





        Express varThis;

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
            fieldName = nodeField.Value;
        }




        if (this.Null(thisClass))
        {
            this.Error(this.ErrorKinds.ThisUndefined, getExpress);
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
                this.Error(this.ErrorKinds.FieldUndefined, getExpress);
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





        Express varThis;

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
            methodName = nodeMethod.Value;
        }




        if (this.Null(thisClass))
        {
            this.Error(this.ErrorKinds.ThisUndefined, callExpress);
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
                this.Error(this.ErrorKinds.MethodUndefined, callExpress);
            }
        }






        if (! this.Null(method))
        {
            if (! this.ArgueListMatch(method, argueList))
            {
                this.Error(this.ErrorKinds.ArguesUnassignable, callExpress);
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






        ClassName nodeClass;

        nodeClass = castExpress.Class;




        Express nodeObject;

        nodeObject = castExpress.Object;







        base.ExecuteCastExpress(castExpress);





        Class objectClass;


        objectClass = null;



        if (! this.Null(nodeObject))
        {
            objectClass = this.Check(nodeObject).ExpressClass;
        }



        if (this.Null(objectClass))
        {
            this.Error(this.ErrorKinds.ObjectUndefined, castExpress);
        }




        string className;

        className = null;



        if (! this.Null(nodeClass))
        {
            className = nodeClass.Value;
        }




        Class varClass;

        varClass = null;


        if (! this.Null(className))
        {
            varClass = this.Class(className);
        }



        if (this.Null(varClass))
        {
            this.Error(this.ErrorKinds.ClassUndefined, castExpress);
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




        Express cond;
            
        cond = ifState.Cond;



        StateList loop;
        
        loop = ifState.Loop;





        base.ExecuteIfState(ifState);





        Class condClass;


        condClass = null;



        if (!this.Null(cond))
        {
            condClass = this.Check(cond).ExpressClass;
        }





        if (this.Null(condClass))
        {
            this.Error(this.ErrorKinds.CondUndefined, ifState);
        }





        if (!this.Null(condClass))
        {
            if (!this.CheckClass(condClass, this.System.Bool))
            {
                this.Error(this.ErrorKinds.CondUnassignable, ifState);
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





        Express cond;

        cond = whileState.Cond;



        StateList body;

        body = whileState.Body;





        base.ExecuteWhileState(whileState);





        Class condClass;


        condClass = null;



        if (! this.Null(cond))
        {
            condClass = this.Check(cond).ExpressClass;
        }





        if (this.Null(condClass))
        {
            this.Error(this.ErrorKinds.CondUndefined, whileState);
        }





        if (! this.Null(condClass))
        {
            if (! this.CheckClass(condClass, this.System.Bool))
            {
                this.Error(this.ErrorKinds.CondUnassignable, whileState);
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





        Express result;
            
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
            this.Error(this.ErrorKinds.ResultUndefined, returnState);
        }
        



        if (! this.Null(resultClass))
        {
            if (!this.IsFieldSet)
            {
                if (! this.CheckClass(resultClass, this.CurrentResultClass))
                {
                    this.Error(this.ErrorKinds.ResultUnassignable, returnState);
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


        varName = name.Value;




        Var varVar;


        varVar = (Var)this.Vars.Get(varName);




        if (this.Null(varVar))
        {
            this.Error(this.ErrorKinds.VarUndefined, varExpress);
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





        Constant constant;
        

        constant = constantExpress.Constant;





        base.ExecuteConstantExpress(constantExpress);





        Class constantClass;


        constantClass = null;




        if (!this.Null(constant))
        {
            if (constant is BoolConstant)
            {
                constantClass = this.System.Bool;
            }

            if (constant is IntConstant)
            {
                constantClass = this.System.Int;
            }

            if (constant is StringConstant)
            {
                constantClass = this.System.String;
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


        varName = name.Value;




        Var varVar;


        varVar = (Var)this.Vars.Get(varName);




        if (this.Null(varVar))
        {
            this.Error(this.ErrorKinds.VarUndefined, varTarget);
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





        Express varThis;

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
            fieldName = nodeField.Value;
        }




        if (this.Null(thisClass))
        {
            this.Error(this.ErrorKinds.ThisUndefined, setTarget);
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
                this.Error(this.ErrorKinds.FieldUndefined, setTarget);
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





    private bool CheckAcccess(Class varClass, Access access)
    {
        if (this.CurrentClass == varClass)
        {
            return true;
        }



        if (access == this.Access.Public)
        {
            return true;
        }



        if (access == this.Access.Local)
        {
            if (this.Compile.Module == varClass.Module)
            {
                return true;
            }


            return false;
        }


 
        if (access == this.Access.Derive)
        {
            if (this.CheckClass(this.CurrentClass, varClass))
            {
                return true;
            }


            return false;
        }



        if (access == this.Access.Private)
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
            if (!this.CheckAcccess(varClass, field.Access))
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
            if (!this.CheckAcccess(varClass, method.Access))
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




            Pair varPair;


            varPair = (Pair)varIter.Value;




            Argue argue;


            argue = (Argue)argueIter.Value;




            if (this.Null(argue))
            {
                return false;
            }





            Var varVar;


            varVar = (Var)varPair.Value;




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
        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = varVar.Name;


        pair.Value = varVar;




        map.Add(pair);



        return true;
    }





    private bool VarMapMapAdd(VarMap map, VarMap other)
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







    private Var VarStackVar(string name)
    {
        ListIter iter;


        iter = this.VarStack.Iter();



        while (iter.Next())
        {
            VarMap varVars;


            varVars = (VarMap)iter.Value;




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