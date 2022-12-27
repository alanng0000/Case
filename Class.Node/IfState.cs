namespace Class.Node;



public class IfState : State
{
    public Express Cond { get; set; }



    public StateList Loop { get; set; }
}