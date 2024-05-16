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
using ZeldaNES.Physics.Hitboxes;

namespace ZeldaNES.Players.Link.Classes.States
{
    public class LinkStoppedDownState : ILinkState
    {
        private Link link;
        private ISprite sprite;

        private int knockedbackDistance;
        private bool isGettingKnockedBack;

        public LinkStoppedDownState(Link link)
        {
            this.link = link;
            this.link.Orientation = GeneralConstants.Orientation.Down;
            this.sprite = new LinkWalkingDownSprite(this.link);

            knockedbackDistance = 0;
            isGettingKnockedBack = false;

            ReorientateSword();
        }
        private void ReorientateSword()
        {
            link.Body().SwordHitbox = new Hitbox(link.PosX,
                                          link.PosY,
                                          PlayerConstants.LinkDownSwordHitboxXOffset,
                                          PlayerConstants.LinkDownSwordHitboxYOffset,
                                          PlayerConstants.LinkDownSwordHitboxWidth,
                                          PlayerConstants.LinkDownSwordHitboxHeight,
                                          false);
        }
        public void Update()
        {
            if(!isGettingKnockedBack)
                return;

            link.PosY -= PlayerConstants.LinkWalkingSpeed;
            knockedbackDistance -= PlayerConstants.LinkWalkingSpeed;

            if (knockedbackDistance <= 0)
            {
                knockedbackDistance = 0;
                link.IsBusy = false;
                isGettingKnockedBack = false;
                link.Stop();
            }
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Stop()
        {
            // Do nothing, stopped
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
            this.link.SetState(new LinkSwingingSwordDownState(this.link));
        }
        public void UseWeapon()
        {
            link.SetState(new LinkUsingWeaponDownState(this.link));
        }
        public void Dash()
        {
            link.SetState(new LinkDashState(this.link));
        }
        public void PickUpSmall()
        {

        }
        public void PickUpLarge()
        {

        }
        public void KnockBack(int distance)
        {
            if (!isGettingKnockedBack)
            {
                isGettingKnockedBack = true;
                knockedbackDistance = distance;
                link.IsBusy = true;
            }
        }
        public void Death()
        {
            link.SetState(new LinkDeathState(this.link));
        }
    }
}
