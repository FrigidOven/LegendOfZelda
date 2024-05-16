using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ZeldaNES.Controllers;
using ZeldaNES.Players.Link;
using ZeldaNES.Players.Link.Classes.States;
using ZeldaNES.Weapons;
using ZeldaNES.Tiles;
using ZeldaNES.Items;
using ZeldaNES.NPCs;
using ZeldaNES.Regions;
using ZeldaNES.Doors1;
using System.Net;
using ZeldaNES.TextureManager;
using ZeldaNES.Factories;
using ZeldaNES.Physics;
using ZeldaNES.Achievement;
using ZeldaNES.NPCs.Classes.OldMan;
using ZeldaNES.Items.Classes;
using ZeldaNES.Weapons.Classes.Bomb;
using ZeldaNES.Weapons.Classes.Clock;
using Microsoft.Xna.Framework.Media;


namespace ZeldaNES.Screens.Classes
{
    public class Area
    {
        public Region region { get; set; }  

        private List<ILink> players;
        private List<IWeapon> friendlyWeapons;
        private List<IWeapon> hostileWeapons;
        public List<IItem> Items { get; set; }
        public List<INPC> Enemies { get; set; } 
        public List<ITile> Tiles { get; set; }
        public List<ITile> BoundryTiles { get; set; }
        public List<IDoor> Doors { get; set; }

        private ItemFactory itemFactory;

        public bool frozen;
        public bool unfreeze;
        public int clockCount;

        public Area() {
            Items = new List<IItem>();
            BoundryTiles = new List<ITile>();
            Enemies = new List<INPC>();
            Tiles = new List<ITile>();
            Doors = new List<IDoor>();
            players = new List<ILink>();
            friendlyWeapons = new List<IWeapon>();
            hostileWeapons = new List<IWeapon>();

            frozen = false;
            unfreeze = true;
            clockCount = 0;

            //itemFactory = new ItemFactory(); //TODO:????????
        }
        public Area(IRegion region)
        {
            Items = new List<IItem>();
            Enemies = new List<INPC>();
            BoundryTiles = new List<ITile>();
            Tiles = new List<ITile>();
            Doors = new List<IDoor>();
            players = new List<ILink>();
            friendlyWeapons = new List<IWeapon>();
            hostileWeapons = new List<IWeapon>();
            this.region =(Region)region;

            //itemFactory = ItemFactory.GenInstance();



            frozen = false;
            unfreeze = true;
            clockCount = 0;

        }
        public void Initialize()
        {

        }

        public void Update()

        {
            foreach (ILink player in players)
            {
                player.Update();
                if (player.Health == 0)
                {
                    player.Death();
                    GameStates.GameState.Instance.deathMode = true;
                }
                /*if (player.TimeFreeze() && unfreeze) {
                    frozen = true;
                    unfreeze = false;

                    SoundManager.SoundManager.Instance.Secret.Play();
                }
                if (player.UnFreeze()) {
                    unfreeze = true;

                    SoundManager.SoundManager.Instance.Secret.Play();
                }*/
            }


            foreach (IWeapon weapon in friendlyWeapons)
            {
                
                if (weapon is Clock && !weapon.ShouldDelete) {
                    clockCount++;
                }

                if (!frozen)
                {
                    weapon.Update();
                }
                else {
                    if (weapon is Bomb)
                    {
                        Bomb b = (Bomb)weapon;
                        if (!b.IsFriendly())
                        {
                            //weapon.Update();
                        }
                        else
                        {
                            weapon.Update();
                        }
                    }
                    else {
                        weapon.Update();
                    }
                }

                
            }

            if (clockCount > 0)
            {
                frozen = true;
                clockCount = 0;
            }
            else { 
                frozen = false;
            }


            foreach (IWeapon weapon in hostileWeapons)
            {
                if (!frozen)
                {
                    weapon.Update();
                }
                else {
                    if (weapon is Bomb)
                    {
                        Bomb b = (Bomb)weapon;
                        if (b.IsFriendly()) {
                            weapon.Update();
                        }
                    }
                }
            }
            

            foreach (INPC enemy in Enemies)
            {
                if (!frozen) {
                    enemy.Update();
                }
                /*if (frozen && !unfreeze)
                {
                    enemy.freeze();
                    //enemy.Update();
                }
                else if (frozen && unfreeze)
                {
                    //enemy.Update();
                    enemy.unfreeze();
                }
                else {
                    enemy.Update();

                }*/
            }

            foreach (ITile tile in Tiles) {
                tile.Update();
            }
            foreach (ITile tile in BoundryTiles)
            {
                tile.Update();
            }
            foreach (IDoor door in Doors)
            {
                door.Update();
            }
            foreach (IItem item in Items) {
                if (item is KeyItem)
                {
                    if (region.Areas[region.AreaIndex].Enemies.Count == 0) {
                        item.Update();
                    }
                }
                else
                {
                    item.Update();
                }
            }
            RemoveInactiveItems(Items);
            RemoveInactiveWeapons();
            RemoveInactiveEnemies(Enemies);
        }
        public void Draw()
        {
            
            foreach (ITile tile in Tiles)
            {
                tile.Draw();
            }
            foreach (IDoor door in Doors)
            {
                door.Draw();
            }
            foreach (IWeapon weapon in friendlyWeapons)
            {
                weapon.Draw();
            }
            foreach (IWeapon weapon in hostileWeapons)
            {
                weapon.Draw();
            }
            
            foreach (IItem item in Items) {
                //item.Draw();

                if (item is KeyItem)
                {
                    if (region.Areas[region.AreaIndex].Enemies.Count == 0 &&
                        region.Areas[region.NextAreaIndex].Enemies.Count == 0)
                    {
                        item.Draw();
                    }
                }
                else
                {
                    item.Draw();
                }
            }

            foreach (INPC enemy in Enemies)
            {
                enemy.Draw();
            }
        }
        public List<IWeapon> GetFriendlyWeapons() {
            return friendlyWeapons;
        }
        public List<IWeapon> GetHostileWeapons()
        {
            return hostileWeapons;
        }
        public List<IItem> GetItems()
        {
            return Items;
        }
        public void RemoveAllWeapons() {
            foreach (IWeapon weapon in hostileWeapons)
            {
                hostileWeapons.Remove(weapon);
            }
            foreach (IWeapon weapon in friendlyWeapons)
            {
                friendlyWeapons.Remove(weapon);
            }
        }
        private void RemoveInactiveWeapons()
        {
            RemoveInactiveWeapons(friendlyWeapons);
            RemoveInactiveWeapons(hostileWeapons);
        }
        private void RemoveInactiveWeapons(List<IWeapon> weapons)
        {
            List<IWeapon> weaponsToDelete=  new List<IWeapon>();
            foreach(IWeapon weapon in weapons)
            {
                if(weapon.ShouldDelete)
                {
                    weaponsToDelete.Add(weapon);
                }
            }
            foreach (IWeapon weapon in weaponsToDelete)
            {
                weapons.Remove(weapon);
            }
            weaponsToDelete.Clear();
        }
        private void RemoveInactiveItems(List<IItem> items)
        {
            List<IItem> itemsToDelete = new List<IItem>();
            foreach (IItem item in items)
            {
                if (item.ShouldDelete())
                {
                    itemsToDelete.Add(item);
                }
            }
            foreach (IItem item in itemsToDelete)
            {
                // Stat tracking
                AchievementTracker.Instance.itemsCollected++;
                if(item is TriforceItem)
                {
                    AchievementTracker.Instance.triforceCollected = true;
                    AchievementTracker.Instance.timeToCollectTriforce = GameTimer.GameTimeTracker.Instance.GetElapsedTime();
                    GameStates.GameState.Instance.WinMode = true;
                }
                if(item is BowItem)
                {
                    AchievementTracker.Instance.keyItemCollected = true;
                }
                
                items.Remove(item);
            }
        }
        private void RemoveInactiveEnemies(List<INPC> enemies)
        {
            List<INPC> enemiesToDelete = new List<INPC>();
            foreach (INPC enemy in enemies)
            {
                if (enemy.Body().Health <= 0)
                {
                    enemiesToDelete.Add(enemy);
                    enemy.dropLoot(region);
                }
            }
            foreach (INPC enemy in enemiesToDelete)
            {
                // Stat Tracking
                AchievementTracker.Instance.enemiesKilled++;
                if(enemy is OldManNPC)
                {
                    AchievementTracker.Instance.oldManKilled = true;
                }

                enemies.Remove(enemy);

                
            }
        }

        public void AddFriendlyWeapon(IWeapon weapon)
        {
            friendlyWeapons.Add(weapon);
        }
        public void AddHostileWeapon(IWeapon weapon)
        {
            hostileWeapons.Add(weapon);
        }
        public void AddItem(IItem item)
        {
            Items.Add(item);
        }
        public void AddPlayer(ILink player)
        {
            players.Add(player);
        }
        
    }
}
