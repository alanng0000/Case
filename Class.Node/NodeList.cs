namespace Class.Node;




public class NodeList : ListNode
{
    public NodeListIter Iter()
    {
        NodeListIter iter;



        iter = new NodeListIter();




        iter.Init(this);




        NodeListIter ret;


        ret = iter;



        return ret;
    }
}