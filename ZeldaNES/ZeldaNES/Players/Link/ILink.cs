using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Game_Constants;
using ZeldaNES.Inventories;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Weapons;

namespace ZeldaNES.Players.Link
{
    public interface ILink:  IWeaponUser
    {
        void Update();
        void Draw();
        bool IsBusy { set; }
        GeneralConstants.Orientation Orientation { get; set; }
        public ILinkState GetState();
        public void SetState(ILinkState state);
        IPlayerPhysicsObject Body();
        public Inventory GetInventory();
        public int HealthCapacity { get; set; }

        int PosX { get; set; }
        int PosY { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
        bool IsTakingDamage {  get; set; }
        bool IsAbleToDash { get; set; }

        void Stop();
        void WalkUp();
        void WalkDown();
        void WalkLeft();
        void WalkRight();
        void SwingSword();
        void UseWoodenArrow();
        void UseMetalArrow();
        void UseWoodenBoomerang();
        void UseMetalBoomerang();
        void UseBomb();
        void UseFire();
        void PickUpSmall();
        void PickUpLarge();
        void Dash();

        void Death();
        public void KnockBack(GeneralConstants.Orientation direction, int distance);

        void useClock();

        public bool TimeFreeze();
        public bool UnFreeze();
    }
}
