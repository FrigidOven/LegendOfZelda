using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Cameras;
using ZeldaNES.Doors1;
using ZeldaNES.Doors1.HiddenDoor;
using ZeldaNES.Doors1.LockedDoor;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;
using ZeldaNES.Tiles;

namespace ZeldaNES.Physics.PhysicsHandlers.SubHandlers
{
    public static class PlayerDoorPhysicsHandler
    {
        public static void HandlePhysics(List<ILink> players, List<IDoor> doors, IRegion region)
        {
            foreach (var player in players)
            {
                foreach (var door in doors)
                {
                    if (IsTouching(player.Body(), door.Body()))
                    {

                        if(TryUseDoor(player, door, region))
                        {
                            region.NextAreaIndex = door.GetIndex();
                            region.NextDirection = door.GetCardinalPosition();
                            (int, int) coordinates = NewPlayerPosition(door.GetCardinalPosition());

                            // since we may have multiplayer
                            foreach (ILink link in players)
                            {
                                player.Body().PosX = coordinates.Item1;
                                player.Body().PosY = coordinates.Item2;
                            }

                            TransitionScreen(door.GetCardinalPosition());
                        }    
                        else
                        {
                            AdjustPlayerPosition(player.Body(), door.Body());
                        }
                    }
                }
            }
        }
        private static bool TryUseDoor(ILink player, IDoor door, IRegion region)
        {
            if(door.Body().Hitbox.IsActive)
            {
                return true;
            }
            if(door is LockedDoor)
            {
                if(player.GetInventory().Keys > 0)
                {
                    player.GetInventory().Keys--;
                    door.Open();
                    SoundManager.SoundManager.Instance.DoorUnlock.CreateInstance().Play();
                    OpenCorrespondingDoor(door, region);
                    return true;
                }
            }
            return false;
        }
        private static void OpenCorrespondingDoor(IDoor door, IRegion region)
        {
            // get the doors of the next area
            List<IDoor> doors = region.Areas[door.Index].Doors;

            for (int i = 0; i < doors.Count; i++)
            {
                if (doors[i].Index == region.AreaIndex)
                {
                    doors[i].Open();
                    // break since there is only one door that links to the current door
                    break;
                }
            }
        }
        private static (int, int) NewPlayerPosition(GeneralConstants.CardinalDirection doorOrientation)
        {
            // magic numbers for now to get it to not teleport you back and forth constantly
            (int, int) coordinates = doorOrientation switch
            {
                GeneralConstants.CardinalDirection.North => (GeneralConstants.SouthDoorPosition.Item1, GeneralConstants.SouthDoorPosition.Item2 - 24 * GeneralConstants.ImageScale),
                GeneralConstants.CardinalDirection.South => (GeneralConstants.NorthDoorPosition.Item1, GeneralConstants.NorthDoorPosition.Item2 + 24 * GeneralConstants.ImageScale),
                GeneralConstants.CardinalDirection.East => (GeneralConstants.WestDoorPosition.Item1 + 24 * GeneralConstants.ImageScale, GeneralConstants.WestDoorPosition.Item2),
                // west
                _ => (GeneralConstants.EastDoorPosition.Item1 - 24 * GeneralConstants.ImageScale, GeneralConstants.EastDoorPosition.Item2),
            };
            return coordinates;
        }
        private static void TransitionScreen(GeneralConstants.CardinalDirection direction)
        {
            switch (direction)
            {
                case GeneralConstants.CardinalDirection.North:
                {
                        PlayerCamera.Instance.PanUp();
                        break;
                }
                case GeneralConstants.CardinalDirection.South:
                {
                        PlayerCamera.Instance.PanDown();
                        break;
                }
                case GeneralConstants.CardinalDirection.East:
                {
                        PlayerCamera.Instance.PanRight();
                        break;
                }
                case GeneralConstants.CardinalDirection.West:
                {
                        PlayerCamera.Instance.PanLeft();
                        break;
                }
            }
        }
        private static void AdjustPlayerPosition(IPlayerPhysicsObject player, IDoorPhysicsObject door)
        {
            GeneralConstants.Orientation side = player.PlayerHitbox.Side(door.Hitbox);
            switch (side)
            {
                case GeneralConstants.Orientation.Up:
                    {
                        player.PosY = door.Hitbox.PosY - (door.Hitbox.Height + player.PlayerHitbox.Height) / 2 - player.PlayerHitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Down:
                    {
                        player.PosY = door.Hitbox.PosY + (door.Hitbox.Height + player.PlayerHitbox.Height) / 2 - player.PlayerHitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Left:
                    {
                        player.PosX = door.Hitbox.PosX - (door.Hitbox.Width + player.PlayerHitbox.Width) / 2 - player.PlayerHitbox.OffsetX;
                        return;
                    }
                default:
                    {
                        player.PosX = door.Hitbox.PosX + (door.Hitbox.Width + player.PlayerHitbox.Width) / 2 - player.PlayerHitbox.OffsetX;
                        return;
                    }
            }
        }
        private static bool IsTouching(IPlayerPhysicsObject player, IDoorPhysicsObject door)
        {
            return player.PlayerHitbox.Intersects(door.Hitbox);
        }
    }
}
