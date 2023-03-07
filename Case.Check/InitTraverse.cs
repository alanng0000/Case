namespace Case.Check;




public class InitTraverse : Traverse
{
    protected override bool ExecuteNode(NodeNode node)
    {
        Check check;



        check = this.Create.CreateCheck();





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = node;


        pair.Valu = check;




        this.Create.Check.Add(pair);




        return true;
    }
}