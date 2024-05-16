using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using ZeldaNES.Cameras;
using ZeldaNES.Commands;
using ZeldaNES.Game_Constants;
using ZeldaNES.GameStates;
using ZeldaNES.Regions;

namespace ZeldaNES.Controllers.Classes
{
    public class MouseController : IController
    {
        private IRegion region;
        private ICommand commandLeftClick;
        private ICommand commandRightClick;
        private long scrollValueOffset;
        private bool wasPressed = false;
        public MouseController(IRegion region)
        {
            this.region = region;
            scrollValueOffset = 0;
            //commandLeftClick = new GenericCommand();
            //commandRightClick =  new GenericCommand();
        }
        public void Update()
        {
            if (GameState.Instance.EditorMode) {
                region.GetRegionEditor().GetRegionElementMultiplexor().SetPosX(Mouse.GetState().X);
                region.GetRegionEditor().GetRegionElementMultiplexor().SetPosY(Mouse.GetState().Y - GeneralConstants.UIBarHeight);
                int indicatorXW = region.ScaleToWorldCoordsX(Mouse.GetState().X);
                int indicatorYW = region.ScaleToWorldCoordsY(Mouse.GetState().Y - GeneralConstants.UIBarHeight);
                int indicatorXS = region.ScaleToScreenCoordsX(indicatorXW);
                int indicatorYS = region.ScaleToScreenCoordsY(indicatorYW);

                region.GetRegionEditor().GetRegionElementMultiplexor().UpdateIndicator(indicatorXS, indicatorYS);

            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed) { 
                wasPressed = true;
            }
                if (Mouse.GetState().LeftButton == ButtonState.Released && wasPressed)
            {
                if (GameState.Instance.EditorMode) {
                    region.GetRegionEditor().AddRegionElementMultiplexor();
                }
                wasPressed = false;

                //commandLeftClick.Execute();
            }
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                //commandRightClick.Execute();
            }

            // zoom in with scroll wheel
            PlayerCamera.Instance.Scale = 1f + 0.001f * (Mouse.GetState().ScrollWheelValue - scrollValueOffset);

            // reset zoom on middle click
            if(Mouse.GetState().MiddleButton == ButtonState.Pressed)
            {
                scrollValueOffset = Mouse.GetState().ScrollWheelValue;
            }
        }
    }
}
