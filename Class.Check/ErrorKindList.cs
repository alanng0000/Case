namespace Class.Check;




public class ErrorKindList : InfraErrorKindList
{
    public static ErrorKindList This { get; } = CreateGlobal();




    private static ErrorKindList CreateGlobal()
    {
        ErrorKindList global;


        global = new ErrorKindList();



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
    public ErrorKind ArgueUnassignable { get; private set; }
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

        this.ArgueUnassignable = this.AddKind("ArgueUnassignable");

        this.ObjectUndefined = this.AddKind("ObjectUndefined");

        this.CondUndefined = this.AddKind("CondUndefined");

        this.CondUnassignable = this.AddKind("CondUnassignable");

        this.ResultUndefined = this.AddKind("ResultUndefined");

        this.ResultUnassignable = this.AddKind("ResultUnassignable");

        this.VarUndefined = this.AddKind("VarUndefined");



        return true;
    }
}