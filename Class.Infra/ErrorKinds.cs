namespace Class.Infra;






public class ErrorKinds : Object
{
    protected ErrorKind AddKind(string text)
    {
        ErrorKind kind;



        kind = new ErrorKind();



        kind.Init();



        kind.Text = text;





        ErrorKind ret;


        ret = kind;



        return ret;
    }
}