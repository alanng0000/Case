namespace Class.Test;




public class Test
{
    public virtual bool Init()
    {
        this.LangName = this.LanguageName();




        this.UnitIndex = 0;




        this.PassCount = 0;




        this.Sets = new List();




        this.Sets.Init();







        this.TestFold = "Test";






        this.Spaces = new string(' ', 4);




        this.PathSeparator = "/";


        

        
        this.Class = this.CreateClass();




        this.Strings = new ModuleStrings();



        this.Strings.Init();





        string newCurrentDirectory = this.CurrentDirectory();



        Directory.SetCurrentDirectory(newCurrentDirectory);





        this.OriginalCurrentDirectory = Directory.GetCurrentDirectory();









        this.AddSets();





        StringCompare compare;


        compare = new StringCompare();


        compare.Init();





        this.FoldSetMap = new Map();



        this.FoldSetMap.Compare = compare;



        this.FoldSetMap.Init();





        this.AddFoldSets();




        return true;
    }







    protected virtual string CurrentDirectory()
    {
        return "../../../../Class.Test";
    }




    protected virtual bool AddSets()
    {
        //this.AddSet(new Module.Set());




        return true;
    }




    protected virtual bool AddFoldSets()
    {
        TaskKindList kinds;


        kinds = TaskKindList.This;




        this.AddFoldSet("Token", kinds.Token, false, false, false);



        this.AddFoldSet("Node", kinds.Node, true, false, false);
        


        this.AddFoldSet("Check", kinds.Check, false, true, false);



        return true;
    }





    protected bool AddSet(Set set)
    {
        set.Test = this;



        set.Init();




        this.Sets.Add(set);




        return true;
    }





    protected bool AddFoldSet(string name, TaskKind kind, bool addKindAfterTaskArg, bool addPathAfterTaskArg, bool sourceFold)
    {
        FoldSet set;




        set = new FoldSet();





        set.Name = name;





        set.Kind = kind;






        set.AddKindAfterTaskArg = addKindAfterTaskArg;





        set.AddPathAfterTaskArg = addPathAfterTaskArg;





        set.SourceFold = sourceFold;






        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = set.Name;


        pair.Value = set;




        this.FoldSetMap.Add(pair);



        return true;
    }




    private string LangName { get; set; }





    private List Sets { get; set; }



    private Set Set { get; set; }




    private string TestFold { get; set; }


    private List FoldUnits { get; set; }




    private Map FoldSetMap { get; set; }


    private FoldSet FoldSet { get; set; }


    private FoldUnit FoldUnit { get; set; }


    private int PassCount { get; set; }


    private ClassClass Class { get; set; }


    private string UnitFolder { get; set; }


    private Exception Error { get; set; }


    private StringWriter Writer { get; set; }




    private string OriginalCurrentDirectory { get; set; }





    private string Spaces { get; set; } = new string(' ', 4);




    private string PathSeparator { get; set; }






    private int UnitIndex { get; set; }





    private Unit CurrentUnit { get; set; }





    private bool UnitPass { get; set; }





    public ModuleStrings Strings { get; set; }



    


    public bool Execute()
    {
        this.ExecuteFoldSets();



        this.ExecuteSets();



        return true;
    }





    private bool ExecuteSets()
    {
        ListIter setIter;



        setIter = this.Sets.Iter();



        while (setIter.Next())
        {
            Set set;



            set = (Set)setIter.Value;


            this.Set = set;



            this.ExecuteSet();



            this.Set = null;
        }



        return true;
    }



    private bool ExecuteSet()
    {
        this.WriteHeader(this.Set.Name);





        this.UnitIndex = 0;



        this.PassCount = 0;





        ListIter kindIter;



        kindIter = this.Set.Kinds.Iter();




        while (kindIter.Next())
        {
            Kind kind;



            kind = (Kind)kindIter.Value;





            ListIter unitIter;



            unitIter = kind.Units.Iter();



            while (unitIter.Next())
            {
                Unit unit;


                unit = (Unit)unitIter.Value;




                this.CurrentUnit = unit;



                this.ExecuteUnit();



                
                this.WriteUnitResult();




                this.UnitIndex = this.UnitIndex + 1;
            }
        }



        this.WriteTotalResult();



        return true;
    }
    



    private bool ExecuteFoldSets()
    {
        MapIter iter;


        iter = this.FoldSetMap.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;



            this.FoldSet = (FoldSet)pair.Value;



            this.AddFoldSetUnits();



            this.ExecuteFoldSet();



            this.FoldSet = null;
        }



        return true;
    }



    private bool AddFoldSetUnits()
    {
        this.FoldUnits = new List();



        this.FoldUnits.Init();






        string set;

        set = this.FoldSet.Name;

        
        

        string setFolder;
            
        setFolder = this.TestFold + PathSeparator + set;





        string[] kinds;

        kinds = this.GetFolders(setFolder);



        IEnumerator kindsIter;
        

        kindsIter = kinds.GetEnumerator();
            

        while (kindsIter.MoveNext())
        {
            string kind;

            kind = (string)kindsIter.Current;




            string kindFolder;


            kindFolder = setFolder + PathSeparator + kind;




            string[] units;
            
            units = this.GetFolders(kindFolder);




            IEnumerator unitsIter;
            
            
            unitsIter = units.GetEnumerator();


            while (unitsIter.MoveNext())
            {
                string unit;


                unit = (string)unitsIter.Current;




                string unitFolder;
                

                unitFolder = kindFolder + PathSeparator + unit;




                string expectFile;
                
                
                expectFile = unitFolder + PathSeparator + "Expect";


                


                string expect;
                
                
                
                expect = File.ReadAllText(expectFile);






                string path;



                path = null;



                if (this.FoldSet.AddPathAfterTaskArg)
                {
                    string pathFile;


                    pathFile = unitFolder + PathSeparator + "Path";




                    path = File.ReadAllText(pathFile);
                }
                




                FoldUnit foldUnit;


                foldUnit = new FoldUnit();
                

                foldUnit.Set = this.FoldSet;
                

                foldUnit.Kind = kind;
                

                foldUnit.Unit = unit;
                

                foldUnit.Expect = expect;
                


                foldUnit.Path = path;




                this.FoldUnits.Add(foldUnit);
            }
        }




        return true;
    }




    private bool ExecuteFoldSet()
    {
        this.WriteHeader(this.FoldSet.Name);





        this.PassCount = 0;



        this.UnitIndex = 0;




        ListIter iter;
        

        iter = this.FoldUnits.Iter();



        while (iter.Next())
        {
            this.FoldUnit = (FoldUnit)iter.Value;



            this.ExecuteFoldUnit();



            this.WriteFoldResult();



            this.FoldUnit = null;



            this.UnitIndex = this.UnitIndex + 1;
        }




        this.WriteTotalResult();




        return true;
    }




    private bool ExecuteUnit()
    {
        bool pass;



        pass = this.CurrentUnit.Execute();



        this.UnitPass = pass;




        return true;
    }





    private bool ExecuteFoldUnit()
    {
        this.UnitFolder = this.TestFold + "/" + this.FoldUnit.Set.Name + "/" + this.FoldUnit.Kind + "/" + this.FoldUnit.Unit;



        this.Writer = new StringWriter();





        Directory.SetCurrentDirectory(this.UnitFolder);







        Task task;



        task = this.Task();



        this.Class.Task = task;
    


        this.Class.Execute();




        Directory.SetCurrentDirectory(this.OriginalCurrentDirectory);





        string actual;
        

        actual = this.Writer.ToString();




        string actualFile;
        

        actualFile = this.UnitFolder + "/" + "Actual";




        File.WriteAllText(actualFile, actual);



        this.FoldUnit.Actual = actual;





        bool pass;

        pass = (this.FoldUnit.Actual == this.FoldUnit.Expect);




        this.UnitPass = pass;




        return true;
    }





    protected virtual string LanguageName()
    {
        return "Class";
    }






    private bool WriteFoldResult()
    {
        this.WriteResult(this.UnitPass, this.FoldUnit.Set.Name, this.FoldUnit.Kind, this.FoldUnit.Unit);



        return true;
    }







    private bool WriteUnitResult()
    {
        Unit unit;


        unit = this.CurrentUnit;




        Kind kind;


        kind = unit.Kind;




        Set set;


        set = kind.Set;



        this.WriteResult(this.UnitPass, set.Name, kind.Name, unit.Name);


        return true;
    }





    private bool WriteResult(bool pass, string set, string kind, string unit)
    {
        string a;



        a = null;




        bool b;


        b = pass;



        if (b)
        {
            a = "Pass";


            this.PassCount = this.PassCount + 1;
        }
        


        if (!b)
        {
            a = "Fail";
        }






        string u;

        u = string.Format("{0,-8}", set);




        string k;

        k = string.Format("{0,-24}", kind);




        string j;


        j = unit;





        int number;


        number = (this.UnitIndex + 1);




        string p;


        p = number.ToString("D3");





        string s;



        s = p + this.Spaces + a + this.Spaces + u + this.Spaces + k + " " + j;




        Console.WriteLine(s);




        return true;
    }






    private bool WriteTotalResult()
    {
        string t;



        int unitCount;



        unitCount = this.UnitIndex;
        



        if (this.PassCount == unitCount)
        {
            t = "All";
        }
        else
        {
            t = this.PassCount.ToString();
        }



        Console.WriteLine(t + " " + "Pass");




        return true;
    }





    private bool WriteHeader(string setName)
    {
        string s;


        s = this.LangName.ToUpper();




        string k;


        k = setName.ToUpper();




        Console.WriteLine("==============================" + " " + s + " " + k + " " + "TEST" + " " + "===============================");



        return true;
    }






    public ModuleResult CompileResult
    {
        get
        {
            return this.Class.Result.Module;
        }

        set
        {
        }
    }






    private string SourceFold { get; set; }







    public bool ClassTask(string sourceFold)
    {
        this.SourceFold = sourceFold;





        Task task;



        task = this.Task();




        this.SourceFold = null;




        this.Class.Task = task;




        this.Class.Execute();






        return true;
    }







    private Task Task()
    {
        bool b;


        b = (this.FoldUnit == null);




        Task task;


        task = new Task();


        task.Init();




        TaskKind kind;


        kind = TaskKindList.This.Module;




        if (!b)
        {
            kind = this.FoldUnit.Set.Kind;
        }




        task.Kind = kind;



        

        if (!b)
        {
            bool ba;


            ba = this.FoldSet.AddKindAfterTaskArg;



            if (ba)
            {
                task.Node = this.FoldUnit.Kind;
            }



            if (!ba)
            {
                if (!(task.Kind == TaskKindList.This.Token))
                {
                    task.Node = "Class";
                }
            }





            if (this.FoldSet.AddPathAfterTaskArg)
            {
                task.Check = this.FoldUnit.Path;
            }




            task.Print = true;
        }





        string source;



        source = this.SourceFold;




        if (!b)
        {
            bool setSourceFold;



            setSourceFold = this.FoldSet.SourceFold;




            if (setSourceFold)
            {
                source = "Source";
            }




            if (!setSourceFold)
            {
                source = "Code";
            }
        }



        task.Source = source;





        task.Out = this.Writer;


        



        Task ret;
        

        ret = task;
        
        
        return ret;
    }







    protected virtual ClassClass CreateClass()
    {
        ClassClass t;



        t = new ClassClass();



        t.Init();





        ClassClass ret;


        ret = t;


        return ret;
    }





    private bool ExecutePort()
    {
        



        return true;
    }






    private string[] GetFolders(string foldPath)
    {
        string[] u;
            
            
        u = Directory.GetDirectories(foldPath);




        int i;

        i = 0;


        while (i < u.Length)
        {
            string path;

            path = u[i];



            string name;

            name = Path.GetFileName(path);



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
}