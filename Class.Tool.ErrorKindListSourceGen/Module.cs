namespace Class.Tool.ErrorKindListSourceGen;




class Module : Object
{
    private StringBuilder StringBuffer { get; set; }




    private List Names { get; set; }




    private string Indent { get; set; }





    private string Quote { get; set; }





    public bool Execute(string[] args)
    {
        string varNamespace;




        varNamespace = args[0];






        string baseClass;




        baseClass = args[1];






        string listFilePath;




        listFilePath = args[2];







        string outputFilePath;




        outputFilePath = args[3];








        this.StringBuffer = new StringBuilder();




        char spaceChar;



        spaceChar = ' ';




        this.Indent = new string(spaceChar, 4);





        this.Quote = "\"";






        List lines;
        
        

        lines = this.GetLines(listFilePath);





        this.Names = new List();



        this.Names.Init();




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






            string name;
            
            
            name = line;




            this.Names.Add(name);




            this.AppendIndents(1)
                .Append("public").Append(" ")
                .Append("ErrorKind").Append(" ")
                .Append(name).Append(" ")
                .Append("{").Append(" ")
                .Append("get").Append(";").Append(" ")
                .Append("private").Append(" ").Append("set").Append(";").Append(" ")
                .Append("}")
                .AppendLine();
        }




        this.AppendLine();



        this.AppendLine();



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
            .Append("base").Append(".")
            .Append("Init")
            .Append("(").Append(")")
            .Append(";").AppendLine();



        this.AppendLine();


        this.AppendLine();


        this.AppendLine();




        this.AppendSetErrorKinds();




        this.AppendLine();


        this.AppendLine();



        this.AppendIndents(2)
            .Append("return").Append(" ")
            .Append("true").Append(";").AppendLine();



        this.AppendIndents(1)
            .Append("}").AppendLine();







        string genString;




        genString = this.StringBuffer.ToString();






        string classTextFilePath;
        
        


        classTextFilePath = "Class.txt";





        string s;
        
        

        s = File.ReadAllText(classTextFilePath);







        string t;
        




        t = s.Replace("#NAMESPACE#", varNamespace);





        t = t.Replace("#BASECLASS#", baseClass);





        t = t.Replace("#MEMBERS#", genString);






        string output;




        output = t;
            




        File.WriteAllText(outputFilePath, output);




        return true;
    }





    private bool AppendSetErrorKinds()
    {
        ListIter iter;
        


        iter = this.Names.Iter();



        while (iter.Next())
        {
            string name;
            

            name = (string)iter.Value;



            this.AppendSetErrorKind(name);
        }



        return true;
    }





    private bool AppendSetErrorKind(string name)
    {
        this.AppendIndents(2)
            .Append("this").Append(".").Append(name).Append(" ")
            .Append("=").Append(" ")
            .Append("this").Append(".")
            .Append("AddKind")
            .Append("(")
            .Append(this.Quote).Append(name).Append(this.Quote)
            .Append(")")
            .Append(";")
            .AppendLine();



        this.AppendLine();



        return true;
    }





    private Module Append(string s)
    {
        this.StringBuffer.Append(s);

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