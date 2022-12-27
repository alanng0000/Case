namespace Class.Node;



public class IfState : State
{
    public Express Cond { get; set; }



    public StateList Then { get; set; }
}