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







    public override bool Init()
    {
        base.Init();





        this.TaskKindList = TaskKindList.This;





        this.ErrorWrite = true;




        this.ErrorString = new ErrorString();



        this.ErrorString.Class = this;



        this.ErrorString.Init();





        this.Compile = this.CreateCompile();





        this.InitSystem();






        return true;
    }







    public bool Execute()
    {
        bool taskModule;



        taskModule = (this.Task.Kind == this.TaskKindList.Module);





        List files;



        files = null;




        if (!taskModule)
        {
            string file;


            file = this.Task.Source;




            files = new List();


            files.Init();



            files.Add(file);




            string moduleName;


            moduleName = "Module";



            this.Port = this.CreatePortNonModule(moduleName);



            
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






            bool ba;
            
            ba = this.GetPort();
            

            if (!ba)
            {
                this.Error("Port Invalid");


                return false;
            }





            string classFold;
                
                

            classFold = this.ClassFold();




            files = this.GetClassFiles(classFold);
        }





        this.Out = this.Task.Out;





        this.SetSources(files);
                



        this.ReadCodes();
            
                
            

        this.ExecuteCompile();




        this.WriteErrors();




        if (this.Task.Print)
        {
            TaskKind t;


            t = this.Task.Kind;



            TaskKindList k;


            k = this.TaskKindList;




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




    protected virtual bool GetPort()
    {
        string portFile;



        portFile = Path.Combine(this.SourceFold, "Module.Port");




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





    protected virtual string ClassFold()
    {
        string s;
        
        
        s = Path.Combine(this.SourceFold, "Class");



        string ret;


        ret = s;


        return ret;
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




        PortVer ver;

        ver = new PortVer();

        ver.Init();

        


        PortImportList import;

        import = new PortImportList();

        import.Init();




        PortExportList export;

        export = new PortExportList();

        export.Init();







        PortPort o;


        o = new PortPort();


        o.Init();


        o.Name = name;


        o.Ver = ver;


        o.Import = import;


        o.Export = export;




        PortPort ret;

        ret = o;


        return ret;
    }





    private string[] GetFiles(string folderPath)
    {
        string[] u;
        
        
        u = Directory.GetFiles(folderPath);





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




        foreach (string s in u)
        {
            t.Add(s);
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



            text.Lines.Add(line);



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



            line.Chars.Add(oc);




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