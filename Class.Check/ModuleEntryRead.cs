namespace Class.Check;






class ModuleNameRead : Object
{
    private TextInfra TextInfra { get; set; }




    private RangeInfra RangeInfra { get; set; }




    private Convert Convert { get; set; }





    public Text Text { get; set; }





    public ModuleEntryIntentMap IntentMap { get; set; }



    public ModuleEntryNameMap NameMap { get; set; }





    private int Row { get; set; }





    public override bool Init()
    {
        base.Init();



        this.TextInfra = new TextInfra();


        this.TextInfra.Init();




        this.RangeInfra = new RangeInfra();


        this.RangeInfra.Init();




        this.Convert = new Convert();


        this.Convert.Init();




        return true;
    }





    public bool Execute()
    {
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




        ulong k;

        k = this.Convert.ULong(this.Row);



        ulong index;

        index = k;





        ModuleIntent intent;

        intent = new ModuleIntent();

        intent.Init();

        intent.Value = index;




        ModuleName name;

        name = new ModuleName();

        name.Init();

        name.Value = s;






        Pair pairA;

        pairA = new Pair();

        pairA.Init();

        pairA.Key = intent;

        pairA.Value = name;



        this.IntentMap.Add(pairA);






        Pair pairB;

        pairB = new Pair();

        pairB.Init();

        pairB.Key = name;

        pairB.Value = intent;



        this.NameMap.Add(pairB);







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