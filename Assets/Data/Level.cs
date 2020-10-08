using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Data
{
    [CreateAssetMenuAttribute(fileName = "Level", menuName ="config/Level", order = 0)]
    public class Level : ScriptableObject
    {
        [SerializeField] private string sceneName;
        
        [Space]
        [SerializeField] private int startingLives;
    }
}
