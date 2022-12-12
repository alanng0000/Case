namespace Class.Tool.DelimitersSourceGen;




class Module
{
    private StringBuilder StringBuilder { get; set; }




    private string Indent { get; set; }



    private RangeInfra RangeInfra { get; set; }





    private Map DelimiterMap { get; set; }




    private List Names { get; set; }






    public bool Init()
    {
        char c;


        c = ' ';



        this.Indent = new string(c, 4);



        return true;
    }





    public bool Main()
    {
        this.StringBuilder = new StringBuilder();




        this.RangeInfra = new RangeInfra();





        List lines;
        
        
        lines = this.GetLines("Delimiters.txt");






        this.DelimiterMap = new Map();



        this.DelimiterMap.Compare = new StringCompare();



        this.DelimiterMap.Init();






        List delimiters;



        delimiters = new List();



        delimiters.Init();





        this.Names = new List();



        this.Names.Init();








        string allListName;


        allListName = "All";






        ListIter iter;


        iter = lines.Iter();




        while (iter.Next())
        {
            string line;

            line = (string)iter.Value;
            


            bool b;


            b = false;


            if (line == null)
            {
                b = true;
            }
            
            
            if (line == "")
            {
                b = true;
            }


            if (b)
            {
                continue;
            }







            int spaceIndex;


            spaceIndex = line.IndexOf(" ");




            if (spaceIndex < 0)
            {
                continue;
            }




            Range delimiterRange;


            delimiterRange = new Range();


            delimiterRange.Start = 0;


            delimiterRange.End = spaceIndex;




            int count;


            count = this.RangeInfra.Count(delimiterRange);




            string delimiter;

            
            delimiter = line.Substring(delimiterRange.Start, count);




            if (delimiters.Contain(delimiter))
            {
                continue;
            }



            delimiters.Add(delimiter);






            Range nameRange;
            
            
            nameRange = new Range();


            nameRange.Start = spaceIndex + 1;
            
            
            nameRange.End = line.Length;




            count = this.RangeInfra.Count(nameRange);





            string name;


            name = line.Substring(nameRange.Start, count);




            this.Names.Add(name);







            Pair pair;



            pair = new Pair();



            pair.Key = name;



            pair.Value = delimiter;





            this.DelimiterMap.Add(pair);






            this.AppendStringProperty(name);
        }




        this.AppendLine();


        this.AppendLine();





        this.AppendListProperty(allListName);

        

        this.AppendLine();


        this.AppendLine();




        this.AppendIndents(1)
            .Append("public").Append(" ")
            .Append("bool").Append(" ")
            .Append("Init")
            .Append("(").Append(")").AppendLine();

        this.AppendIndents(1)
            .Append("{").AppendLine();



        this.AppendSetDelimiters();



        this.AppendLine();



        this.AppendLine();



        this.AppendPropertyAssignment(allListName, this.Names);



        this.AppendLine();



        this.AppendLine();




        this.AppendIndents(2)
            .Append("return").Append(" ")
            .Append("true").Append(";").AppendLine();




        this.AppendIndents(1)
            .Append("}").AppendLine();





        string genString;


        genString = this.StringBuilder.ToString();





        string classTextFilePath;
        
        
        classTextFilePath = "Class.txt";





        string s;
        
        
        s = File.ReadAllText(classTextFilePath);




        string output;



        output = s.Replace("#HOLD#", genString);





        string outputFilePath;
        
        
        
        outputFilePath = "../../../../Class.Infra/Delimiters.cs";





        File.WriteAllText(outputFilePath, output);



        return true;
    }




    private bool AppendSetDelimiters()
    {
        ListIter iter;
        
        iter = this.Names.Iter();




        while (iter.Next())
        {
            string name;


            name = (string)iter.Value;




            this.AppendIndents(2)
                .Append("this").Append(".").Append(name).Append(" ")
                .Append("=").Append(" ");



            
            
            string delimiter;

            delimiter = (string)this.DelimiterMap.Get(name);




            string delimiterString;


            delimiterString = this.DelimiterString(delimiter);



            this.Append("\"").Append(delimiterString).Append("\"");
            



            this.Append(";").AppendLine();
        }



        return true;
    }





    private string DelimiterString(string delimiter)
    {
        string delimiterString;


        if (delimiter == "\\")
        {
            delimiterString = "\\" + delimiter;
        }
        else
        {
            delimiterString = delimiter;
        }



        string ret;


        ret = delimiterString;


        return ret;
    }





    private bool AppendListProperty(string name)
    {
        this.AppendIndents(1)
            .Append("public").Append(" ")
            .Append("List").Append(" ")
            .Append(name).Append(" ")
            .Append("{").Append(" ")
            .Append("get").Append(";").Append(" ")
            .Append("private").Append(" ")
            .Append("set").Append(";").Append(" ")
            .Append("}")
            .AppendLine();



        return true;
    }





    private bool AppendStringProperty(string name)
    {
        this.AppendIndents(1)
            .Append("public").Append(" ")
            .Append("string").Append(" ")
            .Append(name).Append(" ")
            .Append("{").Append(" ")
            .Append("get").Append(";").Append(" ")
            .Append("private").Append(" ").Append("set").Append(";").Append(" ")
            .Append("}")
            .AppendLine();


        return true;
    }




    private bool AppendPropertyAssignment(string name, List words)
    {
        this.AppendIndents(2)
            .Append("this").Append(".").Append(name).Append(" ")
            .Append("=").Append(" ")
            .Append("new").Append(" ")
            .Append("List").Append("(").Append(")").Append(";")
            .AppendLine();




        this.AppendIndents(2)
            .Append("this").Append(".").Append(name)
            .Append(".").Append("Init").Append("(").Append(")").Append(";")
            .AppendLine();





        ListIter iter;
        
        iter = words.Iter();



        while (iter.Next())
        {
            string word;
            word = (string)iter.Value;


            this.AppendIndents(2)
                .Append("this").Append(".").Append(name)
                .Append(".").Append("Add").Append("(")
                .Append("this").Append(".").Append(word)
                .Append(")")
                .Append(";").AppendLine();
        }



        return true;
    }





    private Module Append(string s)
    {
        this.StringBuilder.Append(s);

        return this;
    }




    private Module AppendLine()
    {
        this.Append("\n");



        return this;
    }





    private Module AppendIndents(int count)
    {
        int i;
        
        i = 0;

        while (i < count)
        {
            this.Append(this.Indent);



            i = i + 1;
        }

        return this;
    }





    private List GetLines(string filePath)
    {
        string[] u;
        
        u = File.ReadAllLines(filePath);



        Convert convert;


        convert = new Convert();



        List t;
        
        
        t = convert.List(u);



        List ret;


        ret = t;


        return ret;
    }
}