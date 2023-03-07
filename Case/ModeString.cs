namespace Case;




class ModeString : Object
{
    private StringBuilder Builder { get; set; }




    public bool Execute(ModeResult result)
    {
        this.Builder = new StringBuilder();





        char space;




        space = ' ';





        char lineEnd;




        lineEnd = '\n';






        int rowLength;



        rowLength = 16;





        Data data;
        
        

        data = result.Mode;




        byte[] u;



        u = data.Valu;





        int count;



        count = u.Length;



        
        int i;


        i = 0;



        while (i < count)
        {
            byte o;



            o = u[i];




            if (0 < i)
            {
                int j;



                j = (i / rowLength) * rowLength;




                int m;
                


                m = i - j;




                bool b;



                b = (m == 0);



                if (b)
                {
                    this.Builder.Append(lineEnd);
                }



                if (!b)
                {
                    this.Builder.Append(space);
                }
            }





            this.AppendByteText(o);





            i = i + 1;
        }




        return true;
    }





    public string Result()
    {
        string t;
        
        
        t = this.Builder.ToString();




        string ret;


        ret = t;


        return ret;
    }





    private bool AppendByteText(byte o)
    {
        byte lowerDigit;


        lowerDigit = this.HexDigit(o, 0);




        byte higherDigit;


        higherDigit = this.HexDigit(o, 1);




        char t;
        


        t = this.HexDigitText(higherDigit);



        this.Builder.Append(t);



        t = this.HexDigitText(lowerDigit);



        this.Builder.Append(t);




        return true;
    }





    private byte HexDigit(byte o, int index)
    {
        int digitBitCount;



        digitBitCount = 4;




        int shiftCount;



        shiftCount = index * digitBitCount;





        ulong t;


        t = o;




        ulong k;
        


        k = t >> shiftCount;



        k = k & 0xf;





        byte n;



        n = (byte)k;





        byte ret;



        ret = n;



        return ret;
    }




    private char HexDigitText(byte o)
    {
        char t;


        t = '\0';




        bool b;


        
        b = (o < 10);




        if (b)
        {
            int u;


            u = o + '0';



            t = (char)u;            
        }



        if (!b)
        {
            int k;


            k = o - 10;



            int u;


            u = k + 'a';



            t = (char)u;
        }




        char ret;


        ret = t;



        return ret;
    }
}