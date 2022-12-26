namespace Class.Module;





class SizeCompile
{
    public Compile Compile { get; set; }





    private CheckModule Module { get; set; }





    public ulong Size { get; set; }





    public Constants Constants { get; set; }








    public bool Init()
    {
        this.Constants = Constants.This;





        this.ModuleIndexSize = this.Constants.IntSize;





        this.ClassIndexSize = this.Constants.IntSize;






        this.ClassNameSize = this.ClassIndexSize;





        this.AccessSize = this.Constants.ByteSize;




        return true;
    }








    public bool Execute()
    {
        this.Module = this.Compile.Module;





        this.Size = 0;






        this.ExecuteRefer();





        if (this.Compile.ExecuteStates)
        {
            this.ExecuteStates();
        }




        return true;
    }





    private bool ExecuteRefer()
    {
        this.ExecuteReferName();




        this.ExecuteReferVerse();




        this.ExecuteReferImports();




        this.ExecuteReferExports();




        this.ExecuteReferClass();




        this.ExecuteReferMembers();




        return true;
    }







    private ulong ModuleIndexSize { get; set; }





    private ulong ClassIndexSize { get; set; }




    public ulong ClassNameSize { get; set; }





    private ulong AccessSize { get; set; }








    private bool ExecuteReferName()
    {
        string name;




        name = this.Module.Name;






        ulong nameSize;




        nameSize = this.StringSize(name);





        this.AddSize(nameSize);




        return true;
    }





    private bool ExecuteReferVerse()
    {
        this.AddIntSize();


        this.AddIntSize();


        this.AddIntSize();


        this.AddIntSize();



        return true;
    }






    private bool ExecuteReferImports()
    {
        this.AddCountSize();




        ulong size;


        size = 0;




        ListIter iter;



        iter = this.Compile.Port.Imports.Iter();



        while (iter.Next())
        {
            Import varImport;



            varImport = (Import)iter.Value;





            ulong nameSize;



            nameSize = this.StringSize(varImport.Module.Value);



            size = size + nameSize;





            ulong verseSize;



            verseSize = this.Constants.IntSize * 4;



            size = size + verseSize;






            size = size + this.ClassIndexSize;
        }




        this.AddSize(size);




        return true;
    }





    private bool ExecuteReferExports()
    {
        this.AddCountSize();




        int count;



        count = this.Compile.Port.Exports.Count;





        ulong exportCount;



        exportCount = this.ULong(count);





        ulong size;


        size = exportCount * this.ClassIndexSize;




        this.AddSize(size);




        return true;
    }







    private bool ExecuteReferClass()
    {
        this.AddCountSize();




        ulong size;


        size = 0;




        MapIter iter;



        iter = this.Module.Class.Iter();



        while (iter.Next())
        {
            Pair pair;



            pair = (Pair)iter.Value;




            CheckClass varClass;



            varClass = (CheckClass)pair.Value;





            string name;



            name = varClass.Name;





            ulong nameSize;



            nameSize = this.StringSize(name);




            size = size + nameSize + this.ClassNameSize;
        }




        this.AddSize(size);




        return true;
    }





    private bool ExecuteReferMembers()
    {
        MapIter iter;




        iter = this.Module.Class.Iter();




        while (iter.Next())
        {
            Pair pair;



            pair = (Pair)iter.Value;





            CheckClass varClass;



            varClass = (CheckClass)pair.Value;





            this.ExecuteReferFields(varClass);




            this.ExecuteReferMethods(varClass);
        }




        return true;
    }








    private bool ExecuteReferFields(CheckClass varClass)
    {
        this.AddCountSize();




        MapIter iter;



        iter = varClass.Field.Iter();




        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            CheckField field;


            field = (CheckField)pair.Value;



            this.ExecuteReferField(field);
        }




        return true;
    }





    private bool ExecuteReferField(CheckField field)
    {
        string name;


        name = field.Name;





        ulong nameSize;


        nameSize = this.StringSize(name);





        ulong size;



        size = nameSize + this.ClassNameSize + this.AccessSize;





        this.AddSize(size);




        return true;
    }








    private bool ExecuteReferMethods(CheckClass varClass)
    {
        this.AddCountSize();




        MapIter iter;



        iter = varClass.Methods.Iter();




        while (iter.Next())
        {
            Pair pair;



            pair = (Pair)iter.Value;





            CheckMethod method;



            method = (CheckMethod)pair.Value;





            this.ExecuteReferMethod(method);
        }




        return true;
    }





    private bool ExecuteReferMethod(CheckMethod method)
    {
        string name;


        name = method.Name;





        ulong nameSize;


        nameSize = this.StringSize(name);





        ulong size;



        size = nameSize + this.ClassNameSize + this.AccessSize;




        this.AddSize(size);






        CheckVarMap vars;




        vars = method.Params;




        this.ExecuteReferVars(vars);





        return true;
    }





    private bool ExecuteReferVars(CheckVarMap vars)
    {
        this.AddCountSize();




        MapIter iter;


        iter = vars.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            CheckVar var;


            var = (CheckVar)pair.Value;




            this.ExecuteReferVar(var);
        }



        return true;
    }





    private bool ExecuteReferVar(CheckVar var)
    {
        string name;


        name = var.Name;





        ulong nameSize;


        nameSize = this.StringSize(name);





        ulong size;



        size = nameSize + this.ClassNameSize;




        this.AddSize(size);





        return true;
    }






    private SizeTraverse SizeTraverse { get; set; }






    private bool ExecuteStates()
    {
        this.SizeTraverse = new SizeTraverse();




        this.SizeTraverse.Init();




        this.SizeTraverse.SizeCompile = this;






        MapIter iter;



        iter = this.Module.Class.Iter();




        while (iter.Next())
        {
            Pair pair;



            pair = (Pair)iter.Value;




            CheckClass varClass;


            varClass = (CheckClass)pair.Value;




            this.ExecuteStatesClass(varClass);
        }





        return true;
    }





    private bool ExecuteStatesClass(CheckClass varClass)
    {
        this.ExecuteStatesFields(varClass.Field);




        this.ExecuteStatesMethods(varClass.Methods);




        return true;
    }





    private bool ExecuteStatesFields(CheckFieldMap fields)
    {
        MapIter iter;



        iter = fields.Iter();




        while (iter.Next())
        {
            Pair pair;



            pair = (Pair)iter.Value;




            CheckField field;



            field = (CheckField)pair.Value;




            this.ExecuteStatesField(field);
        }




        return true;
    }




    private bool ExecuteStatesField(CheckField field)
    {
        NodeField nodeField;



        nodeField = field.Node;




        this.ExecuteStatesTraverse(nodeField.Get);



        this.ExecuteStatesTraverse(nodeField.Set);




        return true;
    }





    private bool ExecuteStatesMethods(CheckMethodMap methods)
    {
        MapIter iter;



        iter = methods.Iter();




        while (iter.Next())
        {
            Pair pair;



            pair = (Pair)iter.Value;




            CheckMethod method;



            method = (CheckMethod)pair.Value;




            this.ExecuteStatesMethod(method);
        }




        return true;
    }





    private bool ExecuteStatesMethod(CheckMethod method)
    {
        NodeMethod nodeMethod;



        nodeMethod = method.Node;




        if (nodeMethod == null)
        {
            return true;
        }




        this.ExecuteStatesTraverse(nodeMethod.Call);





        return true;
    }







    private bool ExecuteStatesTraverse(States states)
    {
        this.SizeTraverse.ExecuteStates(states);



        return true;
    }







    private bool AddCountSize()
    {
        this.AddIntSize();



        return true;
    }





    private ulong StringSize(string s)
    {
        int length;



        length = s.Length;





        ulong count;



        count = this.ULong(length);





        ulong charsSize;



        charsSize = count;





        ulong size;



        size = this.Constants.IntSize + charsSize;





        ulong ret;


        ret = size;



        return ret;
    }








    private ulong ULong(int o)
    {
        return this.Compile.ULong(o);
    }








    public bool AddByteSize()
    {
        this.AddSize(this.Constants.ByteSize);


        return true;
    }




    public bool AddIntSize()
    {
        this.AddSize(this.Constants.IntSize);


        return true;
    }





    public bool AddSize(ulong size)
    {
        this.Size = this.Size + size;


        return true;
    }
}