namespace Case.Module;





public class Compile : InfraCompile
{
    public Result Result { get; set; }





    public SourceArray Sources { get; set; }





    public PortPort Port { get; set; }
    





    public NodeResult NodeResult { get; set; }





    public CheckResult CheckResult { get; set; }






    public ConstantClass ConstantClass { get; set; }





    public CheckModule Module { get; set; }








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





        this.Module = this.CheckResult.Refer.Module;






        this.ExecuteStages();







        return true;
    }











    private bool SetSystemClass()
    {
        return true;
    }






    protected virtual bool ExecuteStages()
    {
        




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