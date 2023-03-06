namespace Case.Infra;






public class Create : Object
{
    protected ErrorList ErrorList { get; set; }

    


    protected Source Source { get; set; }




    protected static readonly int IntNull = -1;






    protected TextInfra TextInfra { get; set; }






    public Stage Stage { get; set; }






    public override bool Init()
    {
        base.Init();
        







        this.TextInfra = new TextInfra();



        this.TextInfra.Init();





        this.Stage = new Stage();



        this.Stage.Init();





        return true;
    }





    public virtual bool Execute()
    {
        return true;
    }
}