using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Factories;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs.Classes.Goriya;
using ZeldaNES.NPCs.Classes.Goriya.States;
using ZeldaNES.NPCs.Classes.Keese;
using ZeldaNES.Physics.Hitboxes;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;
using ZeldaNES.Weapons;

namespace ZeldaNES.NPCs.Classes.Keese.States;

public class GoriyaEnemy : INPC, IWeaponUser
{
    private IEnemyPhysicsObject body;
    public int PosX
    {
        get => body.PosX;
        set => body.PosX = value;
    }
    public int PosY
    {
        get => body.PosY;
        set => body.PosY = value;
    }

    private IGoriyaStates state;
    private WeaponFactory weaponfactory;
    private int curState;
    private int durationUntilNextState;
    private int maxDuration = 20;
    public bool IsFriendly { get; set; }
    private bool throwingWeapon = false;
    private Random rnd = new Random();
    private int damageTimer;

    public bool frozen = false;

    public GoriyaEnemy()
    {
        body = new EnemyPhysicsObject(300, 300, EnemyConstants.GoriyaHealth);

        IsFriendly = false;

        curState = 0;

        curState = rnd.Next(0,8);
        curState = 0;
        chooseNextState(curState);
        durationUntilNextState = rnd.Next()%maxDuration;
    }
    public void SetWeaponFactory(WeaponFactory weaponfactory) {
        this.weaponfactory = weaponfactory;
    }
    public GoriyaEnemy(int posX, int posY)
    {
        IsFriendly = false;
        body = new EnemyPhysicsObject(posX, posY, EnemyConstants.GoriyaHealth);

        curState = 0;

        curState = rnd.Next(0, 8);
        curState = 0;
        chooseNextState(curState);
        durationUntilNextState = rnd.Next() % maxDuration;
    }
    public IEnemyPhysicsObject Body()
    {
        return body;
    }
    public IGoriyaStates GetState() {
        return state;
    }
    public void SetState (IGoriyaStates state) {
        this.state = state;
    }
    private void chooseNextState(int nextState)
    {
        switch (nextState)
        {
            case 0:
                {
                    throwingWeapon = false;
                    state = new GoriyaWalkingLeftState(this);
                    break;
                }
            case 1:
                {
                    throwingWeapon = false;
                    state = new GoriyaWalkingRightState(this);
                    break;
                }
            case 2:
                {
                    throwingWeapon = false;
                    state = new GoriyaWalkingUpState(this);
                    break;
                }
            case 3:
                {
                    throwingWeapon = false;
                    state = new GoriyaWalkingDownState(this);
                    break;
                }
            case 4:
                {
                    throwingWeapon = true;
                    weaponfactory.MakeNewWoodenBoomerang(PosX, PosY, state.GetNormal(), this);
                    break;
                }
        }
    }
    public void Update()
    {
        if (!frozen) { 
            if (!throwingWeapon)
            {
                state.Update();
            }
            if (durationUntilNextState == 0)
            {
                durationUntilNextState = 40;
                curState = rnd.Next() % 5;
                chooseNextState(curState);
            }
            durationUntilNextState--;
        }   
        ManageDamage();
    }
    private void ManageDamage()
    {
        if (!body.IsTakingDamage)
        {
            return;
        }
        if (damageTimer < EnemyConstants.DamageGracePeriod)
        {
            damageTimer++;
        }
        else
        {
            damageTimer = 0;
            body.IsTakingDamage = false;
        }
    }
    public void Draw()
    {
        state.Draw();
    }

    public void dropLoot(Region region)
    {
        ItemFactory.Instance.groupBLoot(PosX, PosY, region);
    }

    public void AIMovement(ILink link)
    {
        Vector2 direction = new Vector2(link.Body().PosX - body.PosX, link.Body().PosY - body.PosY);
        direction = Vector2.Normalize(direction);
        body.PosX += (int)(direction.X * EnemyConstants.ChasingSpeed);
        body.PosY += (int)(direction.Y * EnemyConstants.ChasingSpeed);

        // Determine the state based on the direction
        if (Math.Abs(direction.X) > Math.Abs(direction.Y))
        {
            // Moving more horizontally
            if (direction.X > 0)
            {
                // Moving right
                state = new GoriyaWalkingRightState(this);
            }
            else
            {
                // Moving left
                state = new GoriyaWalkingLeftState(this);
            }
        }
        else
        {
            // Moving more vertically
            if (direction.Y > 0)
            {
                // Moving down
                state = new GoriyaWalkingDownState(this);
            }
            else
            {
                // Moving up
                state = new GoriyaWalkingUpState(this);
            }
        }
    }

    public void freeze()
    {
        frozen = true;
    }

    public void unfreeze()
    {
        frozen = false;
    }
}
