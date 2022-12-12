namespace Class.Test.Info;






class Unit : global::Class.Test.Unit
{
    public override bool Init()
    {
        base.Init();





        this.InsideIndent = new string(this.Space, 4);




        this.AfterRootObjectText = "" + this.Comma + this.LineEnd;




        return true;
    }





    protected bool ReadNull()
    {
        InfoRead read;



        read = new InfoRead();



        read.Init();




        string text;



        text = this.NullText() + this.AfterRootObjectText;





        InfoInfo info;




        info = read.Execute(text);
        



        if (this.Null(info))
        {
            return false;
        }





        InfoObject o;


        o = info.Object;



        if (this.Null(o))
        {
            return false;
        }




        bool b;


        b = (o is InfoNull);



        if (!b)
        {
            return false;
        }




        return true;
    }





    protected virtual bool ReadBoolConstant(bool value)
    {
        InfoRead read;



        read = new InfoRead();



        read.Init();






        string t;



        t = this.BoolConstantText(value);






        string text;



        text = t + this.AfterRootObjectText;





        InfoInfo info;




        info = read.Execute(text);
        




        if (this.Null(info))
        {
            return false;
        }





        InfoObject o;


        o = info.Object;



        if (this.Null(o))
        {
            return false;
        }





        bool b;


        b = (o is InfoBoolConstant);



        if (!b)
        {
            return false;
        }




        InfoBoolConstant g;



        g = (InfoBoolConstant)o;





        bool k;



        k = g.Value;
        




        bool ba;



        ba = (k == value);




        if (!ba)
        {
            return false;
        }




        return true;
    }




    protected virtual bool ReadIntConstant(ulong value)
    {
        InfoRead read;



        read = new InfoRead();



        read.Init();






        string t;



        t = this.IntConstantText(value);





        string text;



        text = t + this.AfterRootObjectText;





        InfoInfo info;




        info = read.Execute(text);
        




        if (this.Null(info))
        {
            return false;
        }





        InfoObject o;


        o = info.Object;



        if (this.Null(o))
        {
            return false;
        }





        bool b;


        b = (o is InfoIntConstant);



        if (!b)
        {
            return false;
        }




        InfoIntConstant g;



        g = (InfoIntConstant)o;





        ulong k;



        k = g.Value;
        




        bool ba;



        ba = (k == value);




        if (!ba)
        {
            return false;
        }




        return true;
    }






    protected virtual bool ReadStringConstant(string value)
    {
        InfoRead read;



        read = new InfoRead();



        read.Init();






        string t;


        t = this.StringConstantText(value);





        string text;



        text = t + this.AfterRootObjectText;





        InfoInfo info;




        info = read.Execute(text);
        




        if (this.Null(info))
        {
            return false;
        }





        InfoObject o;


        o = info.Object;



        if (this.Null(o))
        {
            return false;
        }





        bool b;


        b = (o is InfoStringConstant);



        if (!b)
        {
            return false;
        }




        InfoStringConstant g;



        g = (InfoStringConstant)o;





        string k;



        k = g.Value;
        




        bool ba;



        ba = (k == value);




        if (!ba)
        {
            return false;
        }




        return true;
    }




    private string NullText()
    {
        return "null";
    }




    private string BoolConstantText(bool value)
    {
        string t;


        t = null;



        if (value)
        {
            t = "true";
        }



        if (!value)
        {
            t = "false";
        }




        string ret;


        ret = t;


        return ret;
    }






    private string IntConstantText(ulong value)
    {
        return value.ToString();
    }





    private string StringConstantText(string value)
    {
        StringBuilder builder;



        builder = new StringBuilder();




        builder.Append(this.Quote);





        int count;



        count = value.Length;





        int i;



        i = 0;



        while (i < count)
        {
            char oc;



            oc = value[i];



            bool b;


            b = false;




            if (oc == this.Backslash)
            {
                builder.Append(this.Backslash);


                builder.Append(this.Backslash);



                b = true;
            }




            if (oc == this.Quote)
            {
                builder.Append(this.Backslash);


                builder.Append(this.Quote);



                b = true;
            }




            if (oc == this.LineEnd)
            {
                builder.Append(this.Backslash);


                builder.Append(this.NChar);



                b = true;
            }




            if (oc == this.Tab)
            {
                builder.Append(this.Backslash);


                builder.Append(this.TChar);


                b = true;
            }





            if (!b)
            {
                builder.Append(oc);
            }




            i = i + 1;
        }




        builder.Append(this.Quote);



        

        string t;



        t = builder.ToString();





        string ret;



        ret = t;



        return ret;
    }





    private string ValueText(object o)
    {
        if (o == null)
        {
            return this.NullText();
        }



        if (o is bool)
        {
            bool b;


            b = (bool)o;



            return this.BoolConstantText(b);
        }



        if (o is ulong)
        {
            ulong k;


            k = (ulong)o;



            return this.IntConstantText(k);
        }



        if (o is string)
        {
            string t;


            t = (string)o;



            return this.StringConstantText(t);
        }



        return null;
    }





    protected InfoObject RootObject(string text)
    {
        InfoRead read;




        read = new InfoRead();
        



        read.Init();





        InfoInfo info;


        info = read.Execute(text);



        if (this.Null(info))
        {
            return null;
        }





        InfoObject o;


        o = info.Object;



        if (this.Null(o))
        {
            return null;
        }





        InfoObject ret;



        ret = o;



        return ret;
    }





    protected string RootObjectText(string className, Map map)
    {
        StringBuilder builder;



        builder = new StringBuilder();



        builder.Append(className);



        builder.Append(this.LineEnd);





        builder.Append(this.LeftBrace);



        builder.Append(this.LineEnd);





        MapIter iter;


        iter = map.Iter();




        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;





            string key;


            key = (string)pair.Key;





            object value;


            value = pair.Value;





            string valueText;



            valueText = this.ValueText(value);





            builder.Append(this.InsideIndent);




            builder.Append(key);




            builder.Append(this.Space);




            builder.Append(this.Colon);




            builder.Append(this.Space);





            builder.Append(valueText);




            builder.Append(this.Comma);




            builder.Append(this.LineEnd);
        }






        builder.Append(this.RightBrace);



        builder.Append(this.AfterRootObjectText);




        string t;



        t = builder.ToString();




        string ret;


        ret = t;



        return ret;
    }





    protected bool ReadListConstant(List list)
    {
        StringBuilder builder;



        builder = new StringBuilder();



        builder.Append(this.LeftSquare);



        builder.Append(this.LineEnd);





        ListIter iter;


        iter = list.Iter();


        while (iter.Next())
        {
            object m;



            m = iter.Value;




            string s;



            s = this.ValueText(m);



            builder.Append(this.InsideIndent);



            builder.Append(s);



            builder.Append(this.Comma);



            builder.Append(this.LineEnd);
        }





        builder.Append(this.RightSquare);



        builder.Append(this.AfterRootObjectText);





        string t;



        t = builder.ToString();






        InfoRead read;



        read = new InfoRead();



        read.Init();





        InfoInfo info;



        info = read.Execute(t);






        if (this.Null(info))
        {
            return false;
        }





        InfoObject o;


        o = info.Object;



        if (this.Null(o))
        {
            return false;
        }





        bool b;


        b = (o is InfoListConstant);



        if (!b)
        {
            return false;
        }




        InfoListConstant g;



        g = (InfoListConstant)o;






        List value;



        value = g.Value;





        int count;
        


        count = value.Count;





        bool ba;



        ba = (count == list.Count);




        if (!ba)
        {
            return false;
        }





        ListIter iterA;



        iterA = value.Iter();





        ListIter iterB;



        iterB = list.Iter();






        int i;



        i = 0;




        while (i < count)
        {
            iterA.Next();




            iterB.Next();




            InfoObject oa;


            oa = (InfoObject)iterA.Value;




            object ob;


            ob = iterB.Value;




            

            bool c;


            c = this.Match(oa, ob);




            if (!c)
            {
                return false;
            }




            i = i + 1;
        }





        return true;
    }





    protected bool ReadListConstantListConstant(List list)
    {
        StringBuilder builder;



        builder = new StringBuilder();






        builder.Append(this.LeftSquare);



        builder.Append(this.LineEnd);




        builder.Append(this.InsideIndent);



        builder.Append(this.LeftSquare);



        builder.Append(this.LineEnd);





        ListIter iter;


        iter = list.Iter();


        while (iter.Next())
        {
            object m;



            m = iter.Value;




            string s;



            s = this.ValueText(m);




            builder.Append(this.InsideIndent);




            builder.Append(this.InsideIndent);



            builder.Append(s);



            builder.Append(this.Comma);



            builder.Append(this.LineEnd);
        }






        builder.Append(this.InsideIndent);



        builder.Append(this.RightSquare);



        builder.Append(this.Comma);



        builder.Append(this.LineEnd);





        builder.Append(this.RightSquare);



        builder.Append(this.AfterRootObjectText);






        string t;



        t = builder.ToString();






        InfoRead read;



        read = new InfoRead();



        read.Init();





        InfoInfo info;



        info = read.Execute(t);






        if (this.Null(info))
        {
            return false;
        }





        InfoObject o;


        o = info.Object;



        if (this.Null(o))
        {
            return false;
        }





        bool b;


        b = (o is InfoListConstant);



        if (!b)
        {
            return false;
        }





        InfoListConstant g;



        g = (InfoListConstant)o;






        List valueG;



        valueG = g.Value;






        ListIter iterK;



        iterK = valueG.Iter();





        bool bj;


        bj = iterK.Next();



        if (!bj)
        {
            return false;
        }




        object d;


        d = iterK.Value;





        bool bk;



        bk = (d is InfoListConstant);



        if (!bk)
        {
            return false;
        }





        InfoListConstant h;



        h = (InfoListConstant)d;





        List value;



        value = h.Value;





        int count;
        


        count = value.Count;





        bool ba;



        ba = (count == list.Count);




        if (!ba)
        {
            return false;
        }





        ListIter iterA;



        iterA = value.Iter();





        ListIter iterB;



        iterB = list.Iter();






        int i;



        i = 0;




        while (i < count)
        {
            iterA.Next();




            iterB.Next();




            InfoObject oa;


            oa = (InfoObject)iterA.Value;




            object ob;


            ob = iterB.Value;




            

            bool c;


            c = this.Match(oa, ob);




            if (!c)
            {
                return false;
            }




            i = i + 1;
        }





        return true;
    }





    protected bool MatchField(InfoField field, string fieldName, object o)
    {
        bool ba;


        ba = (field.Name.Value == fieldName);



        if (!ba)
        {
            return false;
        }



        InfoObject value = field.Value;


        

        bool bb;


        bb = this.Match(value, o);



        if (!bb)
        {
            return false;
        }



        return true;
    }





    private bool Match(InfoObject infoObject, object o)
    {
        if (infoObject is InfoNull)
        {
            return o == null;
        }



        if (infoObject is InfoBoolConstant)
        {
            InfoBoolConstant c;


            c = (InfoBoolConstant)infoObject;



            bool ca;


            ca = (o is bool);



            if (!ca)
            {
                return false;
            }



            bool b;


            b = (bool)o;



            return c.Value == b;
        }





        if (infoObject is InfoIntConstant)
        {
            InfoIntConstant c;


            c = (InfoIntConstant)infoObject;



            bool ca;


            ca = (o is ulong);



            if (!ca)
            {
                return false;
            }



            ulong k;


            k = (ulong)o;



            return c.Value == k;
        }



        if (infoObject is InfoStringConstant)
        {
            InfoStringConstant c;


            c = (InfoStringConstant)infoObject;



            bool ca;


            ca = (o is string);



            if (!ca)
            {
                return false;
            }



            string s;


            s = (string)o;



            return c.Value == s;
        }




        return false;
    }







    protected char Quote { get; } = '\"';




    protected char Backslash { get; } = '\\';




    protected char LineEnd { get; } = '\n';




    private char Tab { get; } = '\t';




    private char NChar { get; } = 'n';




    private char TChar { get; } = 't';




    protected char Comma { get; } = ',';




    protected char Space { get; } = ' ';




    protected char Colon { get; } = ':';




    protected char LeftSquare { get; } = '[';




    protected char RightSquare { get; } = ']';





    protected char LeftBrace { get; } = '{';




    protected char RightBrace { get; } = '}';





    protected string InsideIndent { get; set; }





    protected string AfterRootObjectText { get; set; }
}