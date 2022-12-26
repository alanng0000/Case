namespace Class.Node;



public class Field : Member
{
    public FieldName Name { get; set; }



    public ClassName Class { get; set; }



    public StateList Get { get; set; }



    public StateList Set { get; set; }



    public Access Access { get; set; }
}