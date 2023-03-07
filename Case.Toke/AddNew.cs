namespace Case.Toke;






class AddNew : New
{
    public bool Set()
    {
        this.TokenCount = 0;


        this.CommentCount = 0;



        return true;
    }




    private int TokenCount { get; set; }



    private int CommentCount { get; set; }




    public override bool Toke()
    {
        Toke token;
        

        token = new Toke();
        

        token.Range = this.Create.Range;




        this.Create.Code.Toke.Set(this.TokenCount, token);




        this.TokenCount = this.TokenCount + 1;




        return true;
    }




    public override bool Comment()
    {
        Comment comment;


        comment = new Comment();


        comment.Range = this.Create.Range;



        
        
        this.Create.Code.Comment.Set(this.CommentCount, comment);




        this.CommentCount = this.CommentCount + 1;




   
        return true;
    }
}