namespace Class.Node;



public class Method : Member
{
    public MethodName Name { get; set; }



    public ClassName Class { get; set; }



    public ParamList Params { get; set; }



    public States Call { get; set; }



    public Access Access { get; set; }
}