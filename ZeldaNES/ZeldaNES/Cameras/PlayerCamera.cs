using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.TileSprites;

namespace ZeldaNES.Cameras
{
    public class PlayerCamera : ICamera
    {
        private static PlayerCamera instance;

        private Matrix transform;

        private Matrix upScreen;
        private Matrix downScreen;
        private Matrix leftScreen;
        private Matrix rightScreen;

        private Vector3 offset;
        private Vector3 upOffset;
        private Vector3 downOffset;
        private Vector3 leftOffset;
        private Vector3 rightOffset;
        private Vector3 position;
        private Vector3 destination;

        private float speed;
        private float scale;

        public static PlayerCamera Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerCamera();
                }
                return instance;
            }
        }
        public Matrix Transform
        {
            get => transform;
        }
        public Matrix UpScreen { 
            get => upScreen;
        }
        public Matrix DownScreen 
        { 
            get => downScreen;
        }
        public Matrix LeftScreen
        { 
            get => leftScreen;
        }
        public Matrix RightScreen
        { 
            get => rightScreen;
        }
        public float Speed
        {
            set
            {
                if (value < 0.1f)
                    speed = 0.1f;
                else
                    speed = value;
            }
        }
        public float Scale
        {
            set
            {
                if (value < 0.1f)
                    scale = 0.1f;
                else if (value < 3f)
                    scale = value;
                else
                    scale = 3f;
            }
        }

        private PlayerCamera()
        {
            // center of screen based coordinates
            offset = new Vector3(GeneralConstants.ScreenWidth/2, GeneralConstants.ScreenHeight/2, 0);

            position = offset;
            destination = offset;

            // just to get screen transitions working
            offset.Y += GeneralConstants.UIBarHeight;


            upOffset = new Vector3(0, GeneralConstants.ScreenHeight - GeneralConstants.UIBarHeight, 0);
            downOffset = new Vector3(0, -GeneralConstants.ScreenHeight + GeneralConstants.UIBarHeight, 0);
            leftOffset = new Vector3(GeneralConstants.ScreenWidth, 0, 0);
            rightOffset = new Vector3(-GeneralConstants.ScreenWidth, 0, 0);

            upScreen = Matrix.CreateTranslation(offset - upOffset - position);
            downScreen = Matrix.CreateTranslation(offset - downOffset - position);
            leftScreen = Matrix.CreateTranslation(offset - leftOffset - position);
            rightScreen = Matrix.CreateTranslation(offset - rightOffset - position);

            transform = Matrix.Identity;

            speed = 2 * GeneralConstants.ImageScale;
            scale = 1f;
        }
        public void Update()
        {
            if (AtDestination())
            {
                SnapTo(destination);
            }
            else
            {
                Vector3 direction = destination - position;
                direction.Normalize();
                direction *= speed;

                position += direction;
            }

            upScreen = Matrix.CreateTranslation(offset - upOffset - position);
            downScreen = Matrix.CreateTranslation(offset - downOffset - position);
            leftScreen = Matrix.CreateTranslation(offset - leftOffset - position);
            rightScreen = Matrix.CreateTranslation(offset - rightOffset - position);

            transform = Matrix.CreateScale(scale);
            transform = Matrix.Multiply(transform, Matrix.CreateTranslation(offset - scale * position));
        }
        public bool AtDestination()
        {
            return Vector3.Distance(position, destination) < speed;
        }
        public void SetDestination(int posX, int posY)
        {
            destination = new Vector3(posX, posY, 0);
        }
        public void PanUp()
        {
            Shift(0, -GeneralConstants.ScreenHeight + GeneralConstants.UIBarHeight);
        }
        public void PanDown()
        {
            Shift(0, GeneralConstants.ScreenHeight - GeneralConstants.UIBarHeight);
        }
        public void PanLeft()
        {
            Shift(-GeneralConstants.ScreenWidth, 0);
        }
        public void PanRight()
        {
            Shift(GeneralConstants.ScreenWidth, 0);
        }
        public void Shift(int posX, int posY)
        {
            destination += new Vector3(posX, posY, 0);
        }
        public void SnapTo(int posX, int posY)
        {
            destination = new Vector3(posX, posY, 0);
            position = destination;
        }
        private void SnapTo(Vector3 coordinates)
        {
            destination = coordinates;
            position = destination;
        }
        public void Reset()
        {
            SnapTo(GeneralConstants.ScreenWidth / 2, GeneralConstants.ScreenHeight / 2);
        }
    }
}
