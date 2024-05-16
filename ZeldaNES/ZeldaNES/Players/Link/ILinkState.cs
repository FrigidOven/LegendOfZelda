using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Factories;

namespace ZeldaNES.Players.Link
{
    public interface ILinkState
    {
        void Update();
        void Draw();

        
        void Stop();
        void WalkUp();
        void WalkDown();
        void WalkLeft();
        void WalkRight();

        void SwingSword();
        void UseWeapon();
        void PickUpSmall();
        void PickUpLarge();

        void Death();

        void Dash();
        void KnockBack(int distance);

        /*
        void WalkUp();
        void WalkDown();
        void WalkLeft();
        void WalkRight();

        void SwingSwordUp();
        void SwingSwordDown();
        void SwingSwordLeft();
        void SwingSwordRight();

        void UseItemUp();
        void UseItemDown();
        void UseItemLeft();
        void UseItemRight();

        void PickUpSmall();
        void PickUpLarge();
        */
    }
}
