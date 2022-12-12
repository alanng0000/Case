namespace Class.Module;






class DataCompile
{
    public Compile Compile { get; set; }





    public byte[] Data { get; set; }





    private Constants Constants { get; set; }





    private CheckAccesss Accesss { get; set; }





    private CheckModule Module { get; set; }





    private Strings Strings { get; set; }





    private Map ImportIndexMap { get; set; }





    private ulong ImportCount { get; set; }



    

    public bool Init()
    {
        this.Constants = Constants.This;






        this.Accesss = CheckAccesss.This;





        this.Strings = new Strings();




        this.Strings.Init();





        return true;
    }










    public bool Execute()
    {
        this.Module = this.Compile.Module;






        this.Data = new byte[this.Compile.SizeCompile.Size];





        this.Index = 0;






        ClassCompare compare;


        compare = new ClassCompare();




        this.ImportIndexMap = new Map();



        this.ImportIndexMap.Compare = compare;



        this.ImportIndexMap.Init();





        Imports imports;



        imports = this.Compile.Port.Imports;






        this.ImportCount = this.ULong(imports.Count);







        this.ExecuteRefer();





        if (this.Compile.ExecuteStates)
        {
            this.CompileStates();
        }




        return true;
    }





    private bool ExecuteRefer()
    {
        this.ExecuteReferModule();




        this.ExecuteReferImports();




        this.ExecuteReferExports();




        this.ExecuteReferClass();




        this.ExecuteReferMembers();




        return true;
    }





    private bool ExecuteReferModule()
    {
        this.ExecuteReferName();





        return true;
    }




    private bool ExecuteReferName()
    {
        string name;





        name = this.Module.Name;






        this.AddString(name);






        return true;
    }





    private bool ExecuteReferImports()
    {
        Imports imports;



        imports = this.Compile.Port.Imports;




        this.AddInt(this.ImportCount);





        ulong index;



        index = 0;




        ListIter iter;



        iter = imports.Iter();



        while (iter.Next())
        {
            Import varImport;



            varImport = (Import)iter.Value;





            string moduleName;



            moduleName = varImport.Module.Value;




            this.AddString(moduleName);







            string className;


            className = varImport.Class.Value;




            CheckModule module;
            


            module = (CheckModule)this.Compile.CheckResult.Refer.Modules.Get(moduleName);




            CheckClass varClass;
            
            
            varClass = (CheckClass)module.Class.Get(className);





            Pair pair;


            pair = new Pair();


            pair.Init();


            pair.Key = varClass;


            pair.Value = index;




            this.ImportIndexMap.Add(pair);






            int k;



            k = varClass.Index;





            ulong u;



            u = this.ULong(k);




            this.AddInt(u);




            index = index + 1;
        }





        return true;
    }





    private bool ExecuteReferExports()
    {
        Exports exports;



        exports = this.Compile.Port.Exports;





        int count;



        count = exports.Count;





        ulong exportCount;



        exportCount = this.ULong(count);





        this.AddInt(exportCount);





        ListIter iter;



        iter = exports.Iter();




        while (iter.Next())
        {
            Export export;



            export = (Export)iter.Value;




            string className;



            className = export.Class.Value;




            CheckClass varClass;



            varClass = (CheckClass)this.Module.Class.Get(className);

            


            int k;



            k = varClass.Index;




            ulong index;



            index = this.ULong(k);




            this.AddInt(index);
        }




        return true;
    }





    private bool ExecuteReferClass()
    {
        CheckClassMap classMap;




        classMap = this.Module.Class;






        int count;



        count = classMap.Count;





        ulong u;




        u = this.ULong(count);





        this.AddInt(u);







        ulong index;



        index = 0;





        MapIter iter;




        iter = classMap.Iter();






        while (iter.Next())
        {
            Pair pair;



            pair = (Pair)iter.Value;





            CheckClass varClass;



            varClass = (CheckClass)pair.Value;





            string name;



            name = varClass.Name;






            this.AddString(name);





            ulong k;



            k = this.ImportCount + index;




            bool b;


            b = (k == 0);



            
            if (b)
            {
                this.AddInt(0);
            }




            if (!b)
            {
                CheckClass baseClass;



                baseClass = (CheckClass)varClass.Base;




            }




            index = index + 1;
        }




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
        CheckFieldMap fields;



        fields = varClass.Fields;




        int count;


        count = fields.Count;




        ulong t;



        t = this.ULong(count);




        this.AddInt(t);






        MapIter iter;



        iter = fields.Iter();




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




        this.AddString(name);





        CheckClass varClass;
        
        


        varClass = field.Class;




        this.AddClassName(varClass);





        CheckAccess access;




        access = field.Access;




        this.AddAccess(access);




        return true;
    }






    private bool ExecuteReferMethods(CheckClass varClass)
    {
        CheckMethodMap methods;




        methods = varClass.Methods;




        int count;



        count = methods.Count;




        ulong o;



        o = this.ULong(count);





        this.AddInt(o);





        MapIter iter;




        iter = methods.Iter();




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





        this.AddString(name);





        CheckClass varClass;



        varClass = method.Class;




        this.AddClassName(varClass);





        CheckAccess access;



        access = method.Access;




        this.AddAccess(access);






        CheckVarMap vars;




        vars = method.Params;




        this.ExecuteReferVars(vars);





        return true;
    }





    private bool ExecuteReferVars(CheckVarMap vars)
    {
        int count;


        count = vars.Count;




        ulong o;



        o = this.ULong(count);




        this.AddInt(o);






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





        this.AddString(name);





        CheckClass varClass;



        varClass = var.Class;





        this.AddClassName(varClass);





        return true;
    }






    private bool AddClassName(CheckClass varClass)
    {
        bool ba;



        ba = (varClass.Module == this.Module);



        if (ba)
        {
            ulong m;



            m = this.ULong(varClass.Index);




            ulong t;



            t = this.ImportCount + m;



            this.AddInt(t);
        }



        if (!ba)
        {
            object o;


            o = this.ImportIndexMap.Get(varClass);




            ulong h;



            h = (ulong)o;




            this.AddInt(h);
        }




        return true;
    }





    private bool AddAccess(CheckAccess access)
    {
        byte o;


        o = 0;



        if (access == this.Accesss.Public)
        {
            o = 0;
        }



        if (access == this.Accesss.Local)
        {
            o = 1;
        }



        if (access == this.Accesss.Derive)
        {
            o = 2;
        }



        if (access == this.Accesss.Private)
        {
            o = 3;
        }




        this.AddByte(o);




        return true;
    }






    private bool CompileStates()
    {
        return true;
    }




    private bool AddString(string s)
    {
        int count;



        count = s.Length;





        ulong t;



        t = this.ULong(count);





        this.AddInt(t);






        char c;




        byte o;




        int i;



        i = 0;




        while (i < count)
        {
            c = s[i];



            o = (byte)c;





            byte? u;

            u = this.Strings.GetCharCode(o);




            if (!u.HasValue)
            {
                return false;
            }




            byte y;


            y = u.Value;



            this.AddByte(y);




            i = i + 1;
        }




        return true;
    }






    private ulong ULong(int o)
    {
        return this.Compile.ULong(o);
    }






    private ulong Index { get; set; }






    public bool AddInt(ulong o)
    {
        ulong size;



        size = this.Constants.IntSize;




        int count;



        count = (int)size;




        int i;


        i = 0;



        while (i < count)
        {
            int shiftCount;



            shiftCount = this.Constants.ByteBitCount * i;



            ulong t;


            t = o >> shiftCount;



            byte u;


            u = (byte)t;




            this.AddByte(u);





            i = i + 1;
        }




        return true;
    }







    public bool AddByte(byte o)
    {
        this.Data[this.Index] = o;




        this.Index = this.Index + 1;




        return true;
    }
}