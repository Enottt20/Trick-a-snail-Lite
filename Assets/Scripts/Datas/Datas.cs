using UnityEngine;
using UnityEngine.SceneManagement;

namespace Datas
{
    public static class Datas
    {
        public const int SkipLevelPrice = 2;
        public const int AdvicePrice = 1;

        public const string BrainValueName = "Brain";
        public const string RemoveAdsValueName = "RemoveAds";
        public const string MaxLevelValueName = "MaxLevel";
        public const string SoundValueName = "Sound";
        public const string MusicValueName = "Music";
        public const string VibrationValueName = "Vibration";

        public static int Brain
        {
            get => PlayerPrefs.GetInt(BrainValueName);

            set => PlayerPrefs.SetInt(BrainValueName, value);
        }

        public static int MaxLevel
        {
            get
            {
                //Debug.Log(PlayerPrefs.GetInt(MaxLevelValueName));
                return PlayerPrefs.GetInt(MaxLevelValueName);
            }

            set
            {
                if (value <= SceneManager.sceneCountInBuildSettings-1) PlayerPrefs.SetInt(MaxLevelValueName, value);
                //Debug.Log(PlayerPrefs.GetInt(MaxLevelValueName));
            }
        }

        public static bool RemoveAds
        {
            get
            {
                if (PlayerPrefs.GetInt(RemoveAdsValueName) == 1) return true;
                
                return false;
            }
        
            set
            {
                if (value == true)
                {
                    PlayerPrefs.SetInt(RemoveAdsValueName, 1);
                }
                else
                {
                    PlayerPrefs.SetInt(RemoveAdsValueName, 0);
                }
            }
        }

        public static bool Sound
        {
            get
            {
                if (PlayerPrefs.GetInt(SoundValueName, 1) == 1) return true;

                return false;
            }
        
            set
            {
                if (value == true)
                {
                    PlayerPrefs.SetInt(SoundValueName, 1);
                }
                else
                {
                    PlayerPrefs.SetInt(SoundValueName, 0);
                }
            }
        }

        public static bool Music
        {
            get
            {
                if (PlayerPrefs.GetInt(MusicValueName, 1) == 1) return true;

                return false;
            }
        
            set
            {
                if (value == true)
                {
                    PlayerPrefs.SetInt(MusicValueName, 1);
                }
                else
                {
                    PlayerPrefs.SetInt(MusicValueName, 0);
                }
            }
        }

        public static bool Vibration
        {
            get
            {
                if (PlayerPrefs.GetInt(VibrationValueName, 1) == 1) return true;

                return false;
            }
        
            set
            {
                if (value == true)
                {
                    PlayerPrefs.SetInt(VibrationValueName, 1);
                }
                else
                {
                    PlayerPrefs.SetInt(VibrationValueName, 0);
                }
            }
        }
        
    }
}
