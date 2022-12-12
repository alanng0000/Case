namespace Class.Check;




public class InitTraverse : Traverse
{
    protected override bool ExecuteNode(NodeNode node)
    {
        Check check;



        check = this.Compile.CreateCheck();





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = node;


        pair.Value = check;




        this.Compile.Checks.Add(pair);




        return true;
    }
}