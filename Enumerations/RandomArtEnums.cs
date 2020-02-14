using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomArt.Enumerations
{
    
    public enum ColorEnum : int
    {
        Red = 0,
        Green = 1,
        Blue = 2
    }

     public enum DirectionEnum : int
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }

    public enum LightFilterEnum : int
    {
        None = 0,
        Light = 1,
        Dark = 2
    }

    public enum ChangeEnum : int
    {
        MoveDown = -1,
        NoChange = 0,
        MoveUp = 1
    }
}
