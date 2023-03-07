namespace Case;




public class CheckString : Object
{
    private StringBuilder Builder { get; set; }




    private CheckResult CheckResult { get; set; }




    private NodeResult NodeResult { get; set; }




    private string Path { get; set; }




    public Class Class { get; set; }





    public bool Execute()
    {

        this.Path = this.Class.Task.Check;





        this.CheckResult = this.Class.Result.Check;





        this.NodeResult = this.Class.Result.Node;







        this.Builder = new StringBuilder();
        




        this.GetClassNode();
        




        this.GetNode();




        if (this.Node == null)
        {
            return true;
        }






        this.Check = (CheckCheck)this.CheckResult.Check.Get(this.Node);





        this.NodeCheckString();





        return true;
    }




    private NodeNode ClassNode { get; set; }




    private NodeNode Node { get; set; }





    private NodeNode CurrentNode { get; set; }




    private int CurrentIndex { get; set; }




    private string Field { get; set; }




    private string FieldName { get; set; }




    private ulong? Index { get; set; }






    private bool GetClassNode()
    {
        TreeArray treeArray;



        treeArray = this.NodeResult.Tree;




        if (treeArray.Count == 0)
        {
            return true;
        }





        ArrayIter iter;



        iter = treeArray.Iter();



        iter.Next();





        Tree tree;


        tree = (Tree)iter.Valu;




        NodeNode root;


        root = tree.Root;




        this.ClassNode = root;



        return true;
    }




    protected CheckCheck Check { get; set; }




    protected virtual bool NodeCheckString()
    {
        this.AppendClass(this.Check.Class);


        this.AppendLine();




        this.AppendField(this.Check.Field);


        this.AppendLine();




        this.AppendMethod(this.Check.Method);


        this.AppendLine();




        this.AppendVar(this.Check.Var);


        this.AppendLine();






        this.AppendClass(this.Check.ExpressClass);


        this.AppendLine();





        this.AppendClass(this.Check.NewClass);


        this.AppendLine();




        this.AppendClass(this.Check.TargetClass);


        this.AppendLine();




        this.AppendClass(this.Check.CastClass);


        this.AppendLine();





        this.AppendClass(this.Check.GlobClass);


        this.AppendLine();




        this.AppendField(this.Check.GetField);


        this.AppendLine();




        this.AppendField(this.Check.SetField);


        this.AppendLine();




        this.AppendMethod(this.Check.CallMethod);


        this.AppendLine();




        return true;
    }




    protected bool AppendClass(CheckClass varClass)
    {
        if (this.Null(varClass))
        {
            this.AppendNull();



            return true;
        }




        bool b;


        b = (varClass.Name == null);




        if (b)
        {
            this.Append("<NullClass>");



            return true;
        }





        this.Append(varClass.Module.Name.Valu);



        this.Append(":");



        this.Append(varClass.Name);



        return true;
    }



    protected bool AppendField(CheckField field)
    {
        if (this.Null(field))
        {
            this.AppendNull();



            return true;
        }





        CheckClass varClass;



        varClass = field.Parent;




        this.AppendClass(varClass);




        this.Append(".");




        this.Append(field.Name);




        return true;
    }




    protected bool AppendMethod(CheckMethod method)
    {
        if (this.Null(method))
        {
            this.AppendNull();



            return true;
        }





        CheckClass varClass;



        varClass = method.Parent;




        this.AppendClass(varClass);




        this.Append(".");




        this.Append(method.Name);




        return true;
    }




    protected bool AppendVar(CheckVar varVar)
    {
        if (this.Null(varVar))
        {
            this.AppendNull();



            return true;
        }




        this.Append(varVar.Name);



        return true;
    }




    protected bool AppendLine()
    {
        this.Append("\n");


        return true;
    }



    protected bool AppendNull()
    {
        this.Builder.Append("<Null>");


        return true;
    }



    protected bool Append(string s)
    {
        this.Builder.Append(s);


        return true;
    }





    protected bool Null(object o)
    {
        return o == null;
    }





    public string Result()
    {
        string ret;

        ret = this.Builder.ToString();



        return ret;
    }





    private bool GetNode()
    {
        NodeNode t;



        t = this.ClassNode;


        

        this.CurrentNode = t;




        this.CurrentIndex = 0;




        while (!this.Null(this.CurrentNode) & this.CurrentIndex < this.Path.Length)
        {
            this.GetFieldNode();
        }




        this.Node = this.CurrentNode;




        return true;
    }






    private bool GetFieldNode()
    {
        this.GetField();




        this.GetFieldNameIndex();




        this.GetFieldValue();




        this.CurrentIndex = this.CurrentIndex + this.Field.Length + 1;





        this.Field = null;




        this.FieldName = null;




        this.Index = null;




        return true;
    }





    private bool GetFieldValue()
    {
        NodeNode node;




        node = this.CurrentNode;





        Type type;



        type = node.GetType();





        PropertyInfo propertyInfo;
        


        propertyInfo = type.GetProperty(this.FieldName);




        if (propertyInfo == null)
        {
            return this.FailGetFieldValue();
        }




        object o;



        o = propertyInfo.GetValue(node);




        if (o == null)
        {
            return this.FailGetFieldValue();
        }






        bool ba;



        ba = (o is NodeNode);





        bool bb;



        bb = (o is List);





        if (!ba & !bb)
        {
            return this.FailGetFieldValue();
        }




        if (ba)
        {
            if (this.Index.HasValue)
            {
                return this.FailGetFieldValue();
            }





            NodeNode t;



            t = (NodeNode)o;




            this.CurrentNode = t;
        }




        if (bb)
        {
            if (!this.Index.HasValue)
            {
                return this.FailGetFieldValue();
            }






            List t;




            t = (List)o;




            List list;

            list = t;





            ulong k;



            k = (ulong)list.Count;





            ulong v;


            v = this.Index.Value;





            ulong count;



            count = v + 1;





            if (k < count)
            {
                return this.FailGetFieldValue();
            }






            int f;


            f = (int)v;




            NodeNode g;




            g = this.NodeAtIndex(list, f);





            this.CurrentNode = g;
        }




        return true;
    }





    private NodeNode NodeAtIndex(List list, int index)
    {
        int count;


        count = index + 1;




        ListIter iter;


        iter = list.Iter();




        int i;

        i = 0;


        while (i < count)
        {
            iter.Next();


            i = i + 1;
        }



        NodeNode node;


        node = (NodeNode)iter.Valu;


        

        NodeNode ret;

        ret = node;



        return ret;
    }





    private bool FailGetFieldValue()
    {
        this.CurrentNode = null;


        return true;
    }




    private bool GetField()
    {
        int startIndex;



        startIndex = this.CurrentIndex;




        int endIndex;



        endIndex = 0;





        int u;



        u = this.Path.IndexOf('.', startIndex);





        bool b;



        b = (u < 0);




        if (b)
        {
            endIndex = this.Path.Length;
        }



        if (!b)
        {
            endIndex = u;
        }





        int count;


        count = endIndex - startIndex;





        string s;



        s = this.Path.Substring(startIndex, count);




        this.Field = s;




        return true;
    }





    private bool GetFieldNameIndex()
    {
        int? u;


        u = this.LeftSquareIndex(this.Field);        





        if (u.HasValue)
        {
            int leftSquareIndex;



            leftSquareIndex = u.Value;




            this.Index = this.GetIndex(this.Field, leftSquareIndex);





            this.FieldName = this.Field.Substring(0, leftSquareIndex);
        }




        if (!u.HasValue)
        {
            this.Index = null;





            this.FieldName = this.Field;
        }




        return true;
    }

    




    private int? LeftSquareIndex(string field)
    {
        int t;



        t = field.IndexOf('[');




        if (t < 0)
        {
            return null;
        }




        int ret;


        ret = t;



        return ret;
    }





    private ulong? GetIndex(string field, int leftSquareIndex)
    {
        if (field.Length < 1)
        {
            return null;
        }





        int lastIndex;



        lastIndex = field.Length - 1;




        char lastChar;


        lastChar = field[lastIndex];




        bool b;



        b =  (lastChar == ']');
        



        if (!b)
        {
            return null;
        }





        int t;


        t = leftSquareIndex + 1;





        int count;


        count = lastIndex - t;





        string s;



        s = field.Substring(t, count);





        bool parse;




        ulong n;



        parse = ulong.TryParse(s, out n);




        if (!parse)
        {
            return null;
        }



        return n;
    }
}