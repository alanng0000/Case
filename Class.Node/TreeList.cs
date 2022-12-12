namespace Class.Node;




public class TreeList : List
{
    public override Tree Get(object key)
    {
        return (Tree)base.Get(key);
    }




    public bool Set(object key, Tree value)
    {
        return base.Set(key, value);
    }
}