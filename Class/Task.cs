namespace Class;






public class Task : Object
{
    public TaskKind Kind { get; set; }





    public string Node { get; set; }



    public string Check { get; set; }




    public string Source { get; set; }




    public bool Print { get; set; }







    public PortPort Port { get; set; }






    public TextWriter Out { get; set; }
}