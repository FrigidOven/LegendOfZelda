using ZeldaNES.Sprint2;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.NPCs.Classes.Dodongo;
using ZeldaNES.NPCs.Classes.Keese.States;
using ZeldaNES.NPCs.Classes.Stalfo;
using ZeldaNES.NPCs.Classes.SmallJelly;
using ZeldaNES.NPCs.Classes.BigJelly;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.NPCs.Classes.Aquamentus;
using System.Collections.Generic;
using ZeldaNES.Game_Constants;
using ZeldaNES.Tiles;
using ZeldaNES.Tiles.Classes;
using System.Diagnostics;

namespace ZeldaNES.NPCs.Classes
{
    public class Sprint2Tile : ISprint2, ITile
    {
        int posX;
        int posY;
        public ITile[] tileRef = new ITile[13];
        private ITilePhysicsObject body;
        private IItemPhysicsObject body2;

        public int currentIndex = 0;
       
        Dictionary<int, GeneralConstants.Entities> mapping;
        private ITile IndicatorTile;


        public Sprint2Tile(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            IndicatorTile = new IndicatorTile();
            mapping = new Dictionary<int, GeneralConstants.Entities>();

            tileRef[0] = new BlackTile();
            mapping.Add(0, GeneralConstants.Entities.BlackTile);

            tileRef[1] = new BlockTile();
            mapping.Add(1, GeneralConstants.Entities.BlockTile);

            tileRef[2] = new WaterTile();
            mapping.Add(2, GeneralConstants.Entities.WaterTile);

            tileRef[3] = new WhiteStairTile();
            mapping.Add(3, GeneralConstants.Entities.WhiteStairTile);

            tileRef[4] = new BlueStairTile(posX, posY);
            mapping.Add(4, GeneralConstants.Entities.BlueStairTile);

            tileRef[5] = new RightFacingStatueTile(posX, posY);
            mapping.Add(5, GeneralConstants.Entities.RightFacingStatueTile);

            tileRef[6] = new BrickTile(posX, posY);
            mapping.Add(6, GeneralConstants.Entities.BrickTile);

            tileRef[7] = new LeftFacingStatueTile(posX, posY);
            mapping.Add(7, GeneralConstants.Entities.LeftFacingStatueTile);

            tileRef[8] = new DirtTile(posX, posY);
            mapping.Add(8, GeneralConstants.Entities.DirtTile);

            tileRef[9] = new FloorTile(posX, posY);
            mapping.Add(9, GeneralConstants.Entities.FloorTile);

            tileRef[10] = new BoundryTile(posX, posY);
            mapping.Add(10, GeneralConstants.Entities.BoundryTile);

            tileRef[11] = new DummyTextTile(posX, posY);
            mapping.Add(11, GeneralConstants.Entities.DummyTextTile);

            tileRef[12] = new PushableBlockTile(posX, posY);
            mapping.Add(12, GeneralConstants.Entities.PushableBlockTile);

        }

        public void Update()
        {
            tileRef[currentIndex].Update();
        }
        public void Draw()
        {
            tileRef[currentIndex].Draw();
            IndicatorTile.Draw();
        }
        public void Next()
        {
            Debug.WriteLine(mapping[currentIndex]);
            currentIndex = (currentIndex + 1) % tileRef.Length;
        }
        public void Previous()
        {
            currentIndex = (currentIndex + tileRef.Length - 1) % tileRef.Length;
        }
        public int GetPosX()
        {
            return PosX;
        }

        public bool IsSolid() {
            return true;
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
            tileRef[currentIndex].PosX = x;
        }
        public void SetPosY(int y)
        {
            PosY = y;
            tileRef[currentIndex].PosY = y;

        }
        public void UpdateIndicator(int x, int y) {
            IndicatorTile.PosY = y;
            IndicatorTile.PosX = x;

        }
        public GeneralConstants.Entities GetEntity() {
            return mapping[currentIndex];
        }
        public GeneralConstants.EntitiesType GetEntityType() {
            return GeneralConstants.EntitiesType.ITile;
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
        public ITilePhysicsObject Body()
        {
            return null;
        }

    }
}
