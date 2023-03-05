namespace Case.Tool.ErrorKindListSourceGen;




class Exe
{
    static void Main(string[] args)
    {
        Module module;
        
        
        module = new Module();


        module.Init();


        module.Execute(args);
    }
}