using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.Physics.Hitboxes
{
    public class Hitbox : IHitbox
    {
        private bool isActive;

        private int width;
        private int height;

        private int offsetX;
        private int offsetY;

        private Rectangle bounds;


        public Hitbox(int posX, int posY, int offsetX, int offsetY, int width, int height, bool isActive)
        {
            this.width = GeneralConstants.ImageScale * width;
            this.height = GeneralConstants.ImageScale * height;
            this.isActive = isActive;

            this.offsetX = offsetX;
            this.offsetY = offsetY;

            int boundsX = posX + offsetX - (this.width / 2);
            int boundsY = posY + offsetY - (this.height / 2);
            bounds = new Rectangle(boundsX, boundsY, this.width, this.height);
        }
        public Hitbox(int posX, int posY, int offsetX, int offsetY, int size, bool isActive)
        {
            width = GeneralConstants.ImageScale * size;
            height = GeneralConstants.ImageScale * size;
            this.isActive = isActive;

            this.offsetX = offsetX;
            this.offsetY = offsetY;

            int boundsX = posX + offsetX - (width / 2);
            int boundsY = posY + offsetY - (height / 2);
            bounds = new Rectangle(boundsX, boundsY, this.width, this.height);
        }
        public Hitbox(int posX, int posY, int size, bool isActive)
        {
            width = GeneralConstants.ImageScale * size;
            height = GeneralConstants.ImageScale * size;
            this.isActive = isActive;

            offsetX = 0;
            offsetY = 0;

            int boundsX = posX - (width / 2);
            int boundsY = posY - (height / 2);
            bounds = new Rectangle(boundsX, boundsY, this.width, this.height);
        }
        public bool IsActive
        {
            get => isActive;
            set => isActive = value;
        }
        public int PosX
        { 
            get => bounds.X + (width/2);
            set => bounds.X = value - (width/2) + offsetX;
        }
        public int PosY 
        { 
            get => bounds.Y + (height/2);
            set => bounds.Y = value - (height / 2) + offsetY;
        }
        public int OffsetX
        {
            get => offsetX;
            set => offsetX = value;
        }
        public int OffsetY
        {
            get => offsetY;
            set => offsetY = value;
        }
        public int Width
        {
            get => width;
            set => width = value;
        }
        public int Height
        {
            get => height;
            set => height = value;
        }
        public Rectangle Bounds
        {
            get => bounds;
        }

        public bool Intersects(IHitbox hitbox)
        {
            return bounds.Intersects(hitbox.Bounds);
        }

        public GeneralConstants.Orientation Side(IHitbox hitbox)
        {
            int dx = PosX - hitbox.PosX;
            int dy = PosY - hitbox.PosY;

            if(Math.Abs(dx) > Math.Abs(dy))
            {
                return HorizontalSide(hitbox, dx);
            }
            return VerticalSide(hitbox, dy);
        }
        private GeneralConstants.Orientation HorizontalSide(IHitbox hitbox, int dx)
        {
            if(dx < 0)
            {
                return GeneralConstants.Orientation.Left;
            }
            return GeneralConstants.Orientation.Right;
        }
        private GeneralConstants.Orientation VerticalSide(IHitbox hitbox, int dy)
        {
            if(dy < 0)
            {
                return GeneralConstants.Orientation.Up;
            }
            return GeneralConstants.Orientation.Down;
        }
    }
}
