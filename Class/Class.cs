namespace Class;





public class Class : Object
{
    public SourceArray Source { get; set; }






    public PortPort Port { get; set; }





    public bool ErrorWrite { get; set; }





    public Task Task { get; set; }






    public Result Result { get; set; }






    internal Result SystemResult { get; set; }







    private TextWriter Out { get; set; }






    public Compile Compile { get; set; }








    private ErrorString ErrorString { get; set; }








    private ModuleEntryIntentMap EntryIntentMap { get; set; }



    private ModuleEntryNameMap EntryNameMap { get; set; }





    internal CheckRefer Refer { get; set; }





    internal CheckConstantClass ConstantClass { get; set; }



    

    internal CheckModule ConstantModule { get; set; }





    private string SourceFold { get; set; }
    




    internal string Node { get; set; }






    public override bool Init()
    {
        base.Init();






        this.ErrorWrite = true;




        this.ErrorString = new ErrorString();



        this.ErrorString.Class = this;



        this.ErrorString.Init();





        this.Compile = this.CreateCompile();





        

        this.InitModuleEntry();





        this.InitModuleHead();





        this.InitConstantClass();





        this.CharOneList = new char[1];



        this.LineOneList = new TextLine[1];





        RangeInfra infra;

        infra = RangeInfra.This;



        this.OneRange = infra.Range(0, this.CharOneList.Length);
        



        return true;
    }









    private ModuleHeadLoad ModuleHeadLoad { get; set; }







    private ModuleHeadImportRead ModuleHeadImportRead { get; set; }







    private ModuleImport ModuleImport { get; set; }








    private bool InitModuleHead()
    {
        this.ModuleHeadLoad = new ModuleHeadLoad();


        this.ModuleHeadLoad.Init();






        this.ModuleHeadImportRead = new ModuleHeadImportRead();


        this.ModuleHeadImportRead.Init();




        return true;
    }









    private bool InitModuleEntry()
    {
        this.EntryIntentMap = new ModuleEntryIntentMap();


        this.EntryIntentMap.Init();





        this.EntryNameMap = new ModuleEntryNameMap();


        this.EntryNameMap.Init();






        ModuleEntryLoad moduleEntryLoad;

        moduleEntryLoad = new ModuleEntryLoad();

        moduleEntryLoad.Init();




        moduleEntryLoad.IntentMap = this.EntryIntentMap;


        moduleEntryLoad.NameMap = this.EntryNameMap;




        moduleEntryLoad.Execute();
        




        return true;
    }






    private bool InitConstantClass()
    {
        Constant constant;

        constant = Constant.This;




        ModuleIntent intent;

        intent = new ModuleIntent();

        intent.Init();

        intent.Value = constant.SystemIntent;




        ModuleVer ver;

        ver = new ModuleVer();

        ver.Init();

        ver.Value = constant.SystemVer;
        



        ModuleRefer refer;

        refer = new ModuleRefer();

        refer.Init();

        refer.Intent = intent;

        refer.Ver = ver;




        ModuleName name;

        name = new ModuleName();

        name.Init();

        name.Value = constant.SystemName;






        StringCompare compare;

        compare = new StringCompare();

        compare.Init();





        Map a;


        a = new Map();


        a.Compare = compare;


        a.Init();





        ModuleImport import;

        import = new ModuleImport();

        import.Init();

        import.Refer = refer;

        import.Name = name;

        import.ClassImport = a;





        this.ModuleImport = import;






        this.AddClassImport(constant.SystemObjectName);




        this.AddClassImport(constant.SystemBoolName);




        this.AddClassImport(constant.SystemIntName);




        this.AddClassImport(constant.SystemStringName);






        this.InitConstantClassModule();






        this.ConstantClass = new CheckConstantClass();


        this.ConstantClass.Init();





        this.ConstantClass.Object = this.GetConstantModuleClass(constant.SystemObjectName);


        this.ConstantClass.Bool = this.GetConstantModuleClass(constant.SystemBoolName);


        this.ConstantClass.Int = this.GetConstantModuleClass(constant.SystemIntName);


        this.ConstantClass.String = this.GetConstantModuleClass(constant.SystemStringName);





        return true;
    }






    private CheckClass GetConstantModuleClass(string name)
    {
        return (CheckClass)this.ConstantModule.Class.Get(name);
    }







    private bool InitConstantClassModule()
    {
        ModuleImport import;

        import = this.ModuleImport;




        CheckClassMap classMap;


        classMap = new CheckClassMap();


        classMap.Init();




        CheckModule module;

        module = new CheckModule();

        module.Init();

        module.Refer = import.Refer;

        module.Name = import.Name;

        module.Class = classMap;





        ModuleRefer refer;


        refer = import.Refer;





        Data moduleHead;


        moduleHead = this.LoadModuleHead(refer);




        if (this.Null(moduleHead))
        {
            return false;
        }

        


        bool b;

        
        b = this.ReadModuleHeadImport(moduleHead, import, module);



        if (!b)
        {
            return false;
        }
        


        

        this.ConstantModule = module;





        return true;
    }








    private bool AddClassImport(string varClass)
    {
        Pair pair;

        pair = new Pair();

        pair.Init();

        pair.Key = varClass;

        pair.Value = varClass;



        this.ModuleImport.ClassImport.Add(pair);



        return true;
    }








    public bool Execute()
    {
        TaskKind t;


        t = this.Task.Kind;




        TaskKindList k;


        k = TaskKindList.This;



        bool taskPort;


        taskPort = (t == k.Port);




        if (taskPort)
        {
            bool b;

            b = this.ExecutePort();



            if (!b)
            {
                return false;
            }



            return true;
        }






        bool taskModule;



        taskModule = (t == k.Module);




        bool taskCheck;


        taskCheck = (t == k.Check);




        bool taskNode;


        taskNode = (t == k.Node);




        if (taskModule | taskCheck)
        {
            if (this.Null(this.Refer))
            {
                this.Error("Require Valid Port");


                return false;
            }




            this.Node = "Class";
        }




        if (taskNode)
        {
            if (this.Null(this.Task.Node))
            {
                this.Error("Node Invalid");


                return false;
            }



            this.Node = this.Task.Node;
        }
        
        




        bool bc;


        bc = this.Null(this.Task.Source);



        if (!bc)
        {
            this.Source = this.Task.Source;
        }




        if (bc)
        {
            List fileList;



            fileList = null;




            if (!taskModule)
            {
                string filePath;


                filePath = this.Task.SourcePath;




                if (this.Null(filePath))
                {
                    this.Error("Source Invalid");



                    return false;
                }





                this.SourceFold = Path.GetDirectoryName(filePath);




                string file;

                
                file = Path.GetFileName(filePath);
                



                fileList = new List();


                fileList.Init();



                fileList.Add(file);
            }




            if (taskModule)
            {
                string sourceFold;


                sourceFold = this.Task.SourcePath;



                if (this.Null(sourceFold))
                {
                    this.Error("Source Fold Invalid");



                    return false;
                }



                this.SourceFold = sourceFold;



                fileList = this.GetClassFiles(this.SourceFold);
            }





            this.SetSource(fileList);
                



            this.ReadCodes();
        }




        
        this.Out = this.Task.Out;

            
                
            

        this.ExecuteCompile();




        this.WriteErrors();




        if (this.Task.Print)
        {
            if (t == k.Token)
            {
                this.PrintTokenResult();
            }



            if (t == k.Node)
            {
                this.PrintNodeResult();
            }



            if (t == k.Check)
            {
                this.PrintCheckResult();
            }



            if (t == k.Module)
            {
                this.PrintModuleResult();
            }
        }





        return true;
    }






    

    private bool ExecutePort()
    {
        bool b;

        b = this.ExecutePortRefer();



        if (!b)
        {
            this.Refer = null;
        }



        this.ImportMap = null;





        bool ret;
        
        ret = b;

        return ret;
    }







    private bool ExecutePortRefer()
    {
        this.Refer = null;



        bool b;


        b = this.GetPort();


        if (!b)
        {
            return false;
        }





        CheckRefer refer;

        refer = new CheckRefer();

        refer.Init();

        refer.Import = new CheckModuleMap();

        refer.Import.Init();



        this.Refer = refer;






        string s;

        s = this.Port.Name.Value;




        ModuleName a;

        a = new ModuleName();

        a.Init();

        a.Value = s;




        ModuleEntry entry;

        entry = (ModuleEntry)this.EntryNameMap.Get(a);



        if (this.Null(entry))
        {
            return false;
        }






        ModuleRefer u;


        u = new ModuleRefer();


        u.Init();


        u.Intent = entry.Intent;





        CheckModule m;


        m = new CheckModule();


        m.Init();
        

        m.Refer = u;


        m.Name = entry.Name;


        m.Class = null;






        this.Refer.Module = m;


        



        bool bb;


        bb = this.SetPortImportMap();


        if (!bb)
        {
            return false;
        }





        bool bc;


        bc = this.ExecutePortImportMap();


        if (!bc)
        {
            return false;
        }
 




        return true;
    }





    private Map ImportMap { get; set; }





    private bool SetPortImportMap()
    {   
        ModuleReferCompare c;

        c = new ModuleReferCompare();

        c.Init();
        
        

        Map importMap;

        importMap = new Map();

        importMap.Compare = c;

        importMap.Init();



        this.ImportMap = importMap;





        ListIter iter;

        iter = this.Port.Import.Iter();


        while (iter.Next())
        {
            PortImport o;


            o = (PortImport)iter.Value;



            bool b;


            b = this.SetPortImportMapImport(o);


            if (!b)
            {
                return false;
            }
        }




        return true;
    }




    private bool SetPortImportMapImport(PortImport o)
    {
        ModuleName name;

        name = new ModuleName();

        name.Init();

        name.Value = o.Module.Value;





        ModuleVer ver;


        ver = new ModuleVer();


        ver.Init();


        ver.Value = o.Ver.Value;





        ModuleRefer refer;

        
        refer = this.GetPortModuleRefer(name, ver);



        if (this.Null(refer))
        {
            return false;
        }





        if (!this.CheckModuleVer(refer.Intent, refer.Ver))
        {
            return false;
        }





        ModuleImport u;
        
        u = (ModuleImport)this.ImportMap.Get(refer);



        if (this.Null(u))
        {
            StringCompare cc;

            cc = new StringCompare();

            cc.Init();



            Map a;


            a = new Map();


            a.Compare = cc;


            a.Init();





            ModuleImport h;

            h = new ModuleImport();

            h.Init();

            h.Refer = refer;

            h.Name = name;

            h.ClassImport = a;




            Pair pair;

            pair = new Pair();

            pair.Init();

            pair.Key = h.Refer;

            pair.Value = h;



            this.ImportMap.Add(pair);



            u = h;
        }





        ModuleImport moduleImport;

        moduleImport = u;





        Map classImportMap;


        classImportMap = moduleImport.ClassImport;





        string aa;

        
        aa = o.Class.Value;





        string e;

        e = (string)classImportMap.Get(aa);



        if (!this.Null(e))
        {
            return false;
        }





        string ab;

        ab = o.Name.Value;





        Pair p;

        p = new Pair();

        p.Init();

        p.Key = aa;

        p.Value = ab;


        classImportMap.Add(p);
        


        return true;
    }





    private ModuleRefer GetPortModuleRefer(ModuleName name, ModuleVer ver)
    {
        ModuleEntry u;

        u = (ModuleEntry)this.EntryNameMap.Get(name);



        if (this.Null(u))
        {
            return null;
        }





        ModuleRefer refer;

        refer = new ModuleRefer();

        refer.Init();

        refer.Intent = u.Intent;

        refer.Ver = ver;





        ModuleRefer ret;


        ret = refer;


        return ret;
    }






    private bool ExecutePortImportMap()
    {
        MapIter iter;


        iter = this.ImportMap.Iter();



        while (iter.Next())
        {
            ModuleImport import;


            import = (ModuleImport)iter.Value;





            bool b;


            b = this.ExecutePortImportMapModule(import);



            if (!b)
            {
                return false;
            }
        }



        return true;
    }







    private bool ExecutePortImportMapModule(ModuleImport import)
    {
        CheckClassMap classMap;


        classMap = new CheckClassMap();


        classMap.Init();




        CheckModule module;

        module = new CheckModule();

        module.Init();

        module.Refer = import.Refer;

        module.Name = import.Name;

        module.Class = classMap;




        if (this.IsSystem(module.Refer))
        {
            this.ModuleAddConstantClassImport(module, import);
        }







        ModuleRefer refer;


        refer = import.Refer;





        Data moduleHead;


        moduleHead = this.LoadModuleHead(refer);




        if (this.Null(moduleHead))
        {
            return false;
        }

        

        
        
        bool b;

        
        b = this.ReadModuleHeadImport(moduleHead, import, module);



        if (!b)
        {
            return false;
        }





        Pair p;

        p = new Pair();

        p.Init();

        p.Key = module.Refer;

        p.Value = module;



        this.Refer.Import.Add(p);




        return true;
    }





    private bool ModuleAddConstantClassImport(CheckModule module, ModuleImport import)
    {
        StringCompare cc;

        cc = new StringCompare();

        cc.Init();



        Map map;

        map = new Map();

        map.Compare = cc;

        map.Init();





        MapIter iter;

        iter = import.ClassImport.Iter();


        while (iter.Next())
        {
            string varClass;

            varClass = (string)iter.Key;



            string name;

            name = (string)iter.Value;




            CheckClass c;


            c = (CheckClass)this.ConstantModule.Class.Get(varClass);


            
            bool b;


            b = this.Null(c);



            if (!b)
            {
                Pair pairA;

                pairA = new Pair();

                pairA.Init();

                pairA.Key = name;

                pairA.Value = c;



                module.Class.Add(pairA);
            }
            



            if (b)
            {
                Pair pairB;

                pairB = new Pair();

                pairB.Init();

                pairB.Key = varClass;

                pairB.Value = name;



                map.Add(pairB);
            }
        }




        import.ClassImport = map;




        return true;
    }





    private bool IsSystem(ModuleRefer refer)
    {
        ModuleRefer o;

        o = this.ConstantModule.Refer;




        bool ba;
        
        ba = (refer.Intent.Value == o.Intent.Value);


        bool bb;

        bb = (refer.Ver.Value == o.Ver.Value);



        bool b;
        
        b = (ba & bb);



        bool ret;

        ret = b;

        return ret;
    }






    private bool CheckModuleVer(ModuleIntent intent, ModuleVer ver)
    {
        if (!(ver.Value == 0))
        {
            return false;
        }


        return true;
    }





    private bool ReadModuleHeadImport(Data moduleHead, ModuleImport import, CheckModule module)
    {
        this.ModuleHeadImportRead.Data = moduleHead;


        this.ModuleHeadImportRead.Index = 0;



        this.ModuleHeadImportRead.Import = import;



        this.ModuleHeadImportRead.Module = module;





        bool b;


        b = this.ModuleHeadImportRead.Execute();



        if (!b)
        {
            return false;
        }




        return true;
    }






    private Data LoadModuleHead(ModuleRefer refer)
    {
        this.ModuleHeadLoad.Refer = refer;




        bool b;


        b = this.ModuleHeadLoad.Execute();



        if (!b)
        {
            return null;
        }





        Data data;


        data = this.ModuleHeadLoad.Result;




        Data ret;

        ret = data;

        return ret;
    }






    protected string PortFileName
    {
        get
        {
            return "_";
        }
    }




    private bool GetPort()
    {
        bool b;

        b = this.Null(this.Task.SourcePath);


        if (!b)
        {
            bool ba;
            
            ba = this.GetSourcePort(this.Task.SourcePath);
            

            if (!ba)
            {
                this.Error("Port Invalid");


                return false;
            }
        }




        if (b)
        {
            this.Port = this.Task.Port;
        }



        return true;
    }





    protected virtual bool GetSourcePort(string portFile)
    {
        if (!this.CheckPortFile(portFile))
        {   
            return false;
        }




        PortPort port;
        

        port = this.ReadPort(portFile);



        if (this.Null(port))
        {
            return false;
        }




        this.Port = port;




        return true;
    }








    public bool ExecuteCompile()
    {
        this.Compile.Execute();





        this.Result = this.Compile.Result;




        return true;
    }








    protected virtual Compile CreateCompile()
    {
        Compile compile;




        compile = new Compile();




        compile.Class = this;




        compile.Init();






        Compile ret;



        ret = compile;



        return ret;
    }






    private bool WriteErrors()
    {
        if (!this.ErrorWrite)
        {
            return true;
        }




        TaskKindList k;

        k = TaskKindList.This;




        bool kindModule;


        kindModule = this.Kind(k.Module);



        if (kindModule | this.Kind(k.Token))
        {
            if (!this.Null(this.Result.Token))
            {
                this.WriteErrors(this.Result.Token.Error);
            }
        }



        if (kindModule | this.Kind(k.Node))
        {
            if (!this.Null(this.Result.Node))
            {
                this.WriteErrors(this.Result.Node.Error);
            }
        }



        if (kindModule | this.Kind(k.Check))
        {
            if (!this.Null(this.Result.Check))
            {
                this.WriteErrors(this.Result.Check.Error);
            }
        }



        return true;
    }




    private bool Kind(TaskKind kind)
    {
        return this.Task.Kind == kind;
    }




    private bool WriteErrors(ErrorList errors)
    {
        ListIter iter;



        iter = errors.Iter();




        while (iter.Next())
        {


            Error error;


            error = (Error)iter.Value;




            this.WriteError(error);
        }



        return true;
    }




    private bool WriteError(Error error)
    {
        string t;

        t = this.ErrorString.String(error);


        this.Out.Write(t);




        return true;
    }





    private bool PrintModuleResult()
    {
        ModuleString moduleString;



        moduleString = new ModuleString();




        moduleString.Init();




        moduleString.Execute(this.Result.Module);




        string s;
        
        
        s = moduleString.Result();




        this.Out.Write(s);




        return true;
    }







    private bool PrintCheckResult()
    {
        CheckString checkString;




        checkString = this.CreateCheckString();




        checkString.Execute();





        string s;


        s = checkString.Result();




        this.Out.Write(s);




        return true;
    }






    private bool PrintNodeResult()
    {
        ObjectString objectString;



        objectString = new ObjectString();



        objectString.Init();





        ArrayIter sourceIter;



        sourceIter = this.Source.Iter();





        ArrayIter treeIter;



        treeIter = this.Result.Node.Tree.Iter();




        while (sourceIter.Next() & treeIter.Next())
        {
            Source source;


            source = (Source)sourceIter.Value;





            Tree tree;


            tree = (Tree)treeIter.Value;



            

            Text sourceText;


            sourceText = source.Text;





            NodeNode root;


            root = tree.Root;




            objectString.Source = sourceText;



            objectString.Execute(root);




            string s;
                

            s = objectString.Result();




            this.Out.Write(s);
        }



        return true;
    }










    private bool PrintTokenResult()
    {
        ObjectString objectString;



        objectString = new ObjectString();



        objectString.Init();
        




        ArrayIter sourceIter;


        sourceIter = this.Source.Iter();




        ArrayIter codeIter;


        codeIter = this.Result.Token.Code.Iter();



        
        while (sourceIter.Next() & codeIter.Next())
        {
            Source source;


            source = (Source)sourceIter.Value;



            Code code;



            code = (Code)codeIter.Value;





            Text sourceText;


            sourceText = source.Text;



            

            objectString.Source = sourceText;



            objectString.Execute(code);
            



            string s;
            

            s = objectString.Result();




            this.Out.Write(s);
        }




        return true;
    }




    protected virtual CheckString CreateCheckString()
    {
        CheckString checkString;
        
        
        
        
        checkString = new CheckString();




        checkString.Class = this;




        checkString.Init();




        return checkString;
    }





    private PortPort ReadPort(string filePath)
    {
        string[] k;


        k = File.ReadAllLines(filePath);




        Text text;


        text = this.CreateText(k);




        PortRead read;



        read = new PortRead();



        read.Init();




        read.Text = text;




        PortPort port;


        port = read.Execute();




        if (this.Null(port))
        {
            return null;
        }




        PortPort ret;

        ret = port;


        return ret;
    }








    private string[] GetFiles(string folderPath)
    {
        string[] u;
        
        
        u = Directory.GetFiles(folderPath);





        string s;


        string name;




        int count;


        count = u.Length;




        int i;


        i = 0;



        while (i < count)
        {
            s = u[i];


            name = Path.GetFileName(s);



            u[i] = name;



            i = i + 1;
        }




        StringComparer comparer;


        comparer = new StringComparer();


        comparer.Init();




        SystemArray.Sort<string>(u, comparer);




        string[] ret;



        ret = u;



        return ret;
    }





    private List GetClassFiles(string folderPath)
    {
        string[] u;



        u = this.GetFiles(folderPath);





        List t;


        t = new List();


        t.Init();





        string s;




        int count;


        count = u.Length;




        int i;

        i = 0;
        

        while (i < count)
        {
            s = u[i];



            if (!(s == this.PortFileName))
            {
                t.Add(s);
            }

            


            i = i + 1;
        }





        List ret;


        ret = t;


        return ret;
    }





    private bool Error(string message)
    {
        this.Out.WriteLine(message);



        return true;
    }







    private bool SetSource(List fileList)
    {
        SourceArray t;


        t = new SourceArray();



        t.Count = fileList.Count;



        t.Init();




        int i;

        i = 0;



        ListIter iter;


        iter = fileList.Iter();



        while (iter.Next())
        {
            string fileName;


            fileName = (string)iter.Value;






            Source source;
            

            source = new Source();


            source.Init();
            

            source.Index = i;


            source.Name = fileName;





            t.Set(source.Index, source);




            i = i + 1;
        }




        this.Source = t;



        return true;
    }




    private bool ReadCodes()
    {
        ArrayIter iter;


        iter = this.Source.Iter();



        while (iter.Next())
        {
            Source source;


            source = (Source)iter.Value;



            string fileName;

            fileName = source.Name;



            string filePath;

            filePath = Path.Combine(this.SourceFold, fileName);




            string[] array;


            array = File.ReadAllLines(filePath);


            

            Text text;


            text = this.CreateText(array);
            




            source.Text = text;
        }


        return true;
    }






    private Text CreateText(string[] array)
    {
        Text text;

        text = new Text();

        text.Init();




        int count;

        count = array.Length;




        RangeInfra rangeInfra;

        rangeInfra = RangeInfra.This;



        Range u;

        u = rangeInfra.Range(0, count);




        text.Line.Insert(u);





        int i;

        i = 0;



        while (i < count)
        {
            string s;

            s = array[i];



            TextLine line;

            line = this.CreateTextLine(s);



            this.LineOneList[0] = line;



            text.Line.Set(i, this.LineOneList, this.OneRange);



            i = i + 1;
        }




        Text ret;

        ret = text;


        return ret;
    }





    private char[] CharOneList { get; set; }




    private TextLine[] LineOneList { get; set; }




    private Range OneRange;





    private TextLine CreateTextLine(string s)
    {
        TextLine line;

        line = new TextLine();

        line.Init();



        int count;

        count = s.Length;




        RangeInfra rangeInfra;

        rangeInfra = RangeInfra.This;



        Range u;

        u = rangeInfra.Range(0, count);




        line.Char.Insert(u);




        char oc;
        
        


        int i;

        i = 0;


        while (i < count)
        {
            oc = s[i];



            this.CharOneList[0] = oc;



            line.Char.Set(i, this.CharOneList, this.OneRange);




            i = i + 1;
        }



        TextLine ret;


        ret = line;


        return ret;
    }






    private bool CheckPortFile(string portFile)
    {
        if (!File.Exists(portFile))
        {
            return false;
        }



        return true;
    }







    private bool Null(object o)
    {
        ObjectInfra infra;

        infra = ObjectInfra.This;


        return infra.Null(o);
    }
}