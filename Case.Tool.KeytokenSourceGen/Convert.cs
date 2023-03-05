namespace Case.Tool.KeywordSourceGen;



class Convert
{
    public List List(string[] u)
    {
        List list;


        list = new List();


        list.Init();




        foreach (string s in u)
        {
            list.Add(s);
        }




        List ret;

        ret = list;


        return ret;
    }
}