namespace Class.Tool.SystemModuleGen;




class Module : Object
{
    public ModuleRefer Refer { get; set; }



    public Array Class { get; set; }



    public Array Import { get; set; }



    public Array Export { get; set; }



    public ClassIndex Entry { get; set; }
}