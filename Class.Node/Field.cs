namespace Class.Node;



public class Field : Member
{
    public FieldName Name { get; set; }



    public ClasName Class { get; set; }



    public Access Access { get; set; }



    public StateList Get { get; set; }



    public StateList Set { get; set; }
}