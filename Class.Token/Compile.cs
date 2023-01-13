namespace Class.Token;



public class Compile : InfraCompile
{
    public SourceArray SourceList { get; set; }






    public Result Result { get; set; }





    public override bool Init()
    {
        base.Init();





        this.RangeNull = new TextRange();


        this.RangeNull.Init();



        this.RangeNull.Row = IntNull;


        this.RangeNull.Range.Start = IntNull;


        this.RangeNull.Range.End = IntNull;







        this.CountNew = new CountNew();


        this.CountNew.Compile = this;


        this.CountNew.Init();






        this.AddNew = new AddNew();


        this.AddNew.Compile = this;


        this.AddNew.Init();






        return true;
    }





    public override bool Execute()
    {
        this.Result = new Result();



        this.Result.Init();





        CodeArray codes;
        


        codes = new CodeArray();



        codes.Count = this.SourceList.Count;



        codes.Init();




        this.Codes = codes;





        this.ErrorList = new ErrorList();




        this.ErrorList.Init();





        this.Result.Code = this.Codes;



        this.Result.Error = this.ErrorList;





        this.ExecuteCodes();




        return true;
    }





    private bool ExecuteCodes()
    {
        int i;


        i = 0;


        while (i < this.Codes.Count)
        {
            Code code;


            code = new Code();



            code.Init();




            this.Codes.Set(i, code);



            this.Code = code;




            this.Source = (Source)this.SourceList.Get(i);
            

        



            this.CountNew.Reset();




            this.New = this.CountNew;




            this.ExecuteCode();
            





            TokenArray tokenArray;


            tokenArray = new TokenArray();


            tokenArray.Count = this.CountNew.TokenCount;


            tokenArray.Init();





            CommentArray commentArray;


            commentArray = new CommentArray();


            commentArray.Count = this.CountNew.CommentCount;


            commentArray.Init();




            this.Code.Token = tokenArray;


            this.Code.Comment = commentArray;






            this.AddNew.Reset();



            this.New = this.AddNew;




            this.ExecuteCode();






            i = i + 1;
        }



        return true;
    }






    private CountNew CountNew { get; set; }




    private AddNew AddNew { get; set; }






    private CodeArray Codes { get; set; }




    private Text SourceText { get; set; }




    internal Code Code { get; set; }




    private New New { get; set; }





    internal TextRange Range;
    



    private Pos Pos;




    private TextRange RangeNull;




    private int Index { get; set; }




    private bool ExecuteCode()
    {
        Constant constant;


        constant = Constant.This;





        this.SourceText = this.Source.Text;





        
        this.Range = this.RangeNull;




        this.Pos.Row = 0;


        this.Pos.Col = 0;



        LineIter lineIter;


        lineIter = this.SourceText.Line.Iter();



        while (lineIter.Next())
        {
            this.Pos.Col = 0;



            Line line;

            line = lineIter.Value;



            CharIter charIter;


            charIter = line.Char.Iter();



            bool nextRow;


            nextRow = false;




            while (this.NextCharCond(nextRow, ref charIter))
            {
                bool isValid;

                isValid = false;


                char c;

                c = charIter.Value;



                if (c == constant.Hash)
                {
                    this.EndToken();



                    this.Range.Row = this.Pos.Row;


                    this.Range.Range.Start = this.Pos.Col;


                    this.Range.Range.End = line.Char.Count;



                    this.AddComment();



                    this.Pos.Col = this.Range.Range.End;



                    this.Reset();



                    nextRow = true;



                    isValid = true;
                }



                if (c == constant.Space)
                {
                    this.EndToken();


                    this.Pos.Col = this.Pos.Col + 1;


                    this.Reset();


                    isValid = true;
                }



                if (c == constant.Quote)
                {
                    this.EndToken();
                    

                    this.Range.Row = this.Pos.Row;


                    this.Range.Range.Start = this.Pos.Col;


                    this.Range.Range.End = IntNull;
                    



                    int col;

                    col = this.Pos.Col + 1;



                    char oc;



                    bool isEscape;

                    isEscape = false;

                    

                    bool ba;



                    bool b;

                    b = false;

                    
                    while (this.NextCharCond(b, ref charIter))
                    {
                        oc = charIter.Value;


                        
                        ba = isEscape;


                        if (ba)
                        {
                            isEscape = false;
                        }



                        if (!ba)
                        {
                            if (oc == constant.BackSlash)
                            {
                                isEscape = true;
                            }


                            if (oc == constant.Quote)
                            {
                                b = true;
                            }
                        }

                        

                        col = col + 1;
                    }
                    


                    
                    this.Range.Range.End = col;

                    


                    this.AddToken();


                    this.Pos.Col = this.Range.Range.End;


                    this.Reset();



                    isValid = true;
                }

                    

                if (this.TextInfra.IsAlphanumeric(c))
                {
                    if (this.NullRange())
                    {
                        this.Range.Row = this.Pos.Row;
                        this.Range.Range.Start = this.Pos.Col;
                    }


                    this.Pos.Col = this.Pos.Col + 1;


                    isValid = true;
                }



                if (!isValid)
                {
                    this.EndToken();



                    this.Range.Row = this.Pos.Row;


                    this.Range.Range.Start = this.Pos.Col;


                    this.Range.Range.End = this.Range.Range.Start + 1;
                    
                    

                    this.AddToken();



                    this.Pos.Col = this.Range.Range.End;



                    this.Reset();
                }
            }




            this.EndToken();



            this.Reset();




            this.Pos.Row = this.Pos.Row + 1;
        }
        




        return true;
    }





    private bool NextCharCond(bool breakCond, ref CharIter charIter)
    {
        bool b;


        b = false;



        if (!breakCond)
        {
            if (charIter.Next())
            {
                b = true;
            }
        }



        bool ret;

        ret = b;

        return ret;
    }





    private bool AddToken()
    {
        this.New.Token();



        return true;
    }





    private bool AddComment()
    {
        this.New.Comment();


        return true;
    }
    




    private bool EndToken()
    {
        if (!this.NullRange())
        {
            this.Range.Range.End = this.Pos.Col;



            this.AddToken();
        }


        return true;
    }





    private bool NullRange()
    {
        return this.Range.Row == IntNull;
    }




    private bool Reset()
    {
        this.Range = this.RangeNull;



        return true;
    }
}