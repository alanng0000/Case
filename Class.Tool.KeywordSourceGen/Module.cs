namespace Class.Tool.KeywordSourceGen;




class Module : Object
{
    private StringBuilder StringBuilder { get; set; }




    private string Indent { get; set; }



    private RangeInfra RangeInfra { get; set; }




    private List Names { get; set; }






    public bool Execute()
    {
        this.StringBuilder = new StringBuilder();




        this.RangeInfra = new RangeInfra();





        char spaceCode;
        
        spaceCode = ' ';



        this.Indent = new string(spaceCode, 4);



        List lines;


        lines = this.GetLines("Keyword.txt");





        this.Names = new List();


        this.Names.Init();





        List accessNames;


        accessNames = new List();



        accessNames.Init();





        string allListName;
        
        allListName = "All";



        string accessListName;

        accessListName = "Access";




        bool isAccess;
        isAccess = false;



        ListIter iter;
        
        iter = lines.Iter();



        while (iter.Next())
        {
            string line;

            
            line = (string)iter.Value;
                

            if (line == null)
            {
                continue;
            }


            if (line == "")
            {
                continue;
            }


            if (line == "ACCESS")
            {
                isAccess = true;

                continue;
            }



            string firstChar;
            
            
            firstChar = char.ToUpper(line[0]).ToString();




            Range t;
            
            t = new Range();
            

            t.Start = firstChar.Length;
            
            t.End = line.Length;




            int count;



            count = this.RangeInfra.Count(t);



            
            string name;
            

            name = firstChar + line.Substring(t.Start, count);



            if (this.Names.Contain(name))
            {
                continue;
            }


            this.Names.Add(name);



            if (isAccess)
            {
                accessNames.Add(name);
            }


            this.AppendIndents(1)
                .Append("public").Append(" ")
                .Append("string").Append(" ")
                .Append(name).Append(" ")
                .Append("{").Append(" ")
                .Append("get").Append(";").Append(" ")
                .Append("private").Append(" ").Append("set").Append(";").Append(" ")
                .Append("}")
                .AppendLine();
        }



        this.AppendLine();



        this.AppendLine();



        this.AppendListProperty(allListName);



        this.AppendLine();


        this.AppendLine();



        this.AppendListProperty(accessListName);



        this.AppendLine();


        this.AppendLine();




        this.AppendIndents(1)
            .Append("public").Append(" ")
            .Append("override").Append(" ")
            .Append("bool").Append(" ")
            .Append("Init")
            .Append("(").Append(")").AppendLine();



        this.AppendIndents(1)
            .Append("{").AppendLine();






        this.AppendIndents(2)
            .Append("base").Append(".").Append("Init").Append("(").Append(")").Append(";");




        this.AppendLine();



        this.AppendLine();



        this.AppendLine();




        this.AppendSetKeywords();



        this.AppendLine();


        this.AppendLine();



        this.AppendPropertyAssignment(allListName, this.Names);



        this.AppendLine();


        this.AppendLine();



        this.AppendPropertyAssignment(accessListName, accessNames);



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
        
        
        outputFilePath = "../../../../Class.Infra/Keyword.cs";
            




        File.WriteAllText(outputFilePath, output);



        return true;
    }





    private void AppendSetKeywords()
    {
        ListIter iter;
        
        
        iter = this.Names.Iter();




        while (iter.Next())
        {
            string name;

            name = (string)iter.Value;




            string keyword;

            keyword = name.ToLower();



            this.AppendIndents(2)
                .Append("this").Append(".").Append(name).Append(" ")
                .Append("=").Append(" ")
                .Append("\"").Append(keyword).Append("\"")
                .Append(";")
                .AppendLine();
        }
    }




    private void AppendListProperty(string name)
    {
        AppendIndents(1)
            .Append("public").Append(" ")
            .Append("List").Append(" ")
            .Append(name).Append(" ")
            .Append("{").Append(" ")
            .Append("get").Append(";").Append(" ")
            .Append("protected").Append(" ")
            .Append("set").Append(";").Append(" ")
            .Append("}")
            .AppendLine();
    }




    private void AppendPropertyAssignment(string name, List words)
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