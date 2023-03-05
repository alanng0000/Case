namespace Case.Test;




public class Unit
{
    public virtual bool Init()
    {
        return true;
    }





    public string Name { get; set; }




    public Kind Kind { get; set; }





    public virtual bool Execute()
    {
        return true;
    }





    protected bool Null(object o)
    {
        return o == null;
    }
}