namespace Class.Module;





class SizeTraverse : Traverse
{
    public SizeCompile SizeCompile { get; set; }





    public override bool Init()
    {
        this.CharSize = sizeof(uint);



        return true;
    }






    public override bool ExecuteStateList(StateList stateList)
    {
        if (this.Null(stateList))
        {
            return true;
        }




        this.AddOpSize();




        this.AddArgSize();





        base.ExecuteStateList(stateList);





        return true;
    }






    public override bool ExecuteState(State state)
    {
        if (this.Null(state))
        {
            return true;
        }




        base.ExecuteState(state);




        this.AddOpSize();





        return true;
    }







    public override bool ExecuteThisExpress(ThisExpress thisExpress)
    {
        if (this.Null(thisExpress))
        {
            return true;
        }




        base.ExecuteThisExpress(thisExpress);





        this.AddOpSize();




        return true;
    }




    public override bool ExecuteBaseExpress(BaseExpress baseExpress)
    {
        if (this.Null(baseExpress))
        {
            return true;
        }




        base.ExecuteBaseExpress(baseExpress);





        this.AddOpSize();




        return true;
    }





    public override bool ExecuteDeclareState(DeclareState declareState)
    {
        if (this.Null(declareState))
        {
            return true;
        }




        base.ExecuteDeclareState(declareState);





        this.AddOpSize();




        return true;
    }






    public override bool ExecuteAssignState(AssignState assignState)
    {
        if (this.Null(assignState))
        {
            return true;
        }




        base.ExecuteAssignState(assignState);





        this.AddOpSize();





        return true;
    }








    public override bool ExecuteNewExpress(NewExpress makeExpress)
    {
        if (this.Null(makeExpress))
        {
            return true;
        }




        base.ExecuteNewExpress(makeExpress);




        this.AddOpSize();




        this.AddClassNameSize();





        return true;
    }






    public override bool ExecuteAndExpress(AndExpress andExpress)
    {
        if (this.Null(andExpress))
        {
            return true;
        }




        base.ExecuteAndExpress(andExpress);



        this.AddOpSize();



        return true;
    }





    public override bool ExecuteOrnExpress(OrnExpress orExpress)
    {
        if (this.Null(orExpress))
        {
            return true;
        }




        base.ExecuteOrnExpress(orExpress);



        this.AddOpSize();



        return true;
    }





    public override bool ExecuteNotExpress(NotExpress notExpress)
    {
        if (this.Null(notExpress))
        {
            return true;
        }




        base.ExecuteNotExpress(notExpress);



        this.AddOpSize();



        return true;
    }





    public override bool ExecuteAddExpress(AddExpress addExpress)
    {
        if (this.Null(addExpress))
        {
            return true;
        }




        base.ExecuteAddExpress(addExpress);



        this.AddOpSize();



        return true;
    }





    public override bool ExecuteSubExpress(SubExpress subExpress)
    {
        if (this.Null(subExpress))
        {
            return true;
        }




        base.ExecuteSubExpress(subExpress);



        this.AddOpSize();



        return true;
    }





    public override bool ExecuteMulExpress(MulExpress mulExpress)
    {
        if (this.Null(mulExpress))
        {
            return true;
        }




        base.ExecuteMulExpress(mulExpress);



        this.AddOpSize();



        return true;
    }




    public override bool ExecuteDivExpress(DivExpress divExpress)
    {
        if (this.Null(divExpress))
        {
            return true;
        }




        base.ExecuteDivExpress(divExpress);



        this.AddOpSize();



        return true;
    }





    public override bool ExecuteLessExpress(LessExpress lessExpress)
    {
        if (this.Null(lessExpress))
        {
            return true;
        }




        base.ExecuteLessExpress(lessExpress);





        this.AddOpSize();





        return true;
    }





    public override bool ExecuteEqualExpress(EqualExpress equalExpress)
    {
        if (this.Null(equalExpress))
        {
            return true;
        }




        base.ExecuteEqualExpress(equalExpress);




        this.AddOpSize();




        return true;
    }






    public override bool ExecuteJoinExpress(JoinExpress joinExpress)
    {
        if (this.Null(joinExpress))
        {
            return true;
        }




        base.ExecuteJoinExpress(joinExpress);




        this.AddOpSize();




        return true;
    }





    public override bool ExecuteGetExpress(GetExpress getExpress)
    {
        if (this.Null(getExpress))
        {
            return true;
        }




        base.ExecuteGetExpress(getExpress);




        this.AddOpSize();




        this.AddArgSize();




        return true;
    }





    public override bool ExecuteCallExpress(CallExpress callExpress)
    {
        if (this.Null(callExpress))
        {
            return true;
        }




        base.ExecuteCallExpress(callExpress);




        this.AddOpSize();




        this.AddArgSize();




        return true;
    }






    public override bool ExecuteNullExpress(NullExpress nullExpress)
    {
        if (this.Null(nullExpress))
        {
            return true;
        }




        base.ExecuteNullExpress(nullExpress);




        this.AddOpSize();




        return true;
    }








    public override bool ExecuteCastExpress(CastExpress castExpress)
    {
        if (this.Null(castExpress))
        {
            return true;
        }




        base.ExecuteCastExpress(castExpress);




        this.AddOpSize();




        this.AddClassNameSize();




        return true;
    }





    public override bool ExecuteReturnState(ReturnState returnState)
    {
        if (this.Null(returnState))
        {
            return true;
        }




        base.ExecuteReturnState(returnState);




        this.AddOpSize();




        return true;
    }






    public override bool ExecuteVarExpress(VarExpress varExpress)
    {
        if (this.Null(varExpress))
        {
            return true;
        }





        base.ExecuteVarExpress(varExpress);





        this.AddOpSize();




        this.AddArgSize();





        return true;
    }





    public override bool ExecuteConstantExpress(ConstantExpress constantExpress)
    {
        if (this.Null(constantExpress))
        {
            return true;
        }





        base.ExecuteConstantExpress(constantExpress);





        this.AddOpSize();





        this.AddTypeSize();





        Constant constant;



        constant = constantExpress.Constant;





        if (constant is BoolConstant)
        {
            this.AddByteSize();
        }




        if (constant is IntConstant)
        {
            IntConstant intConstant;



            intConstant = (IntConstant)constant;



            ulong value;


            value = intConstant.Value;





            ulong valueSize;



            valueSize = this.IntValueSize(value);




            this.AddIntSize();



            this.AddSize(valueSize);
        }




        if (constant is StringConstant)
        {
            StringConstant stringConstant;



            stringConstant = (StringConstant)constant;




            int length;


            length = stringConstant.Value.Length;




            ulong count;


            count = (ulong)length;




            ulong size;



            size = count * this.CharSize;





            this.AddIntSize();




            this.AddSize(size);
        }





        return true;
    }






    public override bool ExecuteIfState(IfState ifState)
    {
        if (this.Null(ifState))
        {
            return true;
        }





        this.AddOpSize();





        base.ExecuteIfState(ifState);






        return true;
    }






    public override bool ExecuteWhileState(WhileState whileState)
    {
        if (this.Null(whileState))
        {
            return true;
        }





        this.AddOpSize();





        base.ExecuteWhileState(whileState);






        return true;
    }








    public override bool ExecuteVarTarget(VarTarget varTarget)
    {
        if (this.Null(varTarget))
        {
            return true;
        }





        base.ExecuteVarTarget(varTarget);





        this.AddOpSize();




        this.AddArgSize();





        return true;
    }





    public override bool ExecuteSetTarget(SetTarget setTarget)
    {
        if (this.Null(setTarget))
        {
            return true;
        }





        base.ExecuteSetTarget(setTarget);





        this.AddOpSize();




        this.AddArgSize();





        return true;
    }






    public override bool ExecuteArgueList(ArgueList argueList)
    {
        if (this.Null(argueList))
        {
            return true;
        }






        this.AddOpSize();





        this.AddArgSize();





        base.ExecuteArgueList(argueList);





        return true;
    }







    public override bool ExecuteArgue(Argue argue)
    {
        if (this.Null(argue))
        {
            return true;
        }



        

        base.ExecuteArgue(argue);





        this.AddOpSize();





        return true;
    }







    private ulong IntValueSize(ulong n)
    {
        NullableInt64 size;


        size = null;




        ulong one;


        one = 1;




        int o;


        o = (int)this.SizeCompile.Constants.IntSize;




        int count;


        count = o;




        int i;


        i = 0;


        while (!size.HasValue & i < count)
        {
            int shiftCount;
            
            
            shiftCount = i * 8;




            ulong t;


            t = one << shiftCount;



            if (n < t)
            {
                ulong u;


                u = (ulong)i;




                if (u == 0)
                {
                    u = 1;
                }



                size = u;
            }




            i = i + 1;
        }


        
        if (!size.HasValue)
        {
            size = this.SizeCompile.Constants.IntSize;
        }




        ulong ret;


        ret = size.Value;



        return ret;
    }





    private ulong CharSize { get; set; }





    private bool AddClassNameSize()
    {
        ulong size;



        size = this.SizeCompile.ClassNameSize;



        this.AddSize(size);



        return true;
    }





    private bool AddOpSize()
    {
        this.AddByteSize();



        return true;
    }





    private bool AddArgSize()
    {
        this.AddIntSize();



        return true;
    }





    private bool AddTypeSize()
    {
        this.AddByteSize();



        return true;
    }





    private bool AddByteSize()
    {
        this.SizeCompile.AddByteSize();


        return true;
    }





    private bool AddIntSize()
    {
        this.SizeCompile.AddIntSize();


        return true;
    }





    private bool AddSize(ulong size)
    {
        this.SizeCompile.AddSize(size);


        return true;
    }
}