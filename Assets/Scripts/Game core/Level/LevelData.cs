using System;
using UnityEngine;

namespace Level
{
    [Serializable]
    public class LevelData
    {
        public string levelTitle;
    
        public string adviceTitle;
    
        [TextArea]
        public string adviceDescription;
    }
}
