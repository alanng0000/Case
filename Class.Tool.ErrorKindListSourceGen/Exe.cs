namespace Class.Tool.ErrorKindsSourceGen;




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