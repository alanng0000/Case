namespace Class.Node;



public class WhileState : State
{
    public Express Cond { get; set; }


    public StateList Body { get; set; }
}