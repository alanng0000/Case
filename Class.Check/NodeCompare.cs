namespace Class.Check;




public class NodeCompare : Compare
{
    public override int Execute(object left, object right)
    {
        if (this.Null(left))
        {
            return 0;
        }



        if (this.Null(right))
        {
            return 0;
        }




        NodeNode leftNode;



        leftNode = (NodeNode)left;




        NodeNode rightNode;



        rightNode = (NodeNode)right;




        return leftNode.Id.CompareTo(rightNode.Id);
    }
}