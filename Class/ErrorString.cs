namespace Class;




class ErrorString : Object
{
    public Class Class { get; set; }



    private static readonly string LineEnd = "\n";



    private static readonly string BorderLine = "--------------------------------------------------";




    public string String(Error error)
    {
        StringBuilder sb;


        sb = new StringBuilder();



        this.AppendBorder(sb);




        this.AppendField(sb, "Kind", this.KindString(error));


            

        this.AppendField(sb, "Range", this.RangeString(error));

            

            
        this.AppendField(sb, "Source", this.SourceString(error));




        this.AppendBorder(sb);




        string s;

        s = sb.ToString();



        string ret;

        ret = s;


        return ret;
    }




    private bool AppendBorder(StringBuilder sb)
    {
        sb.Append(BorderLine).Append(LineEnd);



        return true;
    }




    private bool AppendField(StringBuilder sb, string word, string value)
    {
        sb
            .Append(word).Append(":").Append(" ")
            .Append(value)
            .Append(LineEnd);



        return true;
    }





    private string KindString(Error error)
    {
        string s;
            



        ErrorKind errorKind;




        errorKind = error.Kind;




        s = errorKind.Text;
            





        string ret;



        ret = s;



        return ret;
    }





    private string RangeString(Error error)
    {
        string s;



        s = this.TokenRangeString(error);
        
        


        string ret;



        ret = s;


        return ret;
    }






    private string TokenRangeString(Error error)
    {
        Range range;

        range = error.Range;




        StringBuilder sb;


        sb = new StringBuilder();



        sb
            .Append("(")
            .Append(range.Start)
            .Append(",").Append(" ")
            .Append(range.End)
            .Append(")");



        string s;

        s = sb.ToString();



        string ret;

        ret = s;


        return ret;
    }




    private string SourceString(Error error)
    {
        Source source;


        source = error.Source;




        string name;


        name = source.Name;


        return name;
    }
}