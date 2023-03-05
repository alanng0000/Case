namespace Case.Node;




public class Case : Node
{
    public CaseName Name { get; set; }



    public CaseName Base { get; set; }



    public MemberList Member { get; set; }
}