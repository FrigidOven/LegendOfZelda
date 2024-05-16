using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Players.Link;
using ZeldaNES.RegionEditors;
using ZeldaNES.Screens.Classes;
using ZeldaNES.Sprint2;
using ZeldaNES.Weapons;

namespace ZeldaNES.Regions
{
    public interface IRegion
    {
        public List<Area> Areas { get; set; }
        public int AreaIndex { get; set; }
        public int NextAreaIndex { get; set; }
        public GeneralConstants.CardinalDirection NextDirection { get; set; }
        public List<ILink> players { get; set; }
        public void Save();
        public IRegionEditor GetRegionEditor();
        public void ScaleEntitiesToWorldCoords();
        public void ScaleEntitiesToScreenCoords();

        public int ScaleToScreenCoordsX( int x);
        public int ScaleToWorldCoordsY(int y);

        public int ScaleToWorldCoordsX(int x);
        public int ScaleToScreenCoordsY(int y);
        public void Initialize();

        public void PopulateReference();
        public void Previous();
        public void Next();
    }
}
