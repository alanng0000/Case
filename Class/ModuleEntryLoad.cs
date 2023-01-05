namespace Class;






class ModuleEntryLoad : Object
{
    private Convert Convert { get; set; }





    public string RootPath { get; set; }





    private string EntryFileName
    {
        get
        {
            return "_";
        }
        set
        {
        }
    }




    private string EntryFilePath { get; set; }







    public ModuleEntryIntentMap IntentMap { get; set; }



    public ModuleEntryNameMap NameMap { get; set; }








    private int Row { get; set; }




    private string[] LineList { get; set; }


    



    public override bool Init()
    {
        base.Init();




        this.Convert = new Convert();


        this.Convert.Init();




        this.EntryFilePath = Path.Combine(this.RootPath, this.EntryFileName);




        return true;
    }





    public bool Execute()
    {
        string[] u;

        u = File.ReadAllLines(this.EntryFilePath);




        this.LineList = u;



        int rowCount;


        rowCount = this.LineList.Length;





        this.Row = 0;




        while (this.Row < rowCount)
        {
            this.ExecuteRow();
        }




        return true;
    }




    private bool ExecuteRow()
    {
        string s;


        s = this.LineList[this.Row];




        string line;

        line = s;




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

        name.Value = line;





        ModuleEntry entry;

        entry = new ModuleEntry();

        entry.Init();

        entry.Intent = intent;

        entry.Name = name;






        Pair pairA;

        pairA = new Pair();

        pairA.Init();

        pairA.Key = entry.Intent;

        pairA.Value = entry;



        this.IntentMap.Add(pairA);






        Pair pairB;

        pairB = new Pair();

        pairB.Init();

        pairB.Key = entry.Name;

        pairB.Value = entry;



        this.NameMap.Add(pairB);







        this.Row = this.Row + 1;





        return true;
    }
}