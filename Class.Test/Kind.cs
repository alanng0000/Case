namespace Class.Test;




public class Kind
{
    public virtual bool Init()
    {
        this.Units = new List();




        this.Units.Init();





        return true;
    }






    public string Name { get; set; }





    public Set Set { get; set; }





    public List Units { get; set; }






    public bool AddUnit(Unit unit)
    {
        unit.Kind = this;



        unit.Init();





        this.Units.Add(unit);
        



        return true;
    }
}