namespace Class.Infra;



public class Convert : Object
{
    public ulong ByteListULong(byte[] u, ulong start)
    {
        ulong m;

        m = Constant.This.ByteBitCount;



        byte ob;



        ulong k;



        ulong index;




        ulong h;

        h = 0;



        ulong shiftCount;


        int v;



        ulong count;

        count = Constant.This.IntByteCount;



        ulong i;

        i = 0;


        while (i < count)
        {
            shiftCount = i * m;


            v = this.SInt32(shiftCount);



            index = start + i;



            ob = u[index];



            k = ob;
            

            k = k << v;



            h = h | k;



            i = i + 1;
        }



        ulong ret;

        ret = h;


        return ret;
    }





    public ulong ULong(int a)
    {
        return (ulong)a;
    }




    public int SInt32(ulong a)
    {
        return (int)a;
    }
}