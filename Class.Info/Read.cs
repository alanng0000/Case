namespace Class.Info;





public class Read
{
    public bool Init()
    {
        this.RangeInfra = new RangeInfra();



        this.RangeInfra.Init();




        this.StringInfra = new StringInfra();



        this.StringInfra.Init();





        this.LeftSquareString = this.LeftSquare.ToString();




        this.RightSquareString = this.RightSquare.ToString();





        return true;
    }




    private RangeInfra RangeInfra { get; set; }




    private StringInfra StringInfra { get; set; }





    public Info Execute(string text)
    {
        this.Text = text;



        this.StringInfra.String = this.Text;





        this.Index = 0;



        this.Indent = 0;




        
        Info info;



        info = this.Info();




        if (this.Null(info))
        {
            return null;
        }




        Info ret;


        ret = info;



        return ret;
    }




    private Info Info()
    {
        int originalIndex;


        originalIndex = this.Index;




        Object o;



        o = this.Object();



        if (this.Null(o))
        {
            this.Index = originalIndex;



            return null;
        }




        bool ba;


        ba = this.NextComma();



        if (!ba)
        {
            this.Index = originalIndex;



            return null;
        }





        bool bb;


        bb = this.NextLineEnd();



        if (!bb)
        {
            this.Index = originalIndex;



            return null;
        }





        Info info;


        info = new Info();


        info.Object = o;





        Info ret;


        ret = info;



        return ret;
    }





    private Object Object()
    {
        Range text;



        text = this.Token();




        if (this.NullRange(text))
        {
            return null;
        }
        




        Object o;



        o = null;




        if (this.Null(o))
        {
            o = this.NullObject(text);
        }



        
        if (this.Null(o))
        {
            o = this.Constant(text);
        }



        
        if (this.Null(o))
        {
            o = this.ClassObject(text);
        }




        Object ret;


        ret = o;



        return ret;
    }




    private Null NullObject(Range text)
    {
        bool b;


        b = this.StringInfra.Equal(text, this.NullKeyword);



        if (!b)
        {
            return null;
        }




        Null o;


        o = new Null();





        int count;



        count = this.RangeInfra.Count(text);



        this.Index = this.Index + count;





        Null ret;


        ret = o;



        return ret;
    }





    private Constant Constant(Range text)
    {
        Constant o;


        o = null;




        if (this.Null(o))
        {
            o = this.BoolConstant(text);
        }




        if (this.Null(o))
        {
            o = this.IntConstant(text);
        }




        if (this.Null(o))
        {
            o = this.StringConstant(text);
        }




        if (this.Null(o))
        {
            o = this.ListConstant(text);
        }




        Constant ret;


        ret = o;


        return ret;
    }





    private BoolConstant BoolConstant(Range text)
    {
        bool ba;


        ba = this.StringInfra.Equal(text, this.TrueKeyword);




        bool bb;


        bb = this.StringInfra.Equal(text, this.FalseKeyword);




        if (!ba & !bb)
        {
            return null;
        }




        bool value;


        value = ba;






        BoolConstant o;


        o = new BoolConstant();


        o.Value = value;





        int count;



        count = this.RangeInfra.Count(text);



        this.Index = this.Index + count;





        BoolConstant ret;


        ret = o;



        return ret;
    }




    private IntConstant IntConstant(Range text)
    {
        ulong? u;


        u = this.StringInfra.IntValue(text);



        if (!u.HasValue)
        {
            return null;
        }
        



        ulong value;


        value = u.Value;





        IntConstant o;


        o = new IntConstant();


        o.Value = value;





        int count;


        count = this.RangeInfra.Count(text);





        this.Index = this.Index + count;






        IntConstant ret;


        ret = o;



        return ret;
    }





    private StringConstant StringConstant(Range text)
    {
        string t;


        t = this.StringInfra.Value(text);





        if (this.Null(t))
        {
            return null;
        }




        string value;



        value = t;






        StringConstant o;



        o = new StringConstant();



        o.Value = value;





        int count;



        count = this.RangeInfra.Count(text);



        this.Index = this.Index + count;






        StringConstant ret;



        ret = o;




        return ret;
    }





    private ListConstant ListConstant(Range text)
    {
        int originalIndex;



        originalIndex = this.Index;




        bool b;



        b = this.ListConstantStart(text);




        if (!b)
        {
            this.Index = originalIndex;



            return null;
        }







        this.Index = this.Index + this.LeftSquareString.Length;





        bool ba;



        ba = this.NextLineEnd();




        if (! ba)
        {
            this.Index = originalIndex;



            return null;
        }




        List t;


        t = new List();


        t.Init();




        bool h;


        h = true;




        while (h)
        {
            bool bb;


            bb = this.NextIndent();




            if (!bb)
            {
                this.Index = originalIndex;



                return null;
            }





            Range r;



            r = new Range();



            r.Start = this.Index;



            r.End = r.Start + 1;




            bool bc;


            bc = this.ListConstantEnd(r);





            if (!bc)
            {
                bool bd;


                bd = this.NextSpaces(this.InsideIndent);



                if (!bd)
                {
                    this.Index = originalIndex;


                    return null;
                }





                int originalIndent;



                originalIndent = this.Indent;




                this.Indent = this.Indent + this.InsideIndent;




                Object m;


                m = this.Object();




                this.Indent = originalIndent;





                if (this.Null(m))
                {
                    this.Index = originalIndex;



                    return null;
                }




                t.Add(m);





                bool be;


                be = this.NextComma();



                if (!be)
                {
                    this.Index = originalIndex;



                    return null;
                }




                bool bf;



                bf = this.NextLineEnd();




                if (! bf)
                {
                    this.Index = originalIndex;



                    return null;
                }
            }



            
            if (bc)
            {
                this.Index = this.Index + this.RightSquareString.Length;



                h = false;
            }
        }


        



        List value;



        value = t;




        ListConstant o;



        o = new ListConstant();



        o.Value = value;





        ListConstant ret;


        ret = o;



        return ret;
    }





    private Object ClassObject(Range text)
    {
        int originalIndex;



        originalIndex = this.Index;





        ClassName varClass;



        varClass = this.ClassName(text);





        if (this.Null(varClass))
        {
            this.Index = originalIndex;



            return null;
        }





        int u;



        u = this.RangeInfra.Count(text);




        this.Index = this.Index + u;





        bool ba;



        ba = this.NextLineEnd();




        if (!ba)
        {
            this.Index = originalIndex;



            return null;
        }




        bool bb;


        bb = this.NextIndent();



        if (!bb)
        {
            this.Index = originalIndex;



            return null;
        }




        bool bc;


        bc = this.NextLeftBrace();



        if (!bc)
        {
            this.Index = originalIndex;



            return null;
        }




        bool bd;


        bd = this.NextLineEnd();



        if (!bd)
        {
            this.Index = originalIndex;



            return null;
        }





        int originalIndent;



        originalIndent = this.Indent;





        this.Indent = this.Indent + this.InsideIndent;





        Fields h;



        h = this.Fields();





        this.Indent = originalIndent;






        if (this.Null(h))
        {
            this.Index = originalIndex;



            return null;
        }


        


        bool be;



        be = this.NextIndent();




        if (!be)
        {
            this.Index = originalIndex;



            return null;
        }






        bool bf;


        bf = this.NextRightBrace();



        if (!bf)
        {
            this.Index = originalIndex;



            return null;
        }






        Fields fields;



        fields = h;





        Object ret;



        ret = new Object();
        


        ret.Class = varClass;



        ret.Fields = fields;




        return ret;
    }






    private Fields Fields()
    {
        Fields j;


        j = new Fields();



        j.Init();





        Field field;



        field = this.Field();




        while (!this.Null(field))
        {
            j.Add(field);




            field = this.Field();
        }





        Fields ret;



        ret = j;




        return ret;
    }





    private Field Field()
    {
        int originalIndex;



        originalIndex = this.Index;




        bool ba;


        ba = this.NextIndent();



        if (!ba)
        {
            this.Index = originalIndex;




            return null;
        }




        Range t;



        t = this.Token();



        if (this.NullRange(t))
        {
            this.Index = originalIndex;




            return null;
        }




        FieldName fieldName;



        fieldName = this.FieldName(t);



        if (this.Null(fieldName))
        {
            this.Index = originalIndex;




            return null;
        }




        int j;



        j = this.RangeInfra.Count(t);




        this.Index = this.Index + j;





        bool bb;


        bb = this.NextSpaces(1);




        if (!bb)
        {
            this.Index = originalIndex;




            return null;
        }





        bool bc;


        bc = this.NextColon();



        if (!bc)
        {
            this.Index = originalIndex;



            return null;
        }



        
        bool bd;


        bd = this.NextSpaces(1);




        if (!bd)
        {
            this.Index = originalIndex;




            return null;
        }





        int originalIndent;


        originalIndent = this.Indent;




        int m;


        m = j + 1 + 1 + 1;




        this.Indent = this.Indent + m;




        Object d;


        d = this.Object();





        this.Indent = originalIndent;





        if (this.Null(d))
        {
            this.Index = originalIndex;




            return null;
        }





        bool be;



        be = this.NextComma();



        if (!be)
        {
            this.Index = originalIndex;




            return null;
        }





        bool bf;



        bf = this.NextLineEnd();




        if (!bf)
        {
            this.Index = originalIndex;




            return null;
        }







        Object value;


        value = d;





        Field ret;



        ret = new Field();



        ret.Name = fieldName;



        ret.Value = value;




        return ret;
    }
    






    private ClassName ClassName(Range text)
    {
        string t;



        t = this.NameValue(text);




        if (this.Null(t))
        {
            return null;
        }




        string value;


        value = t;




        ClassName ret;


        ret = new ClassName();


        ret.Value = value;



        return ret;
    }





    private FieldName FieldName(Range text)
    {
        string t;



        t = this.NameValue(text);




        if (this.Null(t))
        {
            return null;
        }




        string value;


        value = t;




        FieldName ret;


        ret = new FieldName();


        ret.Value = value;



        return ret;
    }





    private string NameValue(Range text)
    {
        int count;



        count = this.RangeInfra.Count(text);




        int i;



        i = 0;



        while (i < count)
        {
            int index;


            index = text.Start + i;




            char oc;


            oc = this.StringInfra.Char(index);




            bool b;


            b = this.IsLetter(oc);



            if (!b)
            {
                return null;
            }





            i = i + 1;
        }





        string t;



        t = this.StringInfra.Substring(text);





        string ret;


        ret = t;



        return ret;
    }








    private bool NextLineEnd()
    {
        return this.NextChar(this.LineEnd);
    }





    private bool NextComma()
    {
        return this.NextChar(this.Comma);
    }





    private bool NextColon()
    {
        return this.NextChar(this.Colon);
    }





    private bool NextLeftBrace()
    {
        return this.NextChar(this.LeftBrace);
    }




    private bool NextRightBrace()
    {
        return this.NextChar(this.RightBrace);
    }





    private bool NextChar(char m)
    {
        char o;



        o = this.StringInfra.Char(this.Index);




        bool b;



        b = (o == m);




        if (!b)
        {
            return false;
        }




        this.Index = this.Index + 1;



        return true;
    }







    private bool NextIndent()
    {
        return this.NextSpaces(this.Indent);
    }




    private bool NextSpaces(int count)
    {
        int i;


        i = 0;




        while (i < count)
        {
            int index;


            index = this.Index + i;




            char o;


            o = this.StringInfra.Char(index);




            bool b;


            b = (o == this.Space);

            

            if (!b)
            {
                return false;
            }




            i = i + 1;
        }




        this.Index = this.Index + count;



        return true;
    }







    private Range Token()
    {
        if (!this.Valid(this.Index))
        {
            return this.RangeInfra.Null;
        }




        char firstChar;



        firstChar = this.StringInfra.Char(this.Index);




        Range s;




        if (this.IsSpace(firstChar))
        {
            return this.RangeInfra.Null;
        }
        



        if (firstChar == this.Quote)
        {
            int endIndex;


            endIndex = -1;




            int i;


            i = this.Index + 1;




            bool h;


            h = true;



            while (h)
            {
                if (!this.Valid(i))
                {
                    endIndex = i;



                    h = false;
                }




                char o;

                o = '\0';



                if (h)
                {
                    o = this.StringInfra.Char(i);
                }
                


                if (h & o == this.Quote)
                {
                    endIndex = i + 1;



                    h = false;
                }




                if (h & o == this.LineEnd)
                {
                    endIndex = i;



                    h = false;
                }

                

                if (h & o == this.EscapeChar)
                {
                    int nextIndex;


                    nextIndex = i + 1;



                    if (this.Valid(nextIndex))
                    {
                        char nextChar;


                        nextChar = this.StringInfra.Char(nextIndex);




                        bool isQuote;


                        isQuote = (nextChar == this.Quote);




                        bool isEscapeChar;


                        isEscapeChar = (nextChar == this.EscapeChar);




                        if (isQuote)
                        {
                            i = nextIndex;
                        }



                        if (isEscapeChar)
                        {
                            i = nextIndex;
                        }
                    }
                }
                


                if (h)
                {
                    i = i + 1;
                }
            }
            



            Range r;


            r = new Range();


            r.Start = this.Index;


            r.End = endIndex;




            s = r;



            return s;
        }




        if (this.IsAlpha(firstChar))
        {
            int endIndex;



            endIndex = -1;




            int i;



            i = this.Index + 1;




            bool h;



            h = true;




            while (h)
            {
                if (!this.Valid(i))
                {
                    endIndex = i;



                    h = false;
                }




                char o;



                o = '\0';




                if (h)
                {
                    o = this.StringInfra.Char(i);
                }





                if (h & (!this.IsAlpha(o)))
                {
                    endIndex = i;




                    h = false;
                }



                if (h)
                {
                    i = i + 1;
                }
            }






            Range r;


            r = new Range();


            r.Start = this.Index;


            r.End = endIndex;




            s = r;




            return s;
        }
        




        Range ra;


        ra = new Range();


        ra.Start = this.Index;


        ra.End = ra.Start + 1;




        Range ret;
        
        
        ret = ra;




        return ret;
    }





    private bool ListConstantStart(Range text)
    {
        return this.StringInfra.Equal(text, this.LeftSquareString);
    }



    private bool ListConstantEnd(Range text)
    {
        return this.StringInfra.Equal(text, this.RightSquareString);
    }




    private bool NullRange(Range range)
    {
        return this.RangeInfra.NullRange(range);
    }





    private bool Valid(int index)
    {
        return this.StringInfra.Valid(index);
    }




    private bool Null(object o)
    {
        return o == null;
    }




    private bool IsSpace(char o)
    {
        return o == this.Space | o == this.LineEnd;
    }




    private bool IsAlpha(char o)
    {
        return this.StringInfra.IsAlphanumeric(o);
    }




    private bool IsDigit(char o)
    {
        return this.StringInfra.IsDigit(o);
    }




    private bool IsLetter(char o)
    {
        return this.StringInfra.IsLetter(o);
    }




    private bool IsLowerLetter(char o)
    {
        return this.StringInfra.IsLowerLetter(o);
    }



    private bool IsUpperLetter(char o)
    {
        return this.StringInfra.IsUpperLetter(o);
    }





    private string Text { get; set; }




    private int Index { get; set; }




    private char LineEnd { get; } = '\n';




    private char Comma { get; } = ',';




    private char Quote { get; } = '\"';




    private char Space { get; } = ' ';




    private char NChar { get; } = 'n';




    private char EscapeChar { get; } = '\\';




    private char Colon { get; } = ':';




    private char LeftBrace { get; } = '{';




    private char RightBrace { get; } = '}';




    private char LeftSquare { get; } = '[';




    private char RightSquare { get; } = ']';




    private string LeftSquareString { get; set; }




    private string RightSquareString { get; set; }




    private string NullKeyword { get; } = "null";




    private string TrueKeyword { get; } = "true";




    private string FalseKeyword { get; } = "false";





    private int InsideIndent { get; } = 4;




    private int Indent { get; set; }
}