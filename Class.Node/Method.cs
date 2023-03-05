namespace Case.Node;



public class Method : Member
{
    public MethodName Name { get; set; }



    public CaseName Clas { get; set; }



    public Access Access { get; set; }



    public ParamList Param { get; set; }



    public StateList Call { get; set; }
}