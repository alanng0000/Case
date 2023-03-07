namespace Case;





public class Case : Object
{
    public SourceArray Source { get; set; }






    public PortPort Port { get; set; }





    public bool ErrorWrite { get; set; }





    public Task Task { get; set; }






    public Result Result { get; set; }






    internal Result SystemResult { get; set; }







    private TextWriter Out { get; set; }






    public Create Create { get; set; }








    private ErrorString ErrorString { get; set; }






    internal CheckRefer Refer { get; set; }







    private string SourceFold { get; set; }
    




    internal string Node { get; set; }






    public override bool Init()
    {
        base.Init();






        this.ErrorWrite = true;




        this.ErrorString = new ErrorString();



        this.ErrorString.Class = this;



        this.ErrorString.Init();





        this.Create = this.CreateCreate();





    





        this.CharOneList = new char[1];



        this.LineOneList = new TextLine[1];





        RangeInfra infra;

        infra = RangeInfra.This;



        this.OneRange = infra.Range(0, this.CharOneList.Length);
        



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

            
                
            

        this.ExecuteCreate();




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
        return true;
    }







    private bool CheckModuleVer(ModuleIntent intent, ModuleVer ver)
    {
        if (!(ver.Valu == 0))
        {
            return false;
        }


        return true;
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








    public bool ExecuteCreate()
    {
        this.Create.Execute();





        this.Result = this.Create.Result;




        return true;
    }








    protected virtual Create CreateCreate()
    {
        Create create;




        create = new Create();




        create.Class = this;




        create.Init();






        Create ret;



        ret = create;



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


            error = (Error)iter.Valu;




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
        ModeString moduleString;



        moduleString = new ModeString();




        moduleString.Init();




        moduleString.Execute(this.Result.Mode);




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


            source = (Source)sourceIter.Valu;





            Tree tree;


            tree = (Tree)treeIter.Valu;



            

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


            source = (Source)sourceIter.Valu;



            Code code;



            code = (Code)codeIter.Valu;





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


            fileName = (string)iter.Valu;






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


            source = (Source)iter.Valu;



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