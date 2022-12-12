namespace Class.Test.Info.Object.TwoFields;






class Unit : global::Class.Test.Info.Unit
{
    public override bool Init()
    {
        base.Init();



        this.Name = "TwoFields";



        return true;
    }





    public override bool Execute()
    {
        string h;



        h = "Hig";




        Map map;


        map = new Map();


        map.Compare = new StringCompare();


        map.Init();




        string fieldNameA;


        fieldNameA = "B";



        bool fieldValueA;


        fieldValueA = false;





        Pair pairA;


        pairA = new Pair();


        pairA.Init();


        pairA.Key = fieldNameA;


        pairA.Value = fieldValueA;




        map.Add(pairA);





        string fieldNameB;


        fieldNameB = "K";




        ulong fieldValueB;


        fieldValueB = 57;





        Pair pairB;


        pairB = new Pair();


        pairB.Init();


        pairB.Key = fieldNameB;


        pairB.Value = fieldValueB;



        map.Add(pairB);





        string s;


        s = this.RootObjectText(h, map);




        InfoObject o;


        o = this.RootObject(s);




        if (this.Null(o))
        {
            return false;
        }




        bool ba;


        ba = (o.Class.Value == h);



        if (!ba)
        {
            return false;
        }




        InfoFields fields;


        fields = o.Fields;




        bool bb;


        bb = (fields.Count == 2);



        if (!bb)
        {
            return false;
        }




        ListIter iter;


        iter = fields.Iter();




        bool bc;


        bool bd;



        InfoField field;





        bc = iter.Next();


        if (!bc)
        {
            return false;
        }



        
        field = (InfoField)iter.Value;




        bd = this.MatchField(field, fieldNameA, fieldValueA);



        if (!bd)
        {
            return false;
        }






        bc = iter.Next();


        if (!bc)
        {
            return false;
        }




        field = (InfoField)iter.Value;




        bd = this.MatchField(field, fieldNameB, fieldValueB);



        if (!bd)
        {
            return false;
        }






        return true;
    }
}