namespace Case;






public class Task : Object
{
    public TaskKind Kind { get; set; }





    public string Node { get; set; }



    public string Check { get; set; }





    public SourceArray Source { get; set; }




    public string SourcePath { get; set; }






    public bool Print { get; set; }







    public PortPort Port { get; set; }






    public TextWriter Out { get; set; }
}