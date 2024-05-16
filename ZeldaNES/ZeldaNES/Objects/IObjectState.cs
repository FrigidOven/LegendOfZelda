using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//I have no idea whether or not this will be needed, but better to be safe than sorry?? delete if not needed

namespace ZeldaNES.Objects
{
	public interface IObjectState
	{
        void Update();
        void Draw();

        void Stop();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();   //these methods seemed like they might come in handy so i copied them from linkstate
    }
}
