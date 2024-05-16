using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Regions;

namespace ZeldaNES.Achievement
{
    internal interface IAchievement
    {
        void UpdateStatus();

        
        bool IsComplete { get; set; }

        string completionMessage { get; set; }

        
    }
}
