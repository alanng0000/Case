namespace Case.Test;




public class Set
{
    public virtual bool Init()
    {
        this.Kinds = new List();



        this.Kinds.Init();





        return true;
    }





    public string Name { get; set; }





    public Test Test { get; set; }





    public List Kinds { get; set; }





    public bool AddKind(Kind kind)
    {
        kind.Set = this;



        kind.Init();




        this.Kinds.Add(kind);



        return true;
    }
}