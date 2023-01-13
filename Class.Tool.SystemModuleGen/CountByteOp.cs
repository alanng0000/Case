namespace Class.Tool.SystemModuleGen;




class CountByteOp : ByteOp
{
    public Write Write { get; set; }



    public override bool Execute(byte ob)
    {
        ulong k;


        k = this.Write.Index;



        k = k + 1;



        this.Write.Index = k;



        return true;
    }
}