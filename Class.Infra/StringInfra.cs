namespace Class.Infra;




public class StringInfra
{
    public bool Init()
    {
        this.Constant = Constant.This;





        this.Ranges = new RangeInfra();



        this.Ranges.Init();




        return true;
    }




    private string S;




    private RangeInfra Ranges { get; set; }




    private Constant Constant { get; set; }




    public string String
    {
        get
        {
            return this.S;
        }
        set
        {
            this.S = value;
        }
    }








    public bool Equal(Range range, string other)
    {
        int count;
            
        count = this.Ranges.Count(range);


        if (count != other.Length)
        {
            return false;
        }


        int start;

        start = range.Start;


        int i;
        i = 0;

        while (i < count)
        {
            if (this.S[start + i] != other[i])
            {
                return false;
            }


            i++;
        }


        return true;
    }



    public string Substring(Range range)
    {
        if (!this.Check(range))
        {
            return null;
        }
        


        int length;

        length = this.Ranges.Count(range);


        return this.S.Substring(range.Start, length);
    }




    public bool Valid(int index)
    {
        bool b;


        b = (index >= 0) & (index < this.String.Length);



        bool ret;


        ret = b;


        return ret;
    }



    public char Char(int index)
    {
        return this.S[index];
    }




    public bool StartWith(Range range, char code)
    {
        if (!this.Check(range))
        {
            return false;
        }



        if (this.Ranges.Count(range) < 1)
        {
            return false;
        }


        bool ret;

        ret = (this.S[range.Start] == code);


        return ret;
    }





    public bool EndWith(Range range, char code)
    {
        if (!this.Check(range))
        {
            return false;
        }



        if (this.Ranges.Count(range) < 1)
        {
            return false;
        }


        bool ret;

        ret = (this.S[range.End - 1] == code);


        return ret;
    }





    private bool Check(Range range)
    {
        bool ba;


        ba = (range.Start < 0);



        bool bb;
        
        
        bb = (this.S.Length < range.End);



        bool b;


        b = (!ba & !bb);



        bool ret;


        ret = b;


        return ret;
    }




    public string Value(Range s)
    {
        int t;



        t = this.Ranges.Count(s);




        if (t < 2)
        {
            return null;
        }




        if (! this.IsQuote(s.Start))
        {
            return null;
        }





        int count;


        count = t - 1;






        StringBuilder sb;


        sb = new StringBuilder();




        int start;



        start = s.Start + 1;




        int index;




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



            c = this.Char(index);



            b = (c == this.Constant.BackSlash);
            
            

            if (b)
            {
                j = i + 1;



                bb = (j < count - 1);



                if (bb)
                {
                    u = this.Char(start + j);


                    
                    if (u == this.Constant.Quote)
                    {
                        escapeValue = u;
                    }
                    else if (u == 't')
                    {
                        escapeValue = this.Constant.Tab;
                    }
                    else if (u == 'n')
                    {
                        escapeValue = this.Constant.NewLine;
                    }
                    else if (u == this.Constant.BackSlash)
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



                if (! bb)
                {
                    return null;
                }
            }




            if (! b)
            {
                bb = (c == this.Constant.Quote);




                bc = (i == count - 1);




                if (bb)
                {
                    if (! bc)
                    {
                        return null;
                    }
                }
                



                if (! bb)
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




    public ulong? IntValue(Range text)
    {
        ulong j;


        j = 0;




        int count;


        count = this.Ranges.Count(text);




        ulong magnitude;


        magnitude = 1;





        int i;


        i = 0;



        while (i < count)
        {
            int index;


            index = count - i - 1;




            int sc;


            sc = text.Start + index;




            char ob;


            ob = this.Char(sc);




            if (!this.IsDigit(ob))
            {
                return null;
            }




            if (magnitude >= 1000000000000)
            {
                return null;
            }




            ulong digit;


            digit = this.Digit(ob);





            ulong t;



            t = digit * magnitude;





            j = j + t;




            magnitude = magnitude * 10;




            i = i + 1;
        }





        ulong value;



        value = j;




        ulong ret;


        ret = value;


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


        t = t.Replace("\r", "\\r");


        string ret;
        ret = t;

        return ret;
    }





    private ulong Digit(char o)
    {
        ulong u;


        u = o;




        ulong h;


        h = '0';

        


        ulong t;


        t = (u - h);




        ulong ret;


        ret = t;


        return ret;
    }






    public bool IsAlphanumeric(char o)
    {
        return this.IsLetter(o) | this.IsDigit(o);
    }




    public bool IsDigit(char o)
    {
        return '0' <= o && o <= '9';
    }




    public bool IsLetter(char o)
    {
        return this.IsLowerLetter(o) | this.IsUpperLetter(o);
    }




    public bool IsLowerLetter(char o)
    {
        return 'a' <= o & o <= 'z';
    }



    public bool IsUpperLetter(char o)
    {
        return 'A' <= o & o <= 'Z';
    }






    private bool IsQuote(int charIndex)
    {
        char oc;




        oc = this.Char(charIndex);




        bool b;



        b = (oc == this.Constant.Quote);




        bool ret;



        ret = b;



        return ret;
    }
}