namespace Class.Check;



public class Method : Object
{
    public string Name { get; set; }



    public Class Class { get; set; }



    public Access Access { get; set; }



    public VarMap Params { get; set; }



    public VarMap Call { get; set; }



    public Class Parent { get; set; }



    public NodeMethod Node { get; set; }




    public int Index { get; set; }
}