using ZeldaNES.Factories;
using ZeldaNES.Game_Constants;
using ZeldaNES.Inventories;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Players.Link.Classes.States;

namespace ZeldaNES.Players.Link.Classes
{
    public class Link : ILink
    {
        private ILinkState state;

        private WeaponFactory weaponFactory;

        private GeneralConstants.Orientation orientation;

        private IPlayerPhysicsObject body;

        private int damageTicks;

        private bool isBusy;
        private bool isAbleToDash;

        private Inventory inventory;
        public int HealthCapacity { get; set; }
        private bool isFriendly;

        public int timeFreeze;

        public bool TimeFreeze() {
            if (timeFreeze > 0) {
                return true;
            }
            return false;
        }

        public bool UnFreeze()
        {
            if (timeFreeze == 1)
            {
                return true;
            }
            return false;
        }

        public void SetWeaponFactory(WeaponFactory weaponfactory) {
            this.weaponFactory = weaponfactory;
        }
        public ILinkState GetState() {
            return state;
        }
        public void SetState(ILinkState state) {
            this.state = state;
        }

        public Link(WeaponFactory weaponFactory)
        {
            body = new PlayerPhysicsObject();

            this.weaponFactory = weaponFactory;

            // default state for now
            state = new LinkStoppedDownState(this);

            // busy determines if link can switch states true if he cant false if he can
            isBusy = false;
            isFriendly = true;
            isAbleToDash = false;
            damageTicks = 0;

            this.inventory = new Inventory(this); //
          
            this.HealthCapacity = PlayerConstants.LinkHealthCapacity;
            this.Health = 6;
            this.HealthCapacity = 6;

            timeFreeze = 0;
        }
        public Link()
        {
            body = new PlayerPhysicsObject();
            // default state for now
            state = new LinkStoppedDownState(this);

            // busy determines if link can switch states true if he cant false if he can
            isBusy = false;
            isFriendly = true;
            damageTicks = 0;

            this.inventory = new Inventory(this); //
           
            this.HealthCapacity = PlayerConstants.LinkHealthCapacity;
            ;

            timeFreeze = 0;
        }
        public Inventory GetInventory()
        {
            return inventory;
        }
        public IPlayerPhysicsObject Body()
        {
            return body;
        }
        public void Update()
        {
            if (GameStates.GameState.Instance.WinMode)
            {
                if (state is not LinkTriforceState)
                {
                    this.SetState(new LinkTriforceState(this));
                }
            }
            else if (GameStates.GameState.Instance.deathMode|| this.Health <=0)
            {
                this.SetState(new LinkDeathState(this));
                GameStates.GameState.Instance.deathMode = true;
            }
            state.Update();

            if (body.IsTakingDamage)
            {
                damageTicks++;
            }
            if(damageTicks >= PlayerConstants.DamageTicks)
            {
                damageTicks = 0;
                body.IsTakingDamage = false;
            }

            if (timeFreeze > 0)
            {
                timeFreeze--;
            }
        }
        public void Draw()
        {

            state.Draw();

            //draw hitbox, for testing only
            /**
            Rectangle d = playerHitbox.Bounds;
            Rectangle d1 = swordHitbox.Bounds;
            Rectangle d3 = new Rectangle(playerHitbox.PosX, playerHitbox.PosY, 3, 3);

            Rectangle s = new Rectangle(120, 358, 1, 1);

            spriteBatch.Draw(texture, d, s, Color.White);
            spriteBatch.Draw(texture, d1, s, Color.White);
            spriteBatch.Draw(texture, d3, s, Color.Black);
            **/
        }
        public int PosX
        {
            get => body.PosX;
            set
            {
                body.PosX = value;
            }
        }
        public int PosY
        {
            get => body.PosY;
            set
            {
                body.PosY = value;
            }
        }
        public int Health
        {
            get => body.Health;
            set => body.Health = value;
        }
        public bool IsTakingDamage
        {
            get => body.IsTakingDamage;
            set => body.IsTakingDamage = value;
        }
        public GeneralConstants.Orientation Orientation
        {
            get => orientation;
            set => orientation = value;
        }
        public bool IsBusy
        {
            get => isBusy;
            set => isBusy = value;
        }
        public bool IsFriendly
        {
            get => isFriendly;
            private set => isFriendly = value;
        }
        public bool IsAbleToDash
        {
            get => isAbleToDash;
            set => isAbleToDash = value;
        }
        public int Damage
        { 
            get => body.Damage; 
            set => body.Damage = value;
        }
        public void Stop()
        {
            if (!isBusy)
            {
                state.Stop();
                body.SwordHitbox.IsActive = false;
            }
        }
        public void WalkUp()
        {
            if(!isBusy)
                state.WalkUp();
        }
        public void WalkDown()
        {
            if (!isBusy)
                state.WalkDown();
        }
        public void WalkLeft()
        {
            if (!isBusy)
                state.WalkLeft();
        }
        public void WalkRight()
        {
            if (!isBusy)
                state.WalkRight();
        }
        public void SwingSword()
        {
            if (!isBusy)
            {
                state.SwingSword();
                body.SwordHitbox.IsActive = true;
                SoundManager.SoundManager.Instance.SwordSlash.CreateInstance().Play();
            }
        }
        public void UseWoodenArrow()
        {
            if (isBusy)
                return;
            
            state.UseWeapon();

            int xOffset = GetWeaponXOffset(); 
            int yOffset = GetWeaponYOffset();

            if (inventory.Rupees > 0 && inventory.hasBow(inventory.EquippableItems()))
            {
                inventory.Rupees--;

                weaponFactory.MakeNewWoodenArrow(body.PosX + xOffset, body.PosY + yOffset, orientation, this);
                SoundManager.SoundManager.Instance.ArrowBoomerang.CreateInstance().Play();
            }
        }
        public void UseMetalArrow()
        {
            if (isBusy)
                return;

            state.UseWeapon();

            int xOffset = GetWeaponXOffset();
            int yOffset = GetWeaponYOffset();

            if (inventory.Rupees > 0 && inventory.hasBow(inventory.EquippableItems()))
            {
                inventory.Rupees--;

                weaponFactory.MakeNewMetalArrow(body.PosX + xOffset, body.PosY + yOffset, orientation, this);
                SoundManager.SoundManager.Instance.ArrowBoomerang.CreateInstance().Play();
            }
        }
        public void UseWoodenBoomerang()
        {
            if (isBusy)
                return;

            state.UseWeapon();

            int xOffset = GetWeaponXOffset();
            int yOffset = GetWeaponYOffset();

            weaponFactory.MakeNewWoodenBoomerang(body.PosX + xOffset, body.PosY + yOffset, orientation, this);

            SoundManager.SoundManager.Instance.ArrowBoomerang.CreateInstance().Play();
        }
        public void UseMetalBoomerang()
        {
            if (isBusy)
                return;

            state.UseWeapon();

            int xOffset = GetWeaponXOffset();
            int yOffset = GetWeaponYOffset();

            weaponFactory.MakeNewMetalBoomerang(body.PosX + xOffset, body.PosY + yOffset, orientation, this);

            SoundManager.SoundManager.Instance.ArrowBoomerang.CreateInstance().Play();
        }
        public void UseBomb()
        {
            if (isBusy)
                return;

            state.UseWeapon();

            int xOffset = GetWeaponXOffset();
            int yOffset = GetWeaponYOffset();

            if (inventory.Bombs > 0)
            {
                inventory.Bombs--;
                weaponFactory.MakeNewBomb(body.PosX + xOffset, body.PosY + yOffset, this);
                SoundManager.SoundManager.Instance.BombDrop.CreateInstance().Play();
            }
        }
        public void UseFire()
        {
            if (isBusy)
                return;

            state.UseWeapon();

            int xOffset = GetWeaponXOffset();
            int yOffset = GetWeaponYOffset();

            weaponFactory.MakeNewFire(body.PosX + xOffset, body.PosY + yOffset, orientation, this);

            SoundManager.SoundManager.Instance.Candle.CreateInstance().Play();
        }


        public void useClock()
        {
            if (isBusy)
                return;

            state.UseWeapon();

            //            int xOffset = GetWeaponXOffset();
            //          int yOffset = GetWeaponYOffset();

            //        weaponFactory.MakeNewFire(body.PosX + xOffset, body.PosY + yOffset, orientation, this);
            if (inventory.Rupees >= 10 && inventory.hasClock(inventory.EquippableItems())) {
                inventory.Rupees -= 10;

                timeFreeze = PlayerConstants.FreezeTime;

                int xOffset = GetWeaponXOffset();
                int yOffset = GetWeaponYOffset();
                weaponFactory.MakeNewClock(body.PosX + xOffset, body.PosY + yOffset, orientation, this);
                SoundManager.SoundManager.Instance.BombDrop.CreateInstance().Play();
            }

            ///SoundManager.SoundManager.Instance.Secret.Play();
        }


        public void PickUpSmall()
        {
            if (!isBusy)
                state.PickUpSmall();
        }
        public void PickUpLarge()
        {
            if (!isBusy)
                state.PickUpLarge();
        }
        public void Dash()
        {
            if (!isBusy && isAbleToDash)
            {
                state.Dash();
            }
                
        }
        public void Death()
        {
            state.Death();
        }
        public void KnockBack(GeneralConstants.Orientation direction, int distance)
        {
            if(IsBusy)
                return;

            state = direction switch
            {
                GeneralConstants.Orientation.Up => new LinkStoppedDownState(this),
                GeneralConstants.Orientation.Down => new LinkStoppedUpState(this),
                GeneralConstants.Orientation.Left => new LinkStoppedRightState(this),
                _ => new LinkStoppedLeftState(this)
            };
            state.KnockBack(distance);
        }
        private int GetWeaponXOffset()
        {
            int xOffset = orientation switch
            {
                GeneralConstants.Orientation.Left => -WeaponConstants.WeaponSpawnDistance,
                GeneralConstants.Orientation.Right => WeaponConstants.WeaponSpawnDistance,
                _ => 0
            };
            return xOffset;
        }
        private int GetWeaponYOffset()
        {
            int yOffset = orientation switch
            {
                GeneralConstants.Orientation.Up => -WeaponConstants.WeaponSpawnDistance,
                GeneralConstants.Orientation.Down => WeaponConstants.WeaponSpawnDistance,
                _ => 0
            };
            return yOffset;
        }
    }
}
