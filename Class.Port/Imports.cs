namespace Class.Port;





public class Imports : List
{
    public override Import Get(object key)
    {
        return (Import)base.Get(key);
    }




    public bool Set(object key, Import value)
    {
        return base.Set(key, value);
    }
}