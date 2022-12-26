namespace Class.Node;



public class Method : Member
{
    public MethodName Name { get; set; }



    public ClassName Class { get; set; }



    public ParamList Param { get; set; }



    public StateList Call { get; set; }



    public Access Access { get; set; }
}