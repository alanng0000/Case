namespace Case.Token;






class AddNew : New
{
    public bool Reset()
    {
        this.TokenCount = 0;


        this.CommentCount = 0;



        return true;
    }




    private int TokenCount { get; set; }



    private int CommentCount { get; set; }




    public override bool Token()
    {
        Token token;
        

        token = new Token();
        

        token.Range = this.Create.Range;




        this.Create.Code.Token.Set(this.TokenCount, token);




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