using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using ZeldaNES.Commands;
using ZeldaNES.Commands.Classes.GameCommands;
using ZeldaNES.Commands.Classes.Link_Commands;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;
using ZeldaNES.Screens;
using ZeldaNES.CheatCode;
using System.Diagnostics;
using System;

namespace ZeldaNES.Controllers.Classes
{
    public class KeyboardController : IController
    {
        //private ILink link; why define a link here?
        private Dictionary<Keys, ICommand> commands;
        private List<ICommand> defaultCommands;
       
        private List<Keys> pressedKeys;
        
        private HashSet<Keys> nonHoldableKeys;
        private HashSet<Keys> keysToIgnore;

        private ICheatcode CheatCodeDector = new Cheatcode();
        public KeyboardController(IRegion region)
        {

            this.commands = new Dictionary<Keys, ICommand>();
            this.defaultCommands = new List<ICommand>();

            commands.Add(Keys.W, new LinkWalkUpCommand(region));
            commands.Add(Keys.A, new LinkWalkLeftCommand(region));
            commands.Add(Keys.S, new LinkWalkDownCommand(region));
            commands.Add(Keys.D, new LinkWalkRightCommand(region));

            commands.Add(Keys.Up, new LinkWalkUpCommand(region));
            commands.Add(Keys.Left, new LinkWalkLeftCommand(region));
            commands.Add(Keys.Down, new LinkWalkDownCommand(region));
            commands.Add(Keys.Right, new LinkWalkRightCommand(region));

            commands.Add(Keys.N, new LinkSwingSwordCommand(region));
            commands.Add(Keys.Z, new LinkSwingSwordCommand(region));
            commands.Add(Keys.D1, new LinkUseWoodenArrowCommand(region));
            commands.Add(Keys.D2, new LinkUseMetalArrowCommand(region));
            commands.Add(Keys.D3, new LinkUseWoodenBoomerangCommand(region));
            commands.Add(Keys.D4, new LinkUseMetalBoomerangCommand(region));
            commands.Add(Keys.D5, new LinkUseBombCommand(region));
            commands.Add(Keys.D6, new LinkUseFireCommand(region));
            commands.Add(Keys.X, new LinkUseDashCommand(region));

            commands.Add(Keys.D7, new LinkUseClockCommand(region));


            commands.Add(Keys.Q, new GameQuitCommand(region));
            commands.Add(Keys.R, new GameResetCommand(region));
            commands.Add(Keys.P, new GameSaveCommand(region));
            commands.Add(Keys.M, new OpenPauseMenuCommand(region));

            commands.Add(Keys.F1, new GameEditModeCommand(region));

            commands.Add(Keys.I, new PreviousArea(region));
            commands.Add(Keys.O, new NextArea(region));
            

            commands.Add(Keys.F2, new PreviousSprint2(region));
            commands.Add(Keys.F3, new NextSprint2(region));


            commands.Add(Keys.F4, new Previous(region));
            commands.Add(Keys.F5, new Next(region));

            commands.Add(Keys.F11, new DecrementDoorDrawIndex(region));
            commands.Add(Keys.F12, new IncrementDoorDrawIndex(region));

            commands.Add(Keys.G, new RemoveArea(region));
            commands.Add(Keys.H, new AddArea(region));

            commands.Add(Keys.U, new Undo(region));

            commands.Add(Keys.C, new EnemyAICommand(region));
            //cheatcode only
            commands.Add(Keys.None, new CheatCommand(region));
            commands.Add(Keys.L, new CheatDonothing(region));
            commands.Add(Keys.Y, new CheatDonothing(region));
            commands.Add(Keys.E, new CheatDonothing(region));

            // enter key to make the start screen disappear
            commands.Add(Keys.Enter, new StartMenuCommand(region));

            nonHoldableKeys = new HashSet<Keys> { Keys.M, Keys.N, Keys.Z, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.E, Keys.I, Keys.T, Keys.U, Keys.Y, Keys.O, Keys.P, Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F11, Keys.F12, Keys.H,Keys.G, Keys.O};

            defaultCommands.Add(new LinkStopCommand(region));

            pressedKeys = new List<Keys>();
            keysToIgnore = new HashSet<Keys>();
        }
        public void Update()
        {
            HashSet<Keys> newKeysToIgnore = new HashSet<Keys>();
            foreach (Keys key in keysToIgnore)
            {
                if (Keyboard.GetState().IsKeyDown(key))
                {
                    newKeysToIgnore.Add(key);
                }
            }
            keysToIgnore = newKeysToIgnore;
                        
            UpdatePressedKeys();
            Cheat();
            if(pressedKeys.Count == 0)
            {
                foreach (ICommand command in defaultCommands)
                {
                    command.Execute();
                }
                return;
            }

            Keys keyToExecute = pressedKeys[pressedKeys.Count - 1];
            commands[keyToExecute].Execute();

            if(nonHoldableKeys.Contains(keyToExecute))
            {
                keysToIgnore.Add(keyToExecute);
            } 
        }
        private void UpdatePressedKeys()
        {
            foreach (KeyValuePair<Keys, ICommand> command in commands)
            {
                if (Keyboard.GetState().IsKeyDown(command.Key) && !pressedKeys.Contains(command.Key))
                {
                    pressedKeys.Add(command.Key);
                    foreach (Keys key in pressedKeys)
                    {
                        if (!keysToIgnore.Contains(key))
                        {
                            CheatCodeDector.Add(key.ToString());
                        }
                    }
                }
                else if (!Keyboard.GetState().IsKeyDown(command.Key) && pressedKeys.Contains(command.Key))
                {
                    pressedKeys.Remove(command.Key);
                }
            }

            foreach (Keys key in keysToIgnore)
            {
                pressedKeys.Remove(key);
            }
        }
        private void Cheat()
        {

            if (CheatCodeDector.CheatDetected() != 0)
            {
                if (this.commands[Keys.None] is CheatCommand cheatcommand) 
                {
                    cheatcommand.Execute(CheatCodeDector.CheatDetected());
                    CheatCodeDector.resetCheat();
                }
            }
        }
    }
}
