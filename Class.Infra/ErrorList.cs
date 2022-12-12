namespace Class.Infra;




public class ErrorList : List
{
    public override Error Get(object key)
    {
        return (Error)base.Get(key);
    }




    public bool Set(object key, Error value)
    {
        return base.Set(key, value);
    }
}