namespace Class.Check;




public class VarStack : Stack
{
    public bool Push(VarMap item)
    {
        return base.Push(item);
    }



    public new VarMap Top
    {
        get
        {
            return (VarMap)base.Top;
        }

        set
        {
        }
    }
}