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





        this.StringInfra = new StringInfra();



        this.StringInfra.Init();

        



        return true;
    }





    private TextInfra TextInfra { get; set; }





    private RangeInfra RangeInfra { get; set; }





    private StringInfra StringInfra { get; set; }






    public Text Text { get; set; }





    private int Row { get; set; }





    public Port Execute()
    {
        this.TextInfra.Text = this.Text;



        ModuleName name;

        name = this.ModuleName();




        this.NextRow();




        Ver ver;

        ver = this.Ver();



        this.NextRow();




        this.NextRow();
        



        ulong? o;


        o = this.IntValue();



        if (!o.HasValue)
        {
            return null;
        }



        ulong importCount;


        importCount = o.Value;


        
        this.NextRow();
        


        this.NextRow();





        return null;
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




        ModuleName ret;

        ret = new ModuleName();

        ret.Init();

        ret.Value = value;


        return ret;
    }





    private Ver Ver()
    {
        ulong? o;

        o = this.IntValue();



        if (!o.HasValue)
        {
            return null;
        }



        ulong value;

        value = o.Value;




        Ver ret;

        ret = new Ver();

        ret.Init();

        ret.Value = value;


        return ret;
    }




    private ulong? IntValue()
    {
        string s;


        s = this.LineText();



        this.StringInfra.String = s;





        Range range;


        range = this.Range(0, s.Length);




        ulong? o;


        o = this.StringInfra.IntValue(range);




        ulong? ret;

        ret = o;


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



        string ret;

        ret = s;

        return ret;
    }





    private Range Range(int start, int end)
    {
        Range range;

        range = new Range();

        range.Init();

        range.Start = start;

        range.End = end;


        Range ret;

        ret = range;


        return ret;
    }






    private Line Line(int row)
    {
        return (Line)this.Text.Lines.Get(row);
    }
}