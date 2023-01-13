namespace Class.Check;




class MemberTraverse : Traverse
{
    private Class CurrentClass { get; set; }





    private VarMap ParamVarMap { get; set; }







    public override bool ExecuteClass(NodeClass nodeClass)
    {
        if (this.Null(nodeClass))
        {
            return true;
        }




        this.CurrentClass = this.Check(nodeClass).Class;




        if (this.Null(this.CurrentClass))
        {
            return true;
        }




        base.ExecuteClass(nodeClass);




        return true;
    }





    public override bool ExecuteField(NodeField nodeField)
    {
        if (this.Null(nodeField))
        {
            return true;
        }




        FieldName name;

        name = nodeField.Name;




        NodeClassName nodeClass;
            
        nodeClass = nodeField.Class;




        NodeAccess nodeAccess;

        nodeAccess = nodeField.Access;




        StateList nodeGet;

        nodeGet = nodeField.Get;




        StateList nodeSet;

        nodeSet = nodeField.Set;






        string fieldName;


        fieldName = name.Value;





        string className;

        
        className = nodeClass.Value;
               






        if (this.IsMemberNameDefined(fieldName))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeField);


            return true;
        }
        





        Class varClass;



        
        varClass = this.Class(className);
        




        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeField);


            return true;
        }





        Access access;



        access = this.GetAccess(nodeAccess);







        VarMap varGet;


        

        varGet = new VarMap();




        varGet.Init();
        





        VarMap varSet;


        
        
        varSet = new VarMap();




        varSet.Init();







        Field field;
            

        field = new Field();


        field.Init();
            

        field.Name = fieldName;
            

        field.Class = varClass;


        field.Access = access;


        field.Get = varGet;


        field.Set = varSet;


        field.Parent = this.CurrentClass;


        field.Node = nodeField;




        field.Index = this.CurrentClass.Field.Count;





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = fieldName;


        pair.Value = field;



        this.CurrentClass.Field.Add(pair);





        this.Check(nodeField).Field = field;




        return true;
    }





    public override bool ExecuteMethod(NodeMethod nodeMethod)
    {
        if (this.Null(nodeMethod))
        {
            return true;
        }





        MethodName name;

        name = nodeMethod.Name;




        NodeClassName nodeClass;

        nodeClass = nodeMethod.Class;




        NodeAccess nodeAccess;

        nodeAccess = nodeMethod.Access;




        ParamList paramList;

        paramList = nodeMethod.Param;




        StateList call;

        call = nodeMethod.Call;






        string methodName;



        methodName = name.Value;





        string className;


        
        className = nodeClass.Value;
        




        
        if (this.IsMemberNameDefined(methodName))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeMethod);



            return true;
        }





        Class varClass;



        
        varClass = this.Class(className);
        




        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeMethod);



            return true;
        }





        Access access;



        access = this.GetAccess(nodeAccess);






        VarMap o;



        o = new VarMap();



        o.Init();





        VarMap u;



        u = new VarMap();



        u.Init();






        this.ParamVarMap = o;





        this.ExecuteParamList(paramList);






        Method method;


        method = new Method();


        method.Init();


        method.Name = methodName;


        method.Class = varClass;


        method.Access = access;


        method.Params = this.ParamVarMap;


        method.Call = u;


        method.Parent = this.CurrentClass;


        method.Node = nodeMethod;



        method.Index = this.CurrentClass.Method.Count;
        





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = methodName;


        pair.Value = method;




        this.CurrentClass.Method.Add(pair);




        this.Check(nodeMethod).Method = method;




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




        NodeClassName nodeClass;

        nodeClass = nodeVar.Class;
            




        string varName;


        varName = name.Value;
            




        string className;


        className = null;



        if (!this.Null(nodeClass))
        {
            className = nodeClass.Value;
        }






        if (!this.Null(this.ParamVarMap.Get(varName)))
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





        this.Compile.Infra.VarMapAdd(this.ParamVarMap, varVar);
        




        this.Check(nodeVar).Var = varVar;




        return true;
    }









    private bool IsMemberNameDefined(string name)
    {
        bool ba;


        ba = !this.Null(this.CurrentClass.Field.Get(name));




        bool bb;

        bb = !this.Null(this.CurrentClass.Method.Get(name));




        bool t;


        t = ba | bb;




        bool ret;


        ret = t;


        return ret;
    }
}