namespace Case;




class ModeString : Object
{
    private StringBuilder Builder { get; set; }




    public bool Execute(ModeResult result)
    {
        this.Builder = new StringBuilder();






        return true;
    }





    public string Result()
    {
        string t;
        
        
        t = this.Builder.ToString();




        string ret;


        ret = t;


        return ret;
    }
}