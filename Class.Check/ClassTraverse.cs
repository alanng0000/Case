namespace Class.Check;





class ClassTraverse : Traverse
{
    public override bool ExecuteClass(NodeClass nodeClass)
    {
        if (this.Null(nodeClass))
        {
            return true;
        }
        



        NodeClassName name;
            

        name = nodeClass.Name;




        string className;


        className = name.Value;







        ClassMap map;



        map = this.Compile.Refer.Class;




        
        if (!this.Null(map.Get(className)))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeClass);


            return true;
        }




        
        ClassName h;

        h = new ClassName();

        h.Init();

        h.Value = className;
        


        

        Class varClass;



        varClass = new Class();



        varClass.Init();



        varClass.Name = h;



        varClass.Base = null;



        varClass.Field = new FieldMap();



        varClass.Field.Init();



        varClass.Method = new MethodMap();



        varClass.Method.Init();



        varClass.Module = this.Compile.Refer.Module;



        varClass.Node = nodeClass;



        varClass.Source = this.Source;



        varClass.Index = this.Compile.ClassIndex(this.Source);



        varClass.Id = this.Compile.NewClassId();






        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = className;


        pair.Value = varClass;



        map.Add(pair);





        Pair o;


        o = new Pair();


        o.Init();


        o.Key = className;


        o.Value = varClass;




        this.Compile.Refer.Module.Class.Add(o);
        




        this.Check(nodeClass).Class = varClass;




        return true;
    }
}