namespace Class.Node;



public class Field : Member
{
    public FieldName Name { get; set; }



    public ClassName Class { get; set; }



    public States Get { get; set; }



    public States Set { get; set; }



    public Access Access { get; set; }
}