namespace Class.Infra;




public class ModuleReferCompare : Compare
{
    public override bool Init()
    {
        base.Init();




        this.IntentCompare = new ModuleIntentCompare();


        this.IntentCompare.Init();




        this.VerCompare = new ModuleVerCompare();


        this.VerCompare.Init();





        return true;
    }





    private ModuleIntentCompare IntentCompare { get; set; }




    private ModuleVerCompare VerCompare { get; set; }






    public override int Execute(object left, object right)
    {
        if (this.Null(left))
        {
            return 0;
        }



        if (this.Null(right))
        {
            return 0;
        }






        ModuleRefer leftRefer;



        leftRefer = (ModuleRefer)left;





        ModuleRefer rightRefer;



        rightRefer = (ModuleRefer)right;





        int u;



        u = this.IntentCompare.Execute(leftRefer.Intent, rightRefer.Intent);



        if (!(u == 0))
        {
            return u;
        }



        

        u = this.VerCompare.Execute(leftRefer.Ver, rightRefer.Ver);





        return u;
    }
}