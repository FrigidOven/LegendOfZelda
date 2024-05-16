using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Sprint2;
using ZeldaNES.Doors.Classes.HiddenDoor;
using ZeldaNES.Doors.Classes.LockedDoor;
using ZeldaNES.Doors.Classes.OpenDoor;
using ZeldaNES.Doors.Classes.ShutDoor;
using System.Diagnostics;
using ZeldaNES.Physics.Hitboxes;

namespace ZeldaNES.Doors.Classes
{
    public class Sprint2Door: ISprint2
    {
        int posX;
        int posY;
        public int PosX
        {
            get => posX;
            set
            {
                posX = value;
            }
        }
        public int PosY
        {
            get => posY;
            set
            {
                posY = value;
            }
        }
        public IDoor[] doorRef = new IDoor[16];
        public int currentIndex = 0;
        int counter = 100;
        Dictionary<int, GeneralConstants.Entities> Mapping;


        public Sprint2Door(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            Mapping = new Dictionary<int, GeneralConstants.Entities>();

            doorRef[0] = new NorthHiddenDoor();
            Mapping.Add(0, GeneralConstants.Entities.NorthHiddenDoor);

            doorRef[1] = new EastHiddenDoor();
            Mapping.Add(1, GeneralConstants.Entities.EastHiddenDoor);

            doorRef[2] = new SouthHiddenDoor();
            Mapping.Add(2, GeneralConstants.Entities.SouthHiddenDoor);

            doorRef[3] = new WestHiddenDoor();
            Mapping.Add(3, GeneralConstants.Entities.WestHiddenDoor);



            doorRef[4] = new NorthLockedDoor();
            Mapping.Add(4, GeneralConstants.Entities.NorthLockedDoor);
            doorRef[5] = new EastLockedDoor();
            Mapping.Add(5, GeneralConstants.Entities.EastLockedDoor);
            doorRef[6] = new SouthLockedDoor();
            Mapping.Add(6, GeneralConstants.Entities.SouthLockedDoor);
            doorRef[7] = new WestLockedDoor();
            Mapping.Add(7, GeneralConstants.Entities.WestLockedDoor);




            doorRef[8] = new NorthOpenDoor();
            Mapping.Add(8, GeneralConstants.Entities.NorthOpenDoor);
            doorRef[9] = new EastOpenDoor();
            Mapping.Add(9, GeneralConstants.Entities.EastOpenDoor);
            doorRef[10] = new SouthOpenDoor();
            Mapping.Add(10, GeneralConstants.Entities.SouthOpenDoor);
            doorRef[11] = new WestOpenDoor();
            Mapping.Add(11, GeneralConstants.Entities.WestOpenDoor);

            doorRef[12] = new NorthShutDoor();
            Mapping.Add(12, GeneralConstants.Entities.NorthShutDoor);
            doorRef[13] = new EastShutDoor();
            Mapping.Add(13, GeneralConstants.Entities.EastShutDoor);
            doorRef[14] = new SouthShutDoor();
            Mapping.Add(14, GeneralConstants.Entities.SouthShutDoor);
            doorRef[15] = new WestShutDoor();
            Mapping.Add(15, GeneralConstants.Entities.WestShutDoor);
        }
        public void DrawDebug()
        {
            doorRef[currentIndex].DrawDebug();
        }
        public void UpdateIndicator(int x, int y)
        { 
        }
            public void Update()
        {
            doorRef[currentIndex].Update();
        }
        public void Draw()
        {
            //doorRef[currentIndex].Draw();
        }
        public void Next()
        {
            currentIndex = (currentIndex + 1) % doorRef.Length;
        }
        public void Previous()
        {
            currentIndex = (currentIndex + doorRef.Length - 1) % doorRef.Length;
        }
        public int GetPosX()
        {
            return this.posX;
        }
        public int GetPosY()
        {
            return this.posY;
        }
        public void SetPosX(int x)
        {
            PosX = x;
            doorRef[currentIndex].PosX = x;
        }
        public void SetPosY(int y)
        {
            PosY = y;
            doorRef[currentIndex].PosY = y;
        }
        public GeneralConstants.Entities GetEntity()
        {
            Debug.WriteLine("current door enum" + Mapping[currentIndex]);
            return Mapping[currentIndex];
        }
        public GeneralConstants.EntitiesType GetEntityType()
        {
            return GeneralConstants.EntitiesType.IDoor;
        }
        public void Terminate()
        {
        }
        public bool ShouldDelete()
        {
            return false;
        }
        public void SetDeletable(bool deletable)
        {
        }
        public IItemPhysicsObject Body()
        {
            return null;
        }
    }
}
