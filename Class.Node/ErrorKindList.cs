namespace Class.Node;




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



    public ErrorKind Invalid { get; private set; }
    public ErrorKind NameInvalid { get; private set; }
    public ErrorKind BaseInvalid { get; private set; }
    public ErrorKind MembersInvalid { get; private set; }
    public ErrorKind ClassInvalid { get; private set; }
    public ErrorKind AccessInvalid { get; private set; }
    public ErrorKind GetInvalid { get; private set; }
    public ErrorKind SetInvalid { get; private set; }
    public ErrorKind ParamsInvalid { get; private set; }
    public ErrorKind CallInvalid { get; private set; }
    public ErrorKind ExpressInvalid { get; private set; }
    public ErrorKind FieldInvalid { get; private set; }
    public ErrorKind MethodInvalid { get; private set; }
    public ErrorKind VarInvalid { get; private set; }
    public ErrorKind OperandInvalid { get; private set; }
    public ErrorKind TargetInvalid { get; private set; }
    public ErrorKind ValueInvalid { get; private set; }
    public ErrorKind ThisInvalid { get; private set; }
    public ErrorKind ObjectInvalid { get; private set; }
    public ErrorKind CondInvalid { get; private set; }
    public ErrorKind ResultInvalid { get; private set; }
    public ErrorKind ArguesInvalid { get; private set; }
    public ErrorKind BodyInvalid { get; private set; }




    public override bool Init()
    {
        base.Init();



        this.Invalid = this.AddKind("Invalid");

        this.NameInvalid = this.AddKind("NameInvalid");

        this.BaseInvalid = this.AddKind("BaseInvalid");

        this.MembersInvalid = this.AddKind("MembersInvalid");

        this.ClassInvalid = this.AddKind("ClassInvalid");

        this.AccessInvalid = this.AddKind("AccessInvalid");

        this.GetInvalid = this.AddKind("GetInvalid");

        this.SetInvalid = this.AddKind("SetInvalid");

        this.ParamsInvalid = this.AddKind("ParamsInvalid");

        this.CallInvalid = this.AddKind("CallInvalid");

        this.ExpressInvalid = this.AddKind("ExpressInvalid");

        this.FieldInvalid = this.AddKind("FieldInvalid");

        this.MethodInvalid = this.AddKind("MethodInvalid");

        this.VarInvalid = this.AddKind("VarInvalid");

        this.OperandInvalid = this.AddKind("OperandInvalid");

        this.TargetInvalid = this.AddKind("TargetInvalid");

        this.ValueInvalid = this.AddKind("ValueInvalid");

        this.ThisInvalid = this.AddKind("ThisInvalid");

        this.ObjectInvalid = this.AddKind("ObjectInvalid");

        this.CondInvalid = this.AddKind("CondInvalid");

        this.ResultInvalid = this.AddKind("ResultInvalid");

        this.ArguesInvalid = this.AddKind("ArguesInvalid");

        this.BodyInvalid = this.AddKind("BodyInvalid");



        return true;
    }
}