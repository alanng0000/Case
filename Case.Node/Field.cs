namespace Case.Node;



public class Field : Member
{
    public FieldName Name { get; set; }



    public CaseName Case { get; set; }



    public Access Access { get; set; }



    public StateList Get { get; set; }



    public StateList Set { get; set; }
}