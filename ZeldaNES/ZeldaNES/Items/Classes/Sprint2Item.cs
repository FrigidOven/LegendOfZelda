using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Sprint2;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.ItemSprites;
using ZeldaNES.Tiles;
using ZeldaNES.Tiles.Classes;

namespace ZeldaNES.Items.Classes
{   
    public class Sprint2Item: IItem, ISprint2
    {
        int posX;
        int posY;
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
        Dictionary<int, GeneralConstants.Entities> mapping;

        public IItem[] itemRef = new IItem[ItemSpriteConstants.NumberOfItems];
        public int currentIndex = 0;
        private ITile IndicatorTile;
        private IItemPhysicsObject body;
        private bool deletable = false;


        public Sprint2Item(int x, int y) {
            PosX = x;
            PosY = y;
            IndicatorTile = new IndicatorTile();
            mapping = new Dictionary<int, GeneralConstants.Entities>();


            itemRef[0] = new BlueCandleItem();
            mapping.Add(0, GeneralConstants.Entities.BlueCandleItem);

            itemRef[1] = new BluePotionItem();
            mapping.Add(1, GeneralConstants.Entities.BluePotionItem);

            itemRef[2] = new BlueRingItem();
            mapping.Add(2, GeneralConstants.Entities.BlueRingItem);

            itemRef[3] = new BombItem();
            mapping.Add(3, GeneralConstants.Entities.BombItem);

            itemRef[4] = new BookOfMagicItem();
            mapping.Add(4, GeneralConstants.Entities.BookOfMagicItem);

            itemRef[5] = new BowItem();
            mapping.Add(5, GeneralConstants.Entities.BowItem);

            itemRef[6] = new ClockItem();
            mapping.Add(6, GeneralConstants.Entities.ClockItem);

            itemRef[7] = new CompassItem();
            mapping.Add(7, GeneralConstants.Entities.CompassItem);

            itemRef[8] = new FairyItem();
            mapping.Add(8, GeneralConstants.Entities.FairyItem);

            itemRef[9] = new HalfHeartItem();
            mapping.Add(9, GeneralConstants.Entities.HalfHeartItem);

            itemRef[10] = new HeartContainerItem();
            mapping.Add(10, GeneralConstants.Entities.HeartContainerItem);

            itemRef[11] = new HeartItem();
            mapping.Add(11, GeneralConstants.Entities.HeartItem);

            itemRef[12] = new KeyItem();
            mapping.Add(12, GeneralConstants.Entities.KeyItem);

            itemRef[13] = new LetterItem();
            mapping.Add(13, GeneralConstants.Entities.LetterItem);

            itemRef[14] = new MagicalKeyItem();
            mapping.Add(14, GeneralConstants.Entities.MagicalKeyItem);

            itemRef[15] = new MagicalRodItem();
            mapping.Add(15, GeneralConstants.Entities.MagicalRodItem);

            itemRef[16] = new MagicalShieldItem();
            mapping.Add(16, GeneralConstants.Entities.MagicalShieldItem);

            itemRef[17] = new MagicalSwordItem();
            mapping.Add(17, GeneralConstants.Entities.MagicalSwordItem);

            itemRef[18] = new MapItem();
            mapping.Add(18, GeneralConstants.Entities.MapItem);

            itemRef[19] = new MeatItem();
            mapping.Add(19, GeneralConstants.Entities.MeatItem);

            itemRef[20] = new MetalArrowItem();
            mapping.Add(20, GeneralConstants.Entities.MetalArrowItem);

            itemRef[21] = new MetalBoomerangItem();
            mapping.Add(21, GeneralConstants.Entities.MetalBoomerangItem);

            itemRef[22] = new MetalSwordItem();
            mapping.Add(22, GeneralConstants.Entities.MetalSwordItem);

            itemRef[23] = new PowerBraceletItem();
            mapping.Add(23, GeneralConstants.Entities.PowerBraceletItem);

            itemRef[24] = new RaftItem();
            mapping.Add(24, GeneralConstants.Entities.RaftItem);

            itemRef[25] = new RecorderItem();
            mapping.Add(25, GeneralConstants.Entities.RecorderItem);

            itemRef[26] = new RedCandleItem();
            mapping.Add(26, GeneralConstants.Entities.RedCandleItem);

            itemRef[27] = new RedPotionItem();
            mapping.Add(27, GeneralConstants.Entities.RedPotionItem);

            itemRef[28] = new RedRingItem();
            mapping.Add(28, GeneralConstants.Entities.RedRingItem);

            itemRef[29] = new RupeeItem();
            mapping.Add(29, GeneralConstants.Entities.RupeeItem);

            itemRef[30] = new WoodenSwordItem();
            mapping.Add(30, GeneralConstants.Entities.WoodenSwordItem);

            itemRef[31] = new StepladderItem();
            mapping.Add(31, GeneralConstants.Entities.StepladderItem);

            itemRef[32] = new TriforceItem();
            mapping.Add(32, GeneralConstants.Entities.TriforceItem);

            itemRef[33] = new WoodenArrowItem();
            mapping.Add(33, GeneralConstants.Entities.WoodenArrowItem);

            itemRef[34] = new WoodenBoomerangItem();
            mapping.Add(34, GeneralConstants.Entities.WoodenBoomerangItem);


        }
        public void UpdateIndicator(int x, int y)
        {
            IndicatorTile.PosY = y;
            IndicatorTile.PosX = x;
        }
        public void Update() {
            itemRef[currentIndex].Update();
        }
        public void Draw() {
            itemRef[currentIndex].Draw();
            IndicatorTile.Draw();

        }
 
        public void Next() {
            currentIndex = (currentIndex + 1) % itemRef.Length;
        }
        public void Previous()
        {
            currentIndex = (currentIndex + itemRef.Length-1) % itemRef.Length;
        }
        public int GetPosX() { 
            return PosX; 
        }
        public int GetPosY() { 
            return PosY;
        }
        public GeneralConstants.Entities GetEntity() {
            return mapping[currentIndex];
        }

        public GeneralConstants.EntitiesType GetEntityType()
        {
            return GeneralConstants.EntitiesType.IItem;
        }
        public void SetPosX(int x)
        {
            PosX = x;
            itemRef[currentIndex].PosX = x;
        }
        public void SetPosY(int y)
        {
            PosY = y;
            itemRef[currentIndex].PosY = y;

        }
        public void Terminate() { 
        }
        public bool ShouldDelete()
        {
            return this.deletable;
        }
        public void SetDeletable(bool deletable)
        {
            this.deletable = deletable;
        }
        public IItemPhysicsObject Body()
        {
            return null;
        }

    }
}
