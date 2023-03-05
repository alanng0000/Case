namespace Case.Module;





public class Constants
{
    public static Constants This { get; } = CreateGlobal();




    private static Constants CreateGlobal()
    {
        Constants global;


        global = new Constants();



        global.Init();



        return global;
    }







    public bool Init()
    {
        this.ByteSize = sizeof(byte);




        this.IntSize = sizeof(ulong);




        this.ByteBitCount = 8;




        return true;
    }




    public ulong ByteSize { get; private set; }





    public ulong IntSize { get; private set; }





    public int ByteBitCount { get; private set; }
}