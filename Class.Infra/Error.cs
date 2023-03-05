namespace Case.Infra;






public class Error : Object
{
    public Stage Stage { get; set; }




    public ErrorKind Kind { get; set; }




    public Range Range { get; set; }




    public Source Source { get; set; }
}