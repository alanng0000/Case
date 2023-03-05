namespace Case.Test.Module;




class Unit : global::Case.Test.Unit
{
    public override bool Init()
    {
        base.Init();




        Test a;



        a = this.Kind.Set.Test;




        this.Test = a;





        this.Index = 0;





        this.Constants = ModuleConstants.This;





        return true;
    }





    private Test Test { get; set; }






    private byte[] Data { get; set; }





    private ModuleConstants Constants { get; set; }





    protected bool Compile()
    {
        string foldPath;



        foldPath = Path.Combine(".", this.Kind.Set.Name, this.Kind.Name, this.Name, "Source");




        this.Test.ClassTask(foldPath);





        this.Data = this.Test.CompileResult.Module.Value;
        




        return true;
    }






    protected ulong Index { get; set; }





    protected ulong? NextInt()
    {
        ulong size;


        size = this.Constants.IntSize;





        if (!this.HasSize(size))
        {
            return null;
        }






        ulong t;



        t = 0;





        int byteBitCount;



        byteBitCount = (int)this.Constants.ByteBitCount;





        int count;



        count = (int)size;





        int i;


        i = 0;


        while (i < count)
        {
            ulong k;



            k = (ulong)i;




            ulong index;



            index = this.Index + k;




            byte ob;


            ob = this.GetByte(index);




            int shiftCount;


            shiftCount = i * byteBitCount;




            ulong h;


            h = ob;



            h = h << shiftCount;




            t = t | h;




            i = i + 1;
        }
        



        this.Index = this.Index + size;

        


        ulong ret;


        ret = t;



        return ret;
    }
    




    protected string NextString()
    {
        ulong? u;



        u = this.NextInt();




        if (!u.HasValue)
        {
            return null;
        }



        StringBuilder builder;


        builder = new StringBuilder();





        ulong length;



        length = u.Value;





        int count;


        count = (int)length;




        int i;


        i = 0;


        while (i < count)
        {
            ulong j;


            j = (ulong)i;




            ulong index;


            index = this.Index + j;




            byte ob;


            ob = this.GetByte(index);






            byte? oo;



            oo = this.Test.Strings.GetCSharpCharCode(ob);



            if (!oo.HasValue)
            {
                return null;
            }



            byte od;


            od = oo.Value;




            char oc;


            oc = (char)od;



            builder.Append(oc);




            i = i + 1;
        }





        string s;


        s = builder.ToString();




        this.Index = this.Index + length;





        string ret;


        ret = s;



        return ret;
    }






    private byte GetByte(ulong index)
    {
        return this.Data[index];
    }





    protected bool HasSize(ulong size)
    {
        ulong dataSize;



        dataSize = (ulong)this.Data.Length;




        bool ba;


        ba = (this.Index < dataSize);




        bool bb;


        bb = (dataSize < this.Index + size);





        bool b;



        b = (ba & !bb);





        bool ret;


        ret = b;


        return ret;
    }
}