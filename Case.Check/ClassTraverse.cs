namespace Case.Check;





class ClassTraverse : Traverse
{
    public override bool ExecuteClass(NodeClas nodeClass)
    {
        if (this.Null(nodeClass))
        {
            return true;
        }
        



        CaseName name;
            

        name = nodeClass.Name;




        string className;


        className = name.Value;







        ClassMap map;



        map = this.Create.Refer.Class;




        
        if (!this.Null(map.Get(className)))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeClass);


            return true;
        }


        


        

        Class varClass;



        varClass = new Class();



        varClass.Init();



        varClass.Name = className;



        varClass.Base = null;



        varClass.Field = new FieldMap();



        varClass.Field.Init();



        varClass.Method = new MethodMap();



        varClass.Method.Init();



        varClass.Module = this.Create.Refer.Module;



        varClass.Node = nodeClass;



        varClass.Source = this.Source;



        varClass.Index = this.Create.ClassIndex(this.Source);



        varClass.Id = this.Create.NewClassId();






        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = className;


        pair.Valu = varClass;



        map.Add(pair);





        Pair o;


        o = new Pair();


        o.Init();


        o.Key = className;


        o.Valu = varClass;




        this.Create.Refer.Module.Class.Add(o);
        




        this.Check(nodeClass).Class = varClass;




        return true;
    }
}