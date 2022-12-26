namespace Class.Module;





public class Compile : InfraCompile
{
    public Result Result { get; set; }





    public SourceArray Sources { get; set; }





    public string TaskModule { get; set; }





    public PortPort Port { get; set; }
    





    public NodeResult NodeResult { get; set; }





    public CheckResult CheckResult { get; set; }






    public SystemModule SystemModule { get; set; }





    public CheckModule Module { get; set; }







    internal SizeCompile SizeCompile { get; set; }





    internal DataCompile DataCompile { get; set; }





    internal virtual bool ExecuteStates
    {
        get
        {
            return true;
        }

        set
        {
        }
    }




    public override bool Init()
    {
        base.Init();






        this.SizeCompile = new SizeCompile();



        this.SizeCompile.Init();



        this.SizeCompile.Compile = this;







        this.DataCompile = new DataCompile();



        this.DataCompile.Init();



        this.DataCompile.Compile = this;







        return true;
    }





    public override bool Execute()
    {
        this.Result = new Result();


        

        Data data;


        data = new Data();




        this.Result.Module = data;






        ErrorList errors;
        
        

        errors = new ErrorList();



        errors.Init();



        this.Result.Errors = errors;





        if (!this.CheckErrors())
        {
            this.Result.Module.Value = new byte[0];
            


            return true;
        }






        this.SetSystemClass();





        this.Module = (CheckModule)this.CheckResult.Refer.Modules.Get(this.TaskModule);






        this.ExecuteStages();






        this.Result.Module.Value = this.DataResult();






        return true;
    }





    protected virtual byte[] DataResult()
    {
        return this.DataCompile.Data;
    }







    private bool SetSystemClass()
    {
        CheckModule m;



        m = (CheckModule)this.CheckResult.Refer.Modules.Get("System");




        this.SystemModule = new SystemModule();



        this.SystemModule.Module = m;



        this.SystemModule.Init();





        return true;
    }






    protected virtual bool ExecuteStages()
    {
        this.ExecuteSize();





        //this.ExecuteData();




        return true;
    }







    private bool ExecuteSize()
    {
        this.SizeCompile.Execute();




        return true;
    }






    private bool ExecuteData()
    {
        this.DataCompile.Execute();



        
        return true;
    }




    internal ulong ULong(int o)
    {
        ulong u;


        u = (ulong)o;


        return u;
    }





    private bool CheckErrors()
    {
        bool ba;


        ba = this.Zero(this.NodeResult.Error.Count);





        bool bb;


        bb = this.Zero(this.CheckResult.Error.Count);




        bool b;

        b = (ba & bb);




        if (!b)
        {
            return false;
        }




        return true;
    }





    private bool Zero(int n)
    {
        return n == 0;
    }
}