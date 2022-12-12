namespace Class.Node;





public struct NodeListIter : IIter
{
    private NodeList Array { get; set; }




    private int Index { get; set; }




    private int CurrentIndex { get; set; }




    internal bool Init(NodeList array)
    {
        this.Array = array;



        this.Index = 0;



        this.CurrentIndex = -1;



        return true;
    }




    private bool Contain(int index)
    {
        if (index < 0)
        {
            return false;
        }



        bool b;


        b = (index < this.Array.Count);



        bool ret = b;


        return ret;
    }





    public bool Next()
    {
        bool b;


        b = this.Contain(this.Index);





        if (b)
        {
            this.CurrentIndex = this.Index;




            this.Index = this.Index + 1;
        }



        return b;
    }




    public object Value
    {
        get
        {
            return this.Array[this.CurrentIndex];
        }

        set
        {
        }
    }



    public object Key
    {
        get
        {
            return this.CurrentIndex;
        }

        set
        {
        }
    }
}