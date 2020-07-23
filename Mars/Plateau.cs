using System.Collections.Generic;

namespace MarsApp.Mars
{
    public class Plateau
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Rover> Rovers { get; set; }
    }
}