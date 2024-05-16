using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using ZeldaNES.Game_Constants;
using ZeldaNES.Items;

namespace ZeldaNES.SoundManager
{
    public sealed class SoundManager
    {
        private static SoundManager instance = null;
        private static readonly Object padlock = new object();

        private Song currentSong;
        private float currentSongTimeRemaining;
        private float musicTimeBank;
        private float priorGameTime;

        // Songs
        public Song underworldTheme;
        public Song gerudoValley;
        public Song triforceTheme;
        public Song ending;

        // Sound Effects
        public SoundEffect ArrowBoomerang;
        public SoundEffect BombBlowingUp;
        public SoundEffect BombDrop;
        public SoundEffect BossDamaged;
        public SoundEffect BossScream1;
        public SoundEffect BossScream2;
        public SoundEffect BossScream3;
        public SoundEffect Candle;
        public SoundEffect DoorUnlock;
        public SoundEffect EnemyDying;
        public SoundEffect EnemyDamaged;
        public SoundEffect Fanfare;
        public SoundEffect PickupHeart;
        public SoundEffect PickupItem;
        public SoundEffect PickupRupee;
        public SoundEffect KeyAppear;
        public SoundEffect LinkDying;
        public SoundEffect LinkDamaged;
        public SoundEffect LowHealthIndicator;
        public SoundEffect MagicalRod;
        public SoundEffect Recorder;
        public SoundEffect RefillLoop;
        public SoundEffect Secret;
        public SoundEffect Shield;
        public SoundEffect Shore;
        public SoundEffect Stairs;
        public SoundEffect SwordCombined;
        public SoundEffect SwordShoot;
        public SoundEffect SwordSlash;
        public SoundEffect Text;
        public SoundEffect TextSlow;
        private SoundManager(ContentManager Content)
        {
            underworldTheme = Content.Load<Song>(GeneralConstants.underworldTheme);
            gerudoValley = Content.Load<Song>(GeneralConstants.gerudoValley);
            triforceTheme = Content.Load<Song>(GeneralConstants.triforceTheme);
            ending = Content.Load<Song>(GeneralConstants.ending);

            currentSongTimeRemaining = 0;
            musicTimeBank = 0;

            ArrowBoomerang = Content.Load<SoundEffect>(GeneralConstants.arrowBoomerang);
            BombBlowingUp = Content.Load<SoundEffect>(GeneralConstants.bombBlow);
            BombDrop = Content.Load<SoundEffect>(GeneralConstants.bombDrop);
            BossDamaged = Content.Load<SoundEffect>(GeneralConstants.bossDamage);
            Candle = Content.Load<SoundEffect>(GeneralConstants.candle);
            DoorUnlock = Content.Load<SoundEffect>(GeneralConstants.doorUnlock);
            EnemyDying = Content.Load<SoundEffect>(GeneralConstants.enemyDying);
            EnemyDamaged = Content.Load<SoundEffect>(GeneralConstants.enemyDamage);
            Fanfare = Content.Load<SoundEffect>(GeneralConstants.fanfare);
            PickupHeart = Content.Load<SoundEffect>(GeneralConstants.getHeart);
            PickupItem = Content.Load<SoundEffect>(GeneralConstants.getItem);
            PickupRupee = Content.Load<SoundEffect>(GeneralConstants.getRupee);
            LinkDamaged = Content.Load<SoundEffect>(GeneralConstants.linkDamage);
            LowHealthIndicator = Content.Load<SoundEffect>(GeneralConstants.lowHealth);
            MagicalRod = Content.Load<SoundEffect>(GeneralConstants.magicalRod);
            Recorder = Content.Load<SoundEffect>(GeneralConstants.recorder);
            Secret = Content.Load<SoundEffect>(GeneralConstants.secret);
            Shield = Content.Load<SoundEffect>(GeneralConstants.shield);
            Stairs = Content.Load<SoundEffect>(GeneralConstants.stairs);
            SwordCombined = Content.Load<SoundEffect>(GeneralConstants.swordCombined);
            SwordShoot = Content.Load<SoundEffect>(GeneralConstants.swordShoot);
            SwordSlash = Content.Load<SoundEffect>(GeneralConstants.swordSlash);
        }
        public static SoundManager Instance
        {
            get
            {
                return instance;

            }
        }

        public static SoundManager GenInstance(ContentManager Content)
        {

            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new SoundManager(Content);
                }
                return instance;
            }

        }
        public void PlayItemPickupSound(IItem item)
        {
            if (item is IMonetaryItem)
            {
                SoundManager.Instance.PickupRupee.CreateInstance().Play();
            }
            else if (item is IHealingItem)
            {
                SoundManager.Instance.PickupHeart.CreateInstance().Play();
            }
            else if(item is IPassiveItem || item is IEquippableItem || item is IUpgradeItem)
            {
                SoundManager.Instance.Fanfare.CreateInstance().Play();
            }
            else
            {
                SoundManager.Instance.PickupItem.CreateInstance().Play();
            }
        }

        public void PlayVictoryMusic()
        {
            if(!currentSong.Equals(triforceTheme) && !currentSong.Equals(ending))
            {
                MediaPlayer.IsRepeating = false;
                currentSongTimeRemaining = 0;
                currentSong = triforceTheme;
                MediaPlayer.Play(currentSong);
            }
            else if (currentSong.Equals(triforceTheme) && currentSongTimeRemaining <= 0)
            {
                MediaPlayer.IsRepeating = true;
                currentSong = ending;
                MediaPlayer.Play(currentSong);
            }
            
        }

        public void PlayDungeonMusic()
        {
            if (currentSong == null || !currentSong.Equals(gerudoValley))
            {
                currentSong = gerudoValley;
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(currentSong);
            }
        }

        public void PlayStartScreenMusic()
        {
            if (currentSong == null || !currentSong.Equals(underworldTheme))
            {
                currentSong = underworldTheme;
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(currentSong);
            }
        }

        public void Update(GameTime gameTime)
        {  
            if (GameStates.GameState.Instance.StartMenuMode)
            {
                PlayStartScreenMusic();
            } 
            else if (GameStates.GameState.Instance.WinMode)
            {
                PlayVictoryMusic();
            }
            else
            {
                PlayDungeonMusic();
            }

            if (currentSongTimeRemaining <= 0)
            {
                currentSongTimeRemaining = currentSong.Duration.Seconds;
            }

            currentSongTimeRemaining -= ((float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
