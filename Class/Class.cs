namespace Class;





public class Class : Object
{
    public SourceArray Source { get; set; }






    public PortPort Port { get; set; }





    public bool ErrorWrite { get; set; }





    public Task Task { get; set; }






    public Result Result { get; set; }






    internal Result SystemResult { get; set; }






    public TaskKindList TaskKindList { get; set; }






    private TextWriter Out { get; set; }






    public Compile Compile { get; set; }








    private ErrorString ErrorString { get; set; }






    public string SourceFold { get; set; }






    private ModuleEntryIntentMap EntryIntentMap { get; set; }



    private ModuleEntryNameMap EntryNameMap { get; set; }





    private CheckRefer Refer { get; set; }




    private CheckModule Module { get; set; }





    private CheckRefer PortRefer { get; set; }







    public override bool Init()
    {
        base.Init();





        this.TaskKindList = TaskKindList.This;





        this.ErrorWrite = true;




        this.ErrorString = new ErrorString();



        this.ErrorString.Class = this;



        this.ErrorString.Init();





        this.Compile = this.CreateCompile();





        

        this.InitModuleRootPath();




        

        this.InitModuleEntry();





        this.InitModuleHead();






        this.InitSystem();






        return true;
    }








    private bool InitModuleRootPath()
    {
        string s;


        s = File.ReadAllText(this.PathFileName);



        this.ModuleRootPath = s;



        return true;
    }





    private string ModuleRootPath { get; set; }








    private ModuleHeadLoad ModuleHeadLoad { get; set; }







    private ModuleHeadRead ModuleHeadRead { get; set; }






    private string PathFileName
    {
        get
        {
            return "Path.txt";
        }
        set
        {
        }
    }







    private bool InitModuleHead()
    {
        this.ModuleHeadLoad = new ModuleHeadLoad();


        this.ModuleHeadLoad.RootPath = this.ModuleRootPath;


        this.ModuleHeadLoad.Init();






        this.ModuleHeadRead = new ModuleHeadRead();


        this.ModuleHeadRead.Init();




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

        moduleEntryLoad.RootPath = this.ModuleRootPath;

        moduleEntryLoad.Init();




        moduleEntryLoad.IntentMap = this.EntryIntentMap;


        moduleEntryLoad.NameMap = this.EntryNameMap;




        moduleEntryLoad.Execute();
        




        return true;
    }






    public bool Execute()
    {
        TaskKind t;


        t = this.Task.Kind;




        TaskKindList k;


        k = this.TaskKindList;



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




        bool bb;


        bb = (t == k.Check);



        if (taskModule | bb)
        {
            if (this.Null(this.Refer))
            {
                this.Error("Require Valid Port");


                return false;
            }
        }

        



        List files;



        files = null;




        if (!taskModule)
        {
            string file;


            file = this.Task.Source;




            files = new List();


            files.Init();



            files.Add(file);

            



            
            if (!this.CheckClassFiles(files))
            {
                this.Error("Class Files Invalid");


                return false;
            }
        }




        if (taskModule)
        {
            this.SourceFold = this.Task.Source;



            if (this.Null(this.SourceFold))
            {
                this.Error("Source Fold Invalid");



                return false;
            }




            files = this.GetClassFiles(this.SourceFold);
        }





        this.Out = this.Task.Out;





        this.SetSources(files);
                



        this.ReadCodes();
            
                
            

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
        this.PortRefer = null;


        this.Refer = null;




        bool b;

        b = this.Null(this.Task.Source);


        if (!b)
        {
            bool ba;
            
            ba = this.GetPort(this.Task.Source);
            

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






        CheckRefer refer;

        refer = new CheckRefer();

        refer.Init();

        refer.Module = new CheckModuleMap();

        refer.Module.Init();

        refer.Class = new CheckClassMap();

        refer.Class.Init();

        refer.Import = new CheckImportList();

        refer.Import.Init();

        refer.Export = new CheckExportList();

        refer.Export.Init();

        refer.Entry = new CheckModuleEntry();

        refer.Entry.Init();



        this.PortRefer = refer;






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


        u.Ver = null;





        CheckModule m;


        m = new CheckModule();


        m.Init();
        

        m.Refer = u;


        m.Name = entry.Name;


        m.Class = new CheckClassMap();


        m.Class.Init();





        this.Module = m;


        



        bool bb;

        bb = this.SetPortImportMap();


        if (!bb)
        {
            return false;
        }











        this.Refer = this.PortRefer;
        




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
        ModuleRefer refer;

        
        refer = this.GetPortModuleRefer(o);



        if (this.Null(refer))
        {
            return false;
        }




        Map u;
        
        u = (Map)this.ImportMap.Get(refer);



        if (this.Null(u))
        {
            ClassNameCompare cc;

            cc = new ClassNameCompare();

            cc.Init();



            Map a;


            a = new Map();


            a.Compare = cc;


            a.Init();




            Pair pair;

            pair = new Pair();

            pair.Init();

            pair.Key = refer;

            pair.Value = a;



            this.ImportMap.Add(pair);



            u = a;
        }





        Map classImportMap;

        classImportMap = u;




        CheckClassName aa;

        aa = new CheckClassName();

        aa.Init();

        aa.Value = o.Class.Value;





        CheckClassName e;

        e = (CheckClassName)classImportMap.Get(aa);



        if (!this.Null(e))
        {
            return false;
        }





        CheckClassName ab;

        ab = new CheckClassName();

        ab.Init();

        ab.Value = o.Name.Value;



        Pair p;

        p = new Pair();

        p.Init();

        p.Key = aa;

        p.Value = ab;


        classImportMap.Add(p);
        


        return true;
    }





    private ModuleRefer GetPortModuleRefer(PortImport o)
    {
        ModuleName a;

        a = new ModuleName();

        a.Init();

        a.Value = o.Module.Value;




        ModuleEntry u;

        u = (ModuleEntry)this.EntryNameMap.Get(a);



        if (this.Null(u))
        {
            return null;
        }




        ModuleVer ver;


        ver = new ModuleVer();


        ver.Init();


        ver.Value = o.Ver.Value;




        if (!this.CheckModuleVer(u.Intent, ver))
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
            Pair pair;


            pair = (Pair)iter.Value;



            bool b;


            b = this.ExecutePortImportMapPair(pair);



            if (!b)
            {
                return false;
            }
        }



        return true;
    }




    private bool ExecutePortImportMapPair(Pair pair)
    {
        ModuleRefer refer;


        refer = (ModuleRefer)pair.Key;




        Map classImportMap;


        classImportMap = (Map)pair.Value;




        Data moduleHead;


        moduleHead = this.GetModuleHead(refer);
        




        return true;
    }







    private CheckModule GetModule(ModuleRefer refer)
    {
        return (CheckModule)this.PortRefer.Module.Get(refer);
    }





    private CheckModule ReadModule(Data data)
    {
        this.ModuleHeadRead.Data = data;


        this.ModuleHeadRead.Index = 0;



        this.ModuleHeadRead.Execute();




        CheckModule o;

        o = this.ModuleHeadRead.Result;



        CheckModule ret;

        ret = o;


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






    private Data GetModuleHead(ModuleRefer refer)
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





    protected virtual bool GetPort(string portFile)
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






    private bool InitSystem()
    {
        Task task;


        task = new Task();


        task.Init();


        task.Kind = this.TaskKindList.Check;


        task.Node = "Class";


        task.Check = null;


        task.Source = null;


        task.Print = false;


        task.Out = null;




        this.Task = task;





        string moduleName;



        moduleName = "System";




        this.Port = this.CreatePortNonModule(moduleName);






        this.Source = new SourceArray();



        this.Source.Init();







        this.Out = Console.Out;





        this.SystemResult = null;




        this.Result = null;




        this.ExecuteCompile();





        this.SystemResult = this.Result;





        this.Result = null;




        this.Port = null;





        this.Out = null;



        this.Source = null;




        this.Task = null;




        return true;
    }









    public bool ExecuteCompile()
    {
        this.Compile.Execute();





        this.Result = this.Compile.Result;




        return true;
    }






    private bool CreateFoldIfNotExist(string foldPath)
    {
        if (!Directory.Exists(foldPath))
        {
            Directory.CreateDirectory(foldPath);
        }


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




        bool kindModule;


        kindModule = this.Kind(this.TaskKindList.Module);



        if (kindModule | this.Kind(this.TaskKindList.Token))
        {
            if (!(this.Result.Token == null))
            {
                this.WriteErrors(this.Result.Token.Error);
            }
        }



        if (kindModule | this.Kind(this.TaskKindList.Node))
        {
            if (!(this.Result.Node == null))
            {
                this.WriteErrors(this.Result.Node.Error);
            }
        }



        if (kindModule | this.Kind(this.TaskKindList.Check))
        {
            if (!(this.Result.Check == null))
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





        ListIter treeIter;



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







    private PortPort CreatePortNonModule(string moduleName)
    {
        PortModuleName name;

        name = new PortModuleName();

        name.Init();

        name.Value = moduleName;




        PortModuleVer ver;

        ver = new PortModuleVer();

        ver.Init();

        


        PortImportList import;

        import = new PortImportList();

        import.Init();




        PortExportList export;

        export = new PortExportList();

        export.Init();




        PortEntry entry;

        entry = new PortEntry();

        entry.Init();





        PortPort o;


        o = new PortPort();


        o.Init();


        o.Name = name;


        o.Import = import;


        o.Export = export;


        o.Entry = entry;




        PortPort ret;

        ret = o;


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







    private bool SetSources(List files)
    {
        SourceArray t;


        t = new SourceArray();



        t.Count = files.Count;



        t.Init();




        int i;

        i = 0;



        ListIter iter;


        iter = files.Iter();



        while (iter.Next())
        {
            string filePath;


            filePath = (string)iter.Value;




            string fileName;
        
            fileName = Path.GetFileNameWithoutExtension(filePath);




            Source source;
            

            source = new Source();


            source.Init();
            

            source.Index = i;


            source.Name = fileName;


            source.Path = filePath;




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




            string[] array;


            array = File.ReadAllLines(source.Path);


            

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



        int i;

        i = 0;



        while (i < count)
        {
            string s;

            s = array[i];



            TextLine line;

            line = this.CreateTextLine(s);



            text.Line.Add(line);



            i = i + 1;
        }




        Text ret;

        ret = text;


        return ret;
    }






    private TextLine CreateTextLine(string s)
    {
        TextLine line;

        line = new TextLine();

        line.Init();



        char oc;



        int count;

        count = s.Length;
        


        int i;

        i = 0;


        while (i < count)
        {
            oc = s[i];



            line.Char.Add(oc);




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




    private bool CheckClassFiles(List files)
    {
        ListIter iter;


        iter = files.Iter();



        while (iter.Next())
        {
            string file;


            file = (string)iter.Value;



            if (!File.Exists(file))
            {
                return false;
            }
        }




        return true;
    }




    private bool Null(object o)
    {
        return o == null;
    }
}