using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.Hitboxes;
using ZeldaNES.Sprites.Classes.LinkSprites;
using ZeldaNES.Sprites;
using ZeldaNES.Items.Classes;
using ZeldaNES.Sprites.Classes.ItemSprites;

namespace ZeldaNES.Players.Link.Classes.States
{
    internal class LinkTriforceState : ILinkState
    {
        private Link link;
        private ISprite sprite;

        private TriforceItem triforce;

        public LinkTriforceState(Link link)
        {
            this.link = link;
            this.link.Orientation = GeneralConstants.Orientation.Down;
            this.sprite = new LinkTriforceSprite(this.link);

            triforce = new TriforceItem();
            triforce.SetPosX(this.link.PosX);
            triforce.SetPosY(this.link.PosY - 3*ItemSpriteConstants.SpriteSize);
            
        }
        
        public void Update()
        {
            sprite.Update();
            triforce.Update();
        }
        public void Draw()
        {
            sprite.Draw();
            triforce.Draw();
        }
        public void Stop()
        {
            // Do nothing, stopped
        }
        public void WalkUp()
        {
            
        }
        public void WalkDown()
        {
            
        }
        public void WalkLeft()
        {
            
        }
        public void WalkRight()
        {
            
        }
        public void SwingSword()
        {
            
        }
        public void UseWeapon()
        {
            
        }
        public void Dash()
        {
            
        }
        public void PickUpSmall()
        {

        }
        public void PickUpLarge()
        {

        }
        public void KnockBack(int distance)
        {
            
        }
        public void Death()
        {
            //Nothing to do, already won.
        }
    }
}
