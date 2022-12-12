namespace Class.Module;





public class Strings
{
    public bool Init()
    {
        this.CharCodes = new byte[128];




        this.TotalCodeCount = 0;




        int count;



        count = this.CodeCount('A', 'Z');




        this.AddCodes('A', count);



        this.AddCodes('a', count);




        count = this.CodeCount('0', '9');




        this.AddCodes('0', count);





        string s;


        s = " .";   // " .,!?:;=+*/^|~-\'\"(){}[]<>\\\n";




        int charCount;


        charCount = s.Length;




        int i;


        i = 0;


        while (i < charCount)
        {
            char oc;


            oc = s[i];



            this.AddCode(oc);



            i = i + 1;
        }







        this.CSharpCharCodes = new byte[128];





        this.SetCSharpCharCodes(0, 26, 'A');



        this.SetCSharpCharCodes(26, 26, 'a');



        this.SetCSharpCharCodes(52, 10, '0');



        this.SetCSharpCharCodes(62, 1, ' ');



        this.SetCSharpCharCodes(63, 1, '.');





        return true;
    }




    public byte? GetCharCode(byte oc)
    {
        return this.GetCode(oc, this.CharCodes);
    }




    public byte? GetCSharpCharCode(byte oc)
    {
        return this.GetCode(oc, this.CSharpCharCodes);
    }




    private byte? GetCode(byte oc, byte[] array)
    {
        bool b;


        b = (oc < array.Length);



        if (!b)
        {
            return null;
        }




        byte t;


        t = array[oc];



        byte ret;


        ret = t;


        return ret;
    }







    private byte[] CharCodes { get; set; }





    private int TotalCodeCount { get; set; }





    private byte[] CSharpCharCodes { get; set; }





    private bool AddCodes(char startChar, int count)
    {
        ulong valueOffset;


        valueOffset = (ulong)this.TotalCodeCount;




        this.SetCharCodes(startChar, count, valueOffset);




        this.TotalCodeCount = this.TotalCodeCount + count;




        return true;
    }




    private bool AddCode(char oc)
    {
        this.AddCodes(oc, 1);



        return true;
    }




    private int CodeCount(char startChar, char lastChar)
    {
        int k;


        k = (lastChar - startChar + 1);




        int ret;


        ret = k;


        return ret;
    }




    private bool SetCharCodes(char keyStartChar, int codeCount, ulong valueOffset)
    {
        ulong keyOffset;


        keyOffset = keyStartChar;



        return this.SetCodes(keyOffset, codeCount, valueOffset, this.CharCodes);
    }





    
    private bool SetCSharpCharCodes(ulong keyOffset, int codeCount, char valueStartChar)
    {
        ulong valueOffset;


        valueOffset = valueStartChar;



        return this.SetCodes(keyOffset, codeCount, valueOffset, this.CSharpCharCodes);
    }
    





    private bool SetCodes(ulong keyOffset, int codeCount, ulong valueOffset, byte[] array)
    {
        ulong cc;


        cc = keyOffset;




        ulong j;


        j = valueOffset;






        int count;


        count = codeCount;



        int i;


        i = 0;



        while (i < count)
        {
            ulong cd;


            cd = (ulong)i;




            ulong index;


            index = cc + cd;



                        
            ulong k;


            k = j + cd;



            byte o;


            o = (byte)k;



            array[index] = o;




            i = i + 1;
        }



        return true;
    }
}