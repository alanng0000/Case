namespace Class.Port;





public class Read : Object
{
    public override bool Init()
    {
        base.Init();




        this.TextInfra = new TextInfra();



        this.TextInfra.Init();




        this.RangeInfra = new RangeInfra();



        this.RangeInfra.Init();


        



        return true;
    }





    private TextInfra TextInfra { get; set; }





    private RangeInfra RangeInfra { get; set; }






    public Text Text { get; set; }





    private int Row { get; set; }






    public Port Execute()
    {
        this.TextInfra.Text = this.Text;



        this.Row = 0;




        Port module;

        module = this.Module();


        if (this.Null(module))
        {
            return null;
        }




        Port ret;

        ret = module;


        return ret;
    }






    private Port Module()
    {
        ModuleName name;


        name = this.ModuleName();



        if (this.Null(name))
        {
            return null;
        }





        this.NextRow();




        ModuleVer ver;

        ver = this.ModuleVer();


        if (this.Null(ver))
        {
            return null;
        }




        this.NextRow();






        this.NextRow();
        





        ImportList importList;


        importList = this.ImportList();



        if (this.Null(importList))
        {
            return null;
        }




        this.NextRow();






        ExportList exportList;


        exportList = this.ExportList();



        if (this.Null(exportList))
        {
            return null;
        }





        this.NextRow();









        Entry entry;


        entry = this.Entry();


        if (this.Null(entry))
        {
            return null;
        }
        




        Port ret;


        ret = new Port();


        ret.Init();


        ret.Name = name;


        ret.Ver = ver;


        ret.Import = importList;


        ret.Export = exportList;


        ret.Entry = entry;


        return ret;
    }






    private ImportList ImportList()
    {
        ulong? o;


        o = this.IntValue();



        if (!o.HasValue)
        {
            return null;
        }




        ulong k;


        k = o.Value;




        int count;


        count = (int)k;



        
        this.NextRow();







        ImportList list;


        list = new ImportList();


        list.Init();





        int i;

        i = 0;


        while (i < count)
        {
            this.NextRow();



            Import import;


            import = this.Import();



            if (this.Null(import))
            {
                return null;
            }




            list.Add(import);




            i = i + 1;
        }




        ImportList ret;


        ret = list;


        return ret;
    }





    private Import Import()
    {
        ModuleName module;


        module = this.ModuleName();



        if (this.Null(module))
        {
            return null;
        }



        this.NextRow();





        ModuleVer ver;


        ver = this.ModuleVer();



        if (this.Null(ver))
        {
            return null;
        }



        this.NextRow();






        ClassName varClass;


        varClass = this.ClassName();



        if (this.Null(varClass))
        {
            return null;
        }



        this.NextRow();





        ClassName name;


        name = this.ClassName();



        if (this.Null(name))
        {
            return null;
        }



        this.NextRow();





        Import ret;


        ret = new Import();


        ret.Init();


        ret.Module = module;


        ret.Ver = ver;


        ret.Class = varClass;


        ret.Name = name;


        return ret;
    }







    private ExportList ExportList()
    {
        ulong? o;


        o = this.IntValue();



        if (!o.HasValue)
        {
            return null;
        }




        ulong k;


        k = o.Value;




        int count;


        count = (int)k;



        
        this.NextRow();




        this.NextRow();






        ExportList list;


        list = new ExportList();


        list.Init();





        int i;

        i = 0;


        while (i < count)
        {
            Export export;


            export = this.Export();



            if (this.Null(export))
            {
                return null;
            }




            list.Add(export);




            i = i + 1;
        }




        ExportList ret;


        ret = list;


        return ret;
    }








    private Export Export()
    {
        ClassName varClass;


        varClass = this.ClassName();



        if (this.Null(varClass))
        {
            return null;
        }



        this.NextRow();






        Export ret;


        ret = new Export();


        ret.Init();


        ret.Class = varClass;


        return ret;
    }






    private Entry Entry()
    {
        ClassName varClass;


        varClass = this.ClassName();




        this.NextRow();






        Entry ret;


        ret = new Entry();


        ret.Init();


        ret.Class = varClass;


        return ret;
    }







    private bool NextRow()
    {
        int row;


        row = this.Row;



        row = row + 1;



        this.Row = row;


        return true;
    }





    private ModuleName ModuleName()
    {
        string value;


        value = this.LineText();



        if (this.Null(value))
        {
            return null;
        }




        ModuleName ret;

        ret = new ModuleName();

        ret.Init();

        ret.Value = value;


        return ret;
    }





    private ClassName ClassName()
    {
        string value;


        value = this.LineText();



        if (this.Null(value))
        {
            return null;
        }




        ClassName ret;

        ret = new ClassName();

        ret.Init();

        ret.Value = value;


        return ret;
    }





    private ModuleVer ModuleVer()
    {
        ulong? o;

        o = this.IntValue();



        if (!o.HasValue)
        {
            return null;
        }



        ulong value;

        value = o.Value;




        ModuleVer ret;

        ret = new ModuleVer();

        ret.Init();

        ret.Value = value;


        return ret;
    }




    private ulong? IntValue()
    {
        string s;


        s = this.LineText();



        if (this.Null(s))
        {
            return null;
        }




        ulong k;




        bool b;


        b = ulong.TryParse(s, out k);



        if (!b)
        {
            return null;
        }




        ulong? ret;

        ret = k;


        return ret;
    }




    private string LineText()
    {
        Line line;


        line = this.Line(this.Row);



        int end;
        
        end = line.Chars.Count;



        Range range;

        range = this.Range(0, end);




        string s;


        s = this.TextInfra.Substring(this.Row, range);



        if (this.Null(s))
        {
            return null;
        }



        string ret;

        ret = s;

        return ret;
    }







    private Range Range(int start, int end)
    {
        return this.RangeInfra.Range(start, end);
    }




    private Line Line(int row)
    {
        return this.TextInfra.Line(row);
    }




    private bool Null(object o)
    {
        return o == null;
    }
}