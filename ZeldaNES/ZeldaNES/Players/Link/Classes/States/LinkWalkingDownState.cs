﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites.Classes.LinkSprites;
using ZeldaNES.Sprites;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Game_Constants;
using ZeldaNES.Factories;

namespace ZeldaNES.Players.Link.Classes.States
{
    public class LinkWalkingDownState : ILinkState
    {
        private Link link;
        private ISprite sprite;
        public LinkWalkingDownState(Link link)
        {
            this.link = link;
            this.link.Orientation = GeneralConstants.Orientation.Down;
            this.sprite = new LinkWalkingDownSprite(this.link);
        }
        public void Update()
        {
            sprite.Update();
            this.link.PosY = this.link.PosY + PlayerConstants.LinkWalkingSpeed;
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Stop()
        {
            this.link.SetState(new LinkStoppedDownState(this.link));
        }
        public void WalkUp()
        {
            this.link.SetState(new LinkStoppedUpState(this.link));
        }
        public void WalkDown()
        {
            // do nothing, already walking down
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

        }
        public void Death()
        {
            link.SetState(new LinkDeathState(this.link));
        }
    }
}