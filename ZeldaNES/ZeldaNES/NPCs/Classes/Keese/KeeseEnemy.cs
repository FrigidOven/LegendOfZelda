using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs.Classes.Keese;
using ZeldaNES.Physics.Hitboxes;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;

namespace ZeldaNES.NPCs.Classes.Keese.States;

public class KeeseEnemy : INPC
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

    private IKeeseStates state;

    private int curState;
    private int durationUntilNextState;
    private int maxDuration = 5;

    private Random rnd = new Random();
    private int damageTimer;

    public KeeseEnemy()
    {
        body = new EnemyPhysicsObject(300, 300, EnemyConstants.KeeseHealth);

        curState = 0;

        curState = rnd.Next(0,8);
        curState = 0;
        chooseNextState(curState);
        durationUntilNextState = rnd.Next()%maxDuration;
    }
    public KeeseEnemy(int posx, int posy)
    {
        body = new EnemyPhysicsObject(posx, posy, EnemyConstants.KeeseHealth);

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
    public IKeeseStates GetState() {
        return state;
    }
    public void SetState (IKeeseStates state) {
        this.state = state;
    }
    private void chooseNextState(int nextState) {
        switch (nextState)
        {
            case 0:
                {
                    state = new KeeseNotFlyingState(this);
                    break;
                }
            case 1:
                {
                    state = new KeeseFlyingUpState(this);
                    break;
                }
            case 2:
                {
                    state = new KeeseFlyingUpAndRightState(this);
                    break;
                }
            case 3:
                {
                    state = new KeeseFlyingUpAndLeftState(this);
                    break;
                }
            case 4:
                {
                    state = new KeeseFlyingLeftState(this);


                    break;
                }
            case 5:
                {
                    state = new KeeseFlyingRightState(this);

                    break;
                }
            case 6:
                {
                    state = new KeeseFlyingDownState(this);

                    break;
                }
            case 7:
                {
                    state = new KeeseFlyingDownAndRightState(this);

                    break;
                }
            case 8:
                {
                    state = new KeeseFlyingDownAndLeftState(this);

                    break;
                }
        }

    }
    public void Update()
    {
        state.Update();

        if (durationUntilNextState == 0) {
            durationUntilNextState = 40;
            curState = rnd.Next() % 9;
            chooseNextState(curState);
        }
        durationUntilNextState--;
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
        //
    }

    public void AIMovement(ILink link)
    {
        Vector2 direction = new Vector2(link.Body().PosX - body.PosX, link.Body().PosY - body.PosY);
        direction = Vector2.Normalize(direction);
        body.PosX += (int)(direction.X * EnemyConstants.ChasingSpeed);
        body.PosY += (int)(direction.Y * EnemyConstants.ChasingSpeed);
    }

    public void freeze()
    {
        state = new KeeseNotFlyingState(this);
    }

    public void unfreeze()
    {
        durationUntilNextState = 0;
    }
}
