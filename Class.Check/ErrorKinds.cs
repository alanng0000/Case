namespace Class.Check;




public class ErrorKinds : InfraErrorKinds
{
    public static ErrorKinds This { get; } = CreateGlobal();




    private static ErrorKinds CreateGlobal()
    {
        ErrorKinds global;


        global = new ErrorKinds();



        global.Init();



        return global;
    }



    public ErrorKind NameUnavailable { get; private set; }
    public ErrorKind ClassUndefined { get; private set; }
    public ErrorKind BaseUndefined { get; private set; }
    public ErrorKind TargetUndefined { get; private set; }
    public ErrorKind ValueUndefined { get; private set; }
    public ErrorKind ValueUnassignable { get; private set; }
    public ErrorKind OperandUndefined { get; private set; }
    public ErrorKind OperandUnassignable { get; private set; }
    public ErrorKind ThisUndefined { get; private set; }
    public ErrorKind FieldUndefined { get; private set; }
    public ErrorKind MethodUndefined { get; private set; }
    public ErrorKind ArguesUnassignable { get; private set; }
    public ErrorKind ObjectUndefined { get; private set; }
    public ErrorKind CondUndefined { get; private set; }
    public ErrorKind CondUnassignable { get; private set; }
    public ErrorKind ResultUndefined { get; private set; }
    public ErrorKind ResultUnassignable { get; private set; }
    public ErrorKind VarUndefined { get; private set; }




    public override bool Init()
    {
        base.Init();



        this.NameUnavailable = this.AddKind("NameUnavailable");

        this.ClassUndefined = this.AddKind("ClassUndefined");

        this.BaseUndefined = this.AddKind("BaseUndefined");

        this.TargetUndefined = this.AddKind("TargetUndefined");

        this.ValueUndefined = this.AddKind("ValueUndefined");

        this.ValueUnassignable = this.AddKind("ValueUnassignable");

        this.OperandUndefined = this.AddKind("OperandUndefined");

        this.OperandUnassignable = this.AddKind("OperandUnassignable");

        this.ThisUndefined = this.AddKind("ThisUndefined");

        this.FieldUndefined = this.AddKind("FieldUndefined");

        this.MethodUndefined = this.AddKind("MethodUndefined");

        this.ArguesUnassignable = this.AddKind("ArguesUnassignable");

        this.ObjectUndefined = this.AddKind("ObjectUndefined");

        this.CondUndefined = this.AddKind("CondUndefined");

        this.CondUnassignable = this.AddKind("CondUnassignable");

        this.ResultUndefined = this.AddKind("ResultUndefined");

        this.ResultUnassignable = this.AddKind("ResultUnassignable");

        this.VarUndefined = this.AddKind("VarUndefined");



        return true;
    }
}