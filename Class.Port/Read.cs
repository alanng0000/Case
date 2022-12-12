namespace Class.Port;





public class Read
{
    public bool Init()
    {
        this.TextInfra = new TextInfra();



        this.TextInfra.Init();




        this.RangeInfra = new RangeInfra();



        this.RangeInfra.Init();

        



        return true;
    }



    private TextInfra TextInfra { get; set; }





    private RangeInfra RangeInfra { get; set; }






    public string Text { get; set; }





    public Port Execute()
    {
        InfoRead infoRead;


        infoRead = new InfoRead();



        infoRead.Init();




        InfoInfo info;


        info = infoRead.Execute(this.Text);




        if (this.Null(info))
        {
            return null;
        }




        InfoObject root;


        root = info.Object;





        Port port;


        port = this.Port(root);




        if (this.Null(port))
        {
            return null;
        }
        




        Port ret;


        ret = port;



        return ret;
    }





    private Port Port(InfoObject o)
    {
        bool ba;


        ba = this.CheckClass(o, "Port");



        if (!ba)
        {
            return null;
        }




        IIter iter;


        iter = o.Fields.Iter();





        InfoObject mo;


        mo = this.FieldValue(iter, "Module");



        if (this.Null(mo))
        {
            return null;
        }





        string sa;


        sa = this.StringConstant(mo);



        if (this.Null(sa))
        {
            return null;
        }






        ModuleName module;



        module = this.ModuleName(sa);



        if (this.Null(module))
        {
            return null;
        }





        InfoObject ao;


        ao = this.FieldValue(iter, "Imports");



        if (this.Null(ao))
        {
            return null;
        }
        




        Imports imports;



        imports = this.Imports(ao);



        if (this.Null(imports))
        {
            return null;
        }





        InfoObject bo;


        bo = this.FieldValue(iter, "Exports");



        if (this.Null(bo))
        {
            return null;
        }
        




        Exports exports;



        exports = this.Exports(bo);



        if (this.Null(exports))
        {
            return null;
        }





        if (!this.FieldsEnd(iter))
        {
            return null;
        }
        




        Port ret;


        ret = new Port();


        ret.Module = module;


        ret.Imports = imports;


        ret.Exports = exports;


        return ret;
    }
    





    private ModuleName ModuleName(string s)
    {
        int o;


        o = s.IndexOf(':');



        if (o < 0)
        {
            return null;
        }




        string sa;


        sa = s.Substring(0, o);





        string value;


        value = this.ModuleNameValue(sa);



        if (this.Null(value))
        {
            return null;
        }




        int m;


        m = o + 1;




        string sb;


        sb = s.Substring(m);





        ModuleVerse verse;


        verse = this.ModuleVerse(sb);



        if (this.Null(verse))
        {
            return null;
        }





        ModuleName ret;


        ret = new ModuleName();


        ret.Value = value;


        ret.Verse = verse;


        return ret;
    }




    private string ModuleNameValue(string s)
    {
        if (!this.IsModuleNameValue(s))
        {
            return null;
        }



        return s;
    }




    private string VerseString { get; set; }




    private int VerseStringIndex { get; set; }
    




    private ModuleVerse ModuleVerse(string s)
    {
        this.VerseString = s;



        this.VerseStringIndex = 0;




        ulong? u;



        u = this.NextVersePart();



        if (!u.HasValue)
        {
            return null;
        }



        ulong primary;


        primary = u.Value;





        u = this.NextVersePart();



        if (!u.HasValue)
        {
            return null;
        }



        ulong secondary;


        secondary = u.Value;




    
        u = this.NextVersePart();



        if (!u.HasValue)
        {
            return null;
        }



        ulong tertiary;


        tertiary = u.Value;





        u = this.NextVersePart();



        if (!u.HasValue)
        {
            return null;
        }



        ulong quaternary;


        quaternary = u.Value;





        bool b;


        b = (this.VerseStringIndex == this.VerseString.Length + 1);


        if (!b)
        {
            return null;
        }





        ModuleVerse ret;


        ret = new ModuleVerse();


        ret.Primary = primary;


        ret.Secondary = secondary;


        ret.Tertiary = tertiary;


        ret.Quaternary = quaternary;



        return ret;
    }




    private int NextVersePartEnd(string s, int startIndex)
    {
        int o;


        o = s.IndexOf('.', startIndex);



        if (o < 0)
        {
            return s.Length;
        }



        int ret;


        ret = o;


        return ret;
    }





    private ulong? NextVersePart()
    {
        int o;


        o = this.NextVersePartEnd(this.VerseString, this.VerseStringIndex);




        Range range;


        range = new Range();


        range.Start = this.VerseStringIndex;


        range.End = o;




        ulong? u;


        u = this.VersePartValue(this.VerseString, range);



        if (!u.HasValue)
        {
            return null;
        }




        ulong value;


        value = u.Value;




        this.VerseStringIndex = o + 1;




        ulong ret;


        ret = value;


        return ret;
    }





    private ulong? VersePartValue(string s, Range range)
    {
        ulong? u;



        u = this.IntValue(s, range);



        if (!u.HasValue)
        {
            return null;
        }




        ulong value;


        value = u.Value;




        ulong ret;


        ret = value;


        return ret;
    }







    private ulong? IntValue(string s, Range range)
    {
        ulong j;


        j = 0;




        int count;


        count = this.RangeInfra.Count(range);




        ulong magnitude;


        magnitude = 1;





        int i;


        i = 0;



        while (i < count)
        {
            int index;


            index = count - i - 1;




            int sc;


            sc = range.Start + index;




            char ob;


            ob = s[sc];




            if (!this.TextInfra.IsDigit(ob))
            {
                return null;
            }




            if (magnitude >= 1000000000000)
            {
                return null;
            }




            ulong digit;


            digit = this.TextInfra.Digit(ob);





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






    private ClassName ClassName(string s)
    {
        if (!this.IsStringName(s))
        {
            return null;
        }
        



        ClassName ret;


        ret = new ClassName();


        ret.Value = s;


        return ret;
    }






    private bool IsModuleNameValue(string s)
    {
        Range range;



        range = new Range();



        range.Start = 0;



        range.End = 0;






        bool ba;




        ba = range.Start < s.Length;




        if (!ba)
        {
            return false;
        }





        int dotIndex;



        dotIndex = s.IndexOf('.', range.Start);



        
        bool bb;




        bool bc;


        bc = (dotIndex < 0);



        while (!bc)
        {
            range.End = dotIndex;





            bb = this.IsName(s, range);




            if (!bb)
            {
                return false;
            }




            range.Start = range.End + 1;





            ba = range.Start < s.Length;



            if (!ba)
            {
                return false;
            }



            dotIndex = s.IndexOf('.', range.Start);



            bc = (dotIndex < 0);
        }




        range.End = s.Length;




        bb = this.IsName(s, range);




        if (!bb)
        {
            return false;
        }



        return true;
    }






    private bool IsStringName(string s)
    {
        Range range;


        range = new Range();


        range.Start = 0;


        range.End = s.Length;



        return this.IsName(s, range);
    }




    private bool IsName(string s, Range range)
    {
        int count;


        count = this.RangeInfra.Count(range);




        bool b;


        b = (count == 0);



        if (b)
        {
            return false;
        }




        int i;


        i = 0;


        while (i < count)
        {
            int index;


            index = range.Start + i;



            char oc;
            

            oc = s[index];



            bool bb;


            bb = this.TextInfra.IsLetter(oc);



            if (!bb)
            {
                return false;
            }



            i = i + 1;
        }



        return true;
    }





    private Imports Imports(InfoObject o)
    {
        List u;



        u = this.ListConstant(o);




        if (this.Null(u))
        {
            return null;
        }






        Imports t;



        t = new Imports();



        t.Init();





        IIter iter;


        iter = u.Iter();




        while (iter.Next())
        {
            InfoObject jo;


            jo = (InfoObject)iter.Value;




            Import import;



            import = this.Import(jo);




            if (this.Null(import))
            {
                global::System.Console.WriteLine("Read Imports() import is null");


                return null;
            }




            t.Add(import);
        }




        Imports ret;


        ret = t;



        return ret;
    }

    




    private Import Import(InfoObject o)
    {
        bool ba;


        ba = this.CheckClass(o, "Import");


        if (!ba)
        {
            return null;
        }





        IIter iter;


        iter = o.Fields.Iter();




        

        InfoObject ao;


        ao = this.FieldValue(iter, "Class");



        if (this.Null(ao))
        {
            return null;
        }





        string classPath;



        classPath = this.StringConstant(ao);




        if (this.Null(classPath))
        {
            return null;
        }





        int? u;


        u = this.ModuleStringLength(classPath);



        if (!u.HasValue)
        {
            return null;
        }




        int n;


        n = u.Value;




        string sa;


        sa = this.ModuleString(classPath, n);




        if (this.Null(sa))
        {
            return null;
        }




        ModuleName module;


        module = this.ModuleName(sa);



        if (this.Null(module))
        {
            return null;
        }





        string sb;



        sb = this.ClassString(classPath, n);



        if (this.Null(sb))
        {
            return null;
        }





        ClassName varClass;


        varClass = this.ClassName(sb);



        if (this.Null(varClass))
        {
            return null;
        }






        InfoObject bo;


        bo = this.FieldValue(iter, "Name");



        if (this.Null(bo))
        {
            return null;
        }





        string sc;



        sc = this.StringConstant(bo);




        if (this.Null(sc))
        {
            return null;
        }





        ClassName name;



        name = this.ClassName(sc);



        if (this.Null(sc))
        {
            return null;
        }






        if (!this.FieldsEnd(iter))
        {
            return null;
        }





        Import ret;


        ret = new Import();


        ret.Module = module;


        ret.Class = varClass;


        ret.Name = name;



        return ret;
    }





    private Exports Exports(InfoObject o)
    {
        List u;



        u = this.ListConstant(o);




        if (this.Null(u))
        {
            return null;
        }






        Exports t;



        t = new Exports();



        t.Init();





        IIter iter;


        iter = u.Iter();




        while (iter.Next())
        {
            InfoObject jo;


            jo = (InfoObject)iter.Value;




            Export export;



            export = this.Export(jo);




            if (this.Null(export))
            {
                return null;
            }




            t.Add(export);
        }




        Exports ret;


        ret = t;



        return ret;
    }






    private string ModuleString(string s, int length)
    {
        return s.Substring(0, length);
    }





    private int? ModuleStringLength(string s)
    {
        char separaterChar;


        separaterChar = ':';




        int o;


        o = s.IndexOf(separaterChar);


        if (o < 0)
        {
            return null;
        }




        int m;


        m = o + 1;



        o = s.IndexOf(separaterChar, m);



        if (o < 0)
        {
            return null;
        }
        


        int ret;


        ret = o;


        return ret;
    }





    private string ClassString(string s, int separaterIndex)
    {
        int startIndex;


        startIndex = separaterIndex + 1;



        return s.Substring(startIndex);
    }






    private Export Export(InfoObject o)
    {
        bool ba;


        ba = this.CheckClass(o, "Export");


        if (!ba)
        {
            return null;
        }






        IIter iter;


        iter = o.Fields.Iter();



        

        InfoObject ao;


        ao = this.FieldValue(iter, "Class");



        if (this.Null(ao))
        {
            return null;
        }





        string sa;



        sa = this.StringConstant(ao);




        if (this.Null(sa))
        {
            return null;
        }





        ClassName varClass;



        varClass = this.ClassName(sa);




        if (this.Null(varClass))
        {
            return null;
        }
        




        if (!this.FieldsEnd(iter))
        {
            return null;
        }






        Export ret;


        ret = new Export();


        ret.Class = varClass;



        return ret;
    }






    private bool? BoolConstant(InfoObject o)
    {
        bool ba;


        ba = (o is InfoBoolConstant);



        if (!ba)
        {
            return null;
        }




        InfoBoolConstant h;



        h = (InfoBoolConstant)o;





        bool b;



        b = h.Value;





        bool ret;


        ret = b;


        return ret;
    }







    private ulong? IntConstant(InfoObject o)
    {
        bool ba;


        ba = (o is InfoIntConstant);



        if (!ba)
        {
            return null;
        }




        InfoIntConstant h;


        h = (InfoIntConstant)o;




        ulong k;



        k = h.Value;




        ulong ret;


        ret = k;


        return ret;
    }




    private string StringConstant(InfoObject o)
    {
        bool ba;


        ba = (o is InfoStringConstant);



        if (!ba)
        {
            return null;
        }




        InfoStringConstant h;



        h = (InfoStringConstant)o;





        string s;



        s = h.Value;





        string ret;


        ret = s;


        return ret;
    }




    private List ListConstant(InfoObject o)
    {
        bool ba;



        ba = (o is InfoListConstant);



        if (!ba)
        {
            return null;
        }




        InfoListConstant h;



        h = (InfoListConstant)o;




        List u;



        u = h.Value;





        List ret;



        ret = u;



        return ret;         
    }






    private bool NullObject(InfoObject o)
    {
        bool b;


        b = (o is InfoNull);



        if (!b)
        {
            return false;
        }



        return true;
    }



    

    private bool FieldsEnd(IIter fieldIter)
    {
        bool b;


        b = fieldIter.Next();



        if (b)
        {
            return false;
        }



        return true;
    }





    private InfoObject FieldValue(IIter fieldIter, string fieldName)
    {
        bool b;


        b = fieldIter.Next();



        if (!b)
        {
            return null;
        }




        InfoField field;
        
        

        field = (InfoField)fieldIter.Value;




        bool ba;



        ba = (field.Name.Value == fieldName);




        if (!ba)
        {
            return null;
        }




        InfoObject o;
        


        o = field.Value;




        InfoObject ret;


        ret = o;


        return ret;
    }





    private bool CheckClass(InfoObject o, string className)
    {
        InfoClassName j;


        j = o.Class;




        bool ba;



        ba = this.Null(j);




        if (ba)
        {
            return false;
        }




        bool bb;



        bb = (j.Value == className);




        if (!bb)
        {
            return false;
        }



        return true;
    }





    private bool Null(object o)
    {
        return o == null;
    }
}