using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ZeldaNES.SoundManager;


using ZeldaNES.Inventories;

namespace ZeldaNES.CheatCode
{
    public class Cheatcode : ICheatcode
    {
        private List<string> inputdetected;
        private List<string> cheatcode1;
        private List<string> cheatcode2;
        private List<string> cheatcode3;
        private List<string> cheatcode4;
        private int cheatdetected = 0;
        private int maxinput ;

        public Cheatcode()
        {
            this.inputdetected = new List<string>();
            //make a list if too many cheatcodes are needed
            //to add more cheatcode, first add the this.cheatcode4,5..., then add the cheatcode detect to the if, else if check, finally add its function in the cheatcommend,
            //and make the key is aviliable, if not add a key in keyboard cheatdonothing 
            this.cheatcode1 = new List<string>() { "W", "E", "A", "P", "O", "N" };
            this.cheatcode2 = new List<string>() { "S", "L", "A", "Y", "A", "L", "L" };
            this.cheatcode3 = new List<string>() { "H","E", "A", "L"};
            this.cheatcode4 = new List<string>() { "D", "A", "S", "H","Y" };
            //set maxinput to the length of the longest cheatcode if there is a list
            this.maxinput = cheatcode2.Count;
        }
        public void Add(string str)
        {
            this.inputdetected.Add(str);
            if (inputdetected.Count > maxinput)
            {
                shift(inputdetected);
            }

            if (ContainsSubList(inputdetected, cheatcode1))
            {
                cheatdetected = 1;
                SoundManager.SoundManager.Instance.Secret.Play();
            }else if (ContainsSubList(inputdetected,cheatcode2))
            {
                cheatdetected = 2;
                SoundManager.SoundManager.Instance.Secret.Play();
            }
            else if (ContainsSubList(inputdetected, cheatcode3))
            {
                cheatdetected = 3;
                SoundManager.SoundManager.Instance.Secret.Play();
            }
            else if (ContainsSubList(inputdetected, cheatcode4))
            {
                cheatdetected = 4;
                SoundManager.SoundManager.Instance.Secret.Play();
            }

        }
        public int CheatDetected()
        {
            return cheatdetected;
        }
        public void resetCheat()
        {
            inputdetected.Clear();
            this.cheatdetected = 0; 
        }
        private static void shift(List<string> inputlist)
        {
            if (inputlist.Count > 0)
            {
                inputlist.RemoveAt(0);
            }
        }
        public bool ContainsSubList<T>(List<T> longerList, List<T> shorterList)
        {

            // Check if both lists have the same length, if it does, just compare them
            if (longerList.Count == shorterList.Count)
            {
                return longerList.SequenceEqual(shorterList);
            }
            int shorterLength = shorterList.Count;
            int maxIndex = longerList.Count - shorterLength;
            // Iterate through
            for (int i = 0; i <= maxIndex; i++)
            {
                var slice = longerList.GetRange(i, shorterLength);
                if (slice.SequenceEqual(shorterList))
                {
                    return true; 
                }
            }
            return false;
        }
    }
}