using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites.Classes.LinkSprites;
using ZeldaNES.Sprites;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Game_Constants;
using ZeldaNES.Factories;
using ZeldaNES.Regions;

namespace ZeldaNES.Players.Link.Classes.States
{
    public class LinkDashState : ILinkState
    {
        private Link link;
        private ISprite sprite;
        public LinkDashState(Link link)
        {
            this.link = link;
            this.sprite = new LinkWalkingUpSprite(this.link); //Default orientation for cases where draw occurs before update
        }
        public void Update()
        {
            
            this.link.IsTakingDamage = true;
            if (this.link.Orientation == GeneralConstants.Orientation.Down)
            {
                this.sprite = new LinkWalkingDownSprite(this.link);
                this.link.PosY = this.link.PosY + PlayerConstants.LinkDashingSpeed;
                
            } else if(this.link.Orientation == GeneralConstants.Orientation.Up)
            {
                this.sprite = new LinkWalkingUpSprite(this.link);
                this.link.PosY = this.link.PosY - PlayerConstants.LinkDashingSpeed;
            }
            else if (this.link.Orientation == GeneralConstants.Orientation.Left)
            {
                this.sprite = new LinkWalkingLeftSprite(this.link);
                this.link.PosX = this.link.PosX - PlayerConstants.LinkDashingSpeed;

            }
            else if (this.link.Orientation == GeneralConstants.Orientation.Right)
            {
                this.sprite = new LinkWalkingRightSprite(this.link);
                this.link.PosX = this.link.PosX + PlayerConstants.LinkDashingSpeed;
            }
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Stop()
        {
            if (this.link.Orientation == GeneralConstants.Orientation.Down)
            {
                this.link.SetState(new LinkStoppedDownState(this.link));
            }
            else if (this.link.Orientation == GeneralConstants.Orientation.Up)
            {
                this.link.SetState(new LinkStoppedUpState(this.link));
            }
            else if (this.link.Orientation == GeneralConstants.Orientation.Left)
            {
                this.link.SetState(new LinkStoppedLeftState(this.link));
            }
            else if (this.link.Orientation == GeneralConstants.Orientation.Right)
            {
                this.link.SetState(new LinkStoppedRightState(this.link));
            }
        }
        public void WalkUp()
        {
            this.link.SetState(new LinkStoppedUpState(this.link));
        }
        public void WalkDown()
        {
            this.link.SetState(new LinkWalkingDownState(this.link));
        }
        public void WalkLeft()
        {
            this.link.SetState(new LinkStoppedLeftState(this.link));
        }
        public void WalkRight()
        {
            this.link.SetState(new LinkStoppedRightState(this.link));
        }
        public void SwingSword()
        {
            this.link.SetState(new LinkSwingingSwordRightState(this.link));
        }
        public void UseWeapon()
        {
            link.SetState(new LinkUsingWeaponRightState(this.link));
        }
        public void Dash()
        {
            //nothing to do, already in state
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
            link.SetState(new LinkDeathState(this.link));
        }
    }
}
