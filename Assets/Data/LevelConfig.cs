using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName ="config/LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        public List<Level> levels;
    }
}
