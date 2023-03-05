namespace Case.Check;



public class Field : Object
{
    public string Name { get; set; }



    public Class Class { get; set; }



    public Access Access { get; set; }



    public VarMap Get { get; set; }



    public VarMap Set { get; set; }



    public Class Parent { get; set; }



    public NodeField Node { get; set; }




    public int Index { get; set; }
}