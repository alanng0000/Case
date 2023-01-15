namespace Class.Infra;





public class StringInfra : Object
{
    public override bool Init()
    {
        base.Init();



        this.TextInfra = new TextInfra();


        this.TextInfra.Init();



        return true;
    }





    private TextInfra TextInfra { get; set; }

    


    public Text Text
    { 
        get
        {
            return this.TextData;
        }
        set
        {
            this.TextData = value;


            this.TextInfra.Text = this.TextData;
        } 
    }




    private Text TextData { get; set; }







    public string Value(int row, Range range)
    {
        RangeInfra rangeInfra;

        rangeInfra = RangeInfra.This;




        if (rangeInfra.Count(range) < 2)
        {
            return null;
        }




        if (!this.IsQuote(this.Pos(row, range.Start)))
        {
            return null;
        }




        Constant constant;


        constant = Constant.This;




        int count;


        count = rangeInfra.Count(range) - 1;






        StringBuilder sb;


        sb = new StringBuilder();




        int start;



        start = range.Start + 1;




        int index;





        Pos pos;

        pos = this.Pos(row, 0);




        Pos posA;

        posA = this.Pos(row, 0);




        char c;




        bool b;



        bool bb;



        bool bc;



        int j;




        char u;




        char escapeValue;




        int i;


        i = 0;





        while (i < count)
        {
            index = start + i;



            pos.Col = index;



            c = this.Char(pos);



            b = (c == constant.BackSlash);
            
            

            if (b)
            {
                j = i + 1;



                bb = (j < count - 1);



                if (bb)
                {
                    posA.Col = start + j;



                    u = this.Char(posA);



                    
                    if (u == constant.Quote)
                    {
                        escapeValue = u;
                    }
                    else if (u == 't')
                    {
                        escapeValue = constant.Tab;
                    }
                    else if (u == 'n')
                    {
                        escapeValue = constant.NewLine;
                    }
                    else if (u == constant.BackSlash)
                    {
                        escapeValue = u;
                    }
                    else
                    {
                        return null;
                    }


                    sb.Append(escapeValue);



                    i = i + 1;
                }



                if (!bb)
                {
                    return null;
                }
            }




            if (!b)
            {
                bb = (c == constant.Quote);




                bc = (i == count - 1);




                if (bb)
                {
                    if (!bc)
                    {
                        return null;
                    }
                }
                



                if (!bb)
                {
                    if (bc)
                    {
                        return null;
                    }



                    sb.Append(c);
                }
            }




            i = i + 1;
        }




        string ret;

        ret = sb.ToString();


        return ret;
    }






    public string EscapeString(string s)
    {
        string t;
        
        
        t = s;


        t = t.Replace("\\", "\\\\");


        t = t.Replace("\"", "\\\"");


        t = t.Replace("\t", "\\t");


        t = t.Replace("\n", "\\n");



        string ret;
        ret = t;

        return ret;
    }






    private Pos Pos(int row, int col)
    {
        return this.TextInfra.Pos(row, col);
    }





    private char Char(Pos pos)
    {
        return this.TextInfra.Char(pos);
    }






    private bool IsQuote(Pos pos)
    {
        Constant constant;

        constant = Constant.This;



        char oc;




        oc = this.Char(pos);




        bool b;



        b = (oc == constant.Quote);




        bool ret;



        ret = b;



        return ret;
    }
}