using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// A catch all interface for any items that may be spawned in. contains items and projectiles
namespace ZeldaNES.Objects
{
    public interface IObject
    {
        void Update();
        void Draw();
        int GetX();                      //returns the object's x coordinate
        int GetWhy();                    //returns object's y coordinate
        void SetPos(int x, int why);     //sets the object's position based on given x and y coordinates
        void SetBusy(bool b);            //link class had one of these so im putting this here just incase
        //it would be nice to also have a way of deleting objects. i have no fucking clue how thatd be done though...

    }
}
