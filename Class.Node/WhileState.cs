namespace Class.Node;



public class WhileState : State
{
    public Express Cond { get; set; }


    public StateList Loop { get; set; }
}