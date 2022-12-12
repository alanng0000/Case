namespace Class.Check;




public class Class : Object
{
    public string Name { get; set; }



    public Class Base { get; set; }



    public FieldMap Fields { get; set; }



    public MethodMap Methods { get; set; }



    public Module Module { get; set; }



    public NodeClass Node { get; set; }




    public Source Source { get; set; }




    public int Index { get; set; }




    public ulong Id { get; set; }
}