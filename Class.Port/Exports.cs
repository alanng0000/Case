namespace Class.Port;





public class Exports : List
{
    public override Export Get(object key)
    {
        return (Export)base.Get(key);
    }




    public bool Set(object key, Export value)
    {
        return base.Set(key, value);
    }
}