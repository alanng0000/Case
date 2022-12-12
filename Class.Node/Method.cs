namespace Class.Node;



public class Method : Member
{
    public MethodName Name { get; set; }



    public ClassName Class { get; set; }



    public Params Params { get; set; }



    public States Call { get; set; }



    public Access Access { get; set; }
}