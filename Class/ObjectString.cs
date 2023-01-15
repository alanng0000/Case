namespace Class;




class ObjectString : Object
{
    private char CharSpace;



    private int IndentSize;




    private StringBuilder StringBuilder { get; set; }



    private int SpaceCount { get; set; }



    public Text Source { get; set; }



    private RangeInfra RangeInfra { get; set; }



    private TextInfra TextInfra { get; set; }



    private StringInfra StringInfra { get; set; }



    private Type NodeType { get; set; }



    private Type CodeType { get; set; }



    private Type TokenType { get; set; }



    private Type CommentType { get; set; }




    private Type TextRangeType { get; set; }




    private Type TextPosType { get; set; }





    public override bool Init()
    {
        base.Init();




        this.RangeInfra = new RangeInfra();



        this.RangeInfra.Init();





        this.TextInfra = new TextInfra();



        this.TextInfra.Init();





        this.StringInfra = new StringInfra();



        this.StringInfra.Init();





        this.NodeType = typeof(NodeNode);



        this.CodeType = typeof(Code);



        this.TokenType = typeof(TokenToken);



        this.CommentType = typeof(Comment);




        this.TextRangeType = typeof(TextRange);



        this.TextPosType = typeof(TextPos);




        this.CharSpace = ' ';



        this.IndentSize = 4;




        return true;
    }



    public string Result()
    {
        return this.StringBuilder.ToString();
    }



    public bool Execute(object varObject)
    {
        this.StringBuilder = new StringBuilder();



        this.SpaceCount = 0;



        this.TextInfra.Text = this.Source;



        this.ExecuteObject(varObject);



        return true;
    }




    private bool ExecuteObject(object varObject)
    {
        if (varObject == null)
        {
            this.Append("null").Append(",").AppendLine();

            return true;
        }


            
            
            
        if (varObject is bool)
        {
            bool k;

            k = (bool)varObject;


            this.Append(k.ToString().ToLower()).Append(",").AppendLine();

            return true;
        }
        else if (varObject is int)
        {
            int k;

            k = (int)varObject;


            this.Append(k.ToString()).Append(",").AppendLine();

            return true;
        }
        else if (varObject is ulong)
        {
            ulong k;

            k = (ulong)varObject;


            this.Append(k.ToString()).Append(",").AppendLine();


            return true;
        }
        else if (varObject is string)
        {
            string s;
            
            s = (string)varObject;


            s = this.StringInfra.EscapeString(s);


            this.Append("\"").Append(s).Append("\"").Append(",").AppendLine();


            return true;
        }
        else if (varObject is NullableULong)
        {
            NullableULong u;

            u = (NullableULong)varObject;


            if (!u.HasValue)
            {
                this.Append("null").Append(",").AppendLine();

                return true;
            }


            ulong k;

            k = u.Value;


            this.Append(k.ToString()).Append(",").AppendLine();

            return true;
        }



        Type objectType = varObject.GetType();


        string objectTypeName = objectType.Name;


        this.Append(objectTypeName).AppendLine();
            

        this.AppendSpaces().Append("{").AppendLine();


        this.SpaceCount = this.SpaceCount + IndentSize;

            




        bool b;


        
        b = (
            this.IsType(objectType, this.TextRangeType) | 
            this.IsType(objectType, this.TextPosType) |
            this.IsType(objectType, this.TokenType) |
            this.IsType(objectType, this.CommentType)
            );
        




        if (b)
        {
            this.Fields(objectType, varObject);
        }





        if (!b)
        {
            this.Propertys(objectType, varObject);
        }







        this.SpaceCount = this.SpaceCount - IndentSize;


        this.AppendSpaces().Append("}").Append(",").AppendLine();



        return true;
    }






    private bool Propertys(Type objectType, object varObject)
    {
        IEnumerablePropertyInfo propertyInfos;


        propertyInfos = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);



        PropertyInfoDictionary dictionary;
        
        dictionary = new PropertyInfoDictionary();



        foreach (PropertyInfo propertyInfo in propertyInfos)
        {
            if (!dictionary.ContainsKey(propertyInfo.Name))
            {
                dictionary.Add(propertyInfo.Name, propertyInfo);
            }
        }



        propertyInfos = dictionary.Values;




        foreach (PropertyInfo propertyInfo in propertyInfos)
        {
            string fieldName;
                
            fieldName = propertyInfo.Name;


            Type resultType;
                
            resultType = propertyInfo.PropertyType;



            object fieldGetValue;


            fieldGetValue = propertyInfo.GetValue(varObject);




            bool objectIsNode;

            objectIsNode = this.IsType(objectType, this.NodeType);




            if (objectIsNode)
            {
                if (fieldName == "Range" | fieldName == "Id")
                {
                    continue;
                }
            }



            this.Field(fieldName, resultType, fieldGetValue);
        }



        return true;
    }







    private bool Fields(Type objectType, object varObject)
    {
        IEnumerableFieldInfo fieldInfos;


        fieldInfos = objectType.GetFields(BindingFlags.Public | BindingFlags.Instance);



        FieldInfoDictionary dictionary;
        
        dictionary = new FieldInfoDictionary();



        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            if (!dictionary.ContainsKey(fieldInfo.Name))
            {
                dictionary.Add(fieldInfo.Name, fieldInfo);
            }
        }



        fieldInfos = dictionary.Values;




        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            string fieldName;
                
            fieldName = fieldInfo.Name;


            Type resultType;
                
            resultType = fieldInfo.FieldType;



            object fieldGetValue;


            fieldGetValue = fieldInfo.GetValue(varObject);




            bool objectIsNode;

            objectIsNode = this.IsType(objectType, this.NodeType);



            if (objectIsNode)
            {
                if (fieldName == "Range" | fieldName == "Id")
                {
                    continue;
                }
            }



            this.Field(fieldName, resultType, fieldGetValue);
        }



        return true;
    }




    private bool Field(string fieldName, Type resultType, object fieldGetValue)
    {
        this.AppendSpaces().Append(fieldName).Append(" ").Append(":").Append(" ");




        if ((this.IsType(resultType, typeof(IEnumerable))) && !resultType.Equals(typeof(string)))
        {
            int lastSpaceCount = this.SpaceCount;


            this.SpaceCount = this.SpaceCount + (fieldName.Length + 1 + 1 + 1);


            this.Append("[").AppendLine();


            this.SpaceCount = this.SpaceCount + IndentSize;


            IEnumerable objects;
            objects = (IEnumerable)fieldGetValue;


            IEnumerator enumerator;
            enumerator = objects.GetEnumerator();

            while (enumerator.MoveNext())
            {
                object o;
                o = enumerator.Current;


                this.AppendSpaces();


                this.ExecuteObject(o);
            }


            this.SpaceCount = this.SpaceCount - IndentSize;


            this.AppendSpaces().Append("]").Append(",").AppendLine();


            this.SpaceCount = lastSpaceCount;



        }
        else if (this.IsType(resultType, typeof(List)))
        {
            int lastSpaceCount;
            

            lastSpaceCount = this.SpaceCount;




            this.SpaceCount = this.SpaceCount + (fieldName.Length + 1 + 1 + 1);




            this.Append("[").AppendLine();



            this.SpaceCount = this.SpaceCount + IndentSize;




            List list;



            list = (List)fieldGetValue;





            IIter iter;



            iter = list.IIter();




            while (iter.Next())
            {
                object o;

                o = iter.Value;



                this.AppendSpaces();



                this.ExecuteObject(o);
            }




            this.SpaceCount = this.SpaceCount - IndentSize;




            this.AppendSpaces().Append("]").Append(",").AppendLine();




            this.SpaceCount = lastSpaceCount;



        }
        else
        {
            int lastSpaceCount = this.SpaceCount;


            this.SpaceCount = this.SpaceCount + (fieldName.Length + 1 + 1 + 1);



            object n = fieldGetValue;


            this.ExecuteObject(n);


            this.SpaceCount = lastSpaceCount;
        }




        return true;
    }






    private bool IsType(Type objectType, Type type)
    {
        bool b;


        b = type.IsAssignableFrom(objectType);



        bool ret;

        ret = b;

        return ret;
    }








    private ObjectString Append(string s)
    {
        StringBuilder.Append(s);

        return this;
    }



    private ObjectString AppendLine()
    {
        this.Append('\n', 1);


        return this;
    }



    private ObjectString Append(char c, int count)
    {
        StringBuilder.Append(c, count);

        return this;
    }



    private ObjectString AppendSpaces()
    {
        return this.Append(CharSpace, this.SpaceCount);
    }
}