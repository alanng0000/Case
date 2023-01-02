namespace Class.Check;






class ModuleNameRead : Object
{
    private TextInfra TextInfra { get; set; }




    private RangeInfra RangeInfra { get; set; }





    public Text Text { get; set; }




    public ModuleNameMap Result { get; set; }




    private int Row { get; set; }





    public override bool Init()
    {
        base.Init();



        this.TextInfra = new TextInfra();


        this.TextInfra.Init();




        this.RangeInfra = new RangeInfra();


        this.RangeInfra.Init();




        return true;
    }





    public bool Execute()
    {
        this.Result = new ModuleNameMap();


        this.Result.Init();





        this.TextInfra.Text = this.Text;



        this.Row = 0;



        while (this.TextInfra.CheckRow(this.Row))
        {
            this.ExecuteRow();
        }




        return true;
    }




    private bool ExecuteRow()
    {
        string s;


        s = this.LineText();



        




        this.Row = this.Row + 1;





        return true;
    }



    private string LineText()
    {
        TextLine line;


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





    private TextLine Line(int row)
    {
        return this.TextInfra.Line(row);
    }





    private bool Null(object o)
    {
        return o == null;
    }
}