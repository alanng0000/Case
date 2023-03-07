namespace Case.Toke;






class CountNew : New
{
    public bool Set()
    {
        this.TokenCount = 0;


        this.CommentCount = 0;



        return true;
    }





    public int TokenCount { get; set; }



    public int CommentCount { get; set; }




    public override bool Toke()
    {
        this.TokenCount = this.TokenCount + 1;




        return true;
    }




    public override bool Comment()
    {
        this.CommentCount = this.CommentCount + 1;




   
        return true;
    }
}