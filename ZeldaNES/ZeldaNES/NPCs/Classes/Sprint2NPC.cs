using ZeldaNES.Sprint2;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.NPCs.Classes.Dodongo;
using ZeldaNES.NPCs.Classes.Keese.States;
using ZeldaNES.NPCs.Classes.Stalfo;
using ZeldaNES.NPCs.Classes.SmallJelly;
using ZeldaNES.NPCs.Classes.BigJelly;
using ZeldaNES.NPCs.Classes.OldMan;
using ZeldaNES.NPCs.Classes.Rope;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.NPCs.Classes.Aquamentus;
using System.Collections.Generic;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Tiles.Classes;
using ZeldaNES.Regions;
using ZeldaNES.Players.Link;
using ZeldaNES.NPCs.Classes.Trap;
using ZeldaNES.NPCs.Classes.WallMaster;



namespace ZeldaNES.NPCs.Classes
{
    public class Sprint2NPC : ISprint2, INPC
    {
        int posX;
        int posY;
        public INPC[] npcRef = new INPC[11];
        public int currentIndex = 0;
        int counter = 100;
        IndicatorTile indicatorTile;
        Dictionary<int, GeneralConstants.Entities> Mapping;


        public Sprint2NPC(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            indicatorTile = new IndicatorTile(posX, posY);
            Mapping = new Dictionary<int, GeneralConstants.Entities>();

            npcRef[0] = new GoriyaEnemy(PosX, PosY);
            Mapping.Add(0, GeneralConstants.Entities.GoriyaEnemy);
            
            npcRef[1] = new BigJellyEnemy(PosX, PosY);
            Mapping.Add(1, GeneralConstants.Entities.BigJellyEnemy);
            
            npcRef[2] = new KeeseEnemy(PosX, PosY);
            Mapping.Add(2, GeneralConstants.Entities.KeeseEnemy);
            
            npcRef[3] = new SmallJellyEnemy(PosX, PosY);
            Mapping.Add(3, GeneralConstants.Entities.SmallJellyEnemy);
            
            npcRef[4] = new StalfoEnemy(PosX, PosY);
            Mapping.Add(4, GeneralConstants.Entities.StalfoEnemy);
            
            npcRef[5] = new TrapEnemy(PosX, PosY);
            Mapping.Add(5, GeneralConstants.Entities.Trap);
            
            npcRef[6] = new WallMasterEnemy(PosX, PosY);
            Mapping.Add(6, GeneralConstants.Entities.WallMaster);
            
            npcRef[7] = new DodongoEnemy(posX, posY);
            Mapping.Add(7, GeneralConstants.Entities.DodongoEnemy);
            
            npcRef[8] = new AquamentusEnemy(PosX, PosY);
            Mapping.Add(8, GeneralConstants.Entities.AquamentusEnemy);

            npcRef[9] = new OldManNPC(PosX, PosY);
            Mapping.Add(9, GeneralConstants.Entities.OldManNPC);

            npcRef[10] = new RopeEnemy(PosX, PosY);
            Mapping.Add(10, GeneralConstants.Entities.RopeEnemy);
        }
        public void UpdateIndicator(int x, int y)
        {
            indicatorTile.PosY = y;
            indicatorTile.PosX = x;

        }
        public IEnemyPhysicsObject Body()
        {
            return null;
        }
        public void Update()
        {
            npcRef[currentIndex].Update();
        }
        public void Draw()
        {
            npcRef[currentIndex].Draw();
            indicatorTile.Draw();
        }
        public void Next()
        {
            currentIndex = (currentIndex + 1) % npcRef.Length;
        }
        public void Previous()
        {
            currentIndex = (currentIndex + npcRef.Length - 1) % npcRef.Length;
        }
        public int GetPosX()
        {
            return PosX;
        }
        public int GetPosY()
        {
            return PosY;
        }
        public int PosX
        {
            get => posX;
            set => posX = value;
        }
        public int PosY
        {
            get => posY;
            set => posY = value;
        }
        public void SetPosX(int x)
        {
            PosX = x;
            npcRef[currentIndex].PosX = x;
        }
        public void SetPosY(int y)
        {
            PosY = y;
            npcRef[currentIndex].PosY = y;
        }
        public GeneralConstants.Entities GetEntity() {
            return Mapping[currentIndex];
        }
        public GeneralConstants.EntitiesType GetEntityType() {
            return GeneralConstants.EntitiesType.INPC;
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

        public void dropLoot(Region region)
        {
            //
        }

        public void freeze()
        {
            //
        }

        public void unfreeze()
        {
            //
        }
        public void AIMovement(ILink link)
        {
            //
        }

    }
}
