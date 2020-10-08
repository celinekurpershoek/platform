using System.Linq;
using Cysharp.Threading.Tasks;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class LevelManager
    {
        private Level currentLevel;

        private LevelConfig levelsConfiguration;

        public void Init()
        {
            levelsConfiguration = ScriptableObjectHelper.FindScriptableObject<LevelConfig>();
            Debug.Log(levelsConfiguration);
        }

        public async UniTaskVoid LoadFirstLevel()
        {
            await SceneManager.UnloadSceneAsync("MainMenu");
            LoadLevel(levelsConfiguration.levels.FirstOrDefault()).Forget();
        }

        private async UniTaskVoid LoadLevel(Level level)
        {
            if (currentLevel != null)
            {
                await SceneManager.UnloadSceneAsync(currentLevel.name);
            }
            SceneManager.LoadScene(level.name, LoadSceneMode.Additive);
            currentLevel = level;
        }

        private void LoadNextLevel()
        {
            Level level = levelsConfiguration.levels.SkipWhile(x => x != currentLevel).Skip(1).FirstOrDefault();
            if (level != null)
            {
                LoadLevel(level).Forget();
            }
        }

        public void ReloadCurrentLevel()
        {
            LoadLevel(currentLevel).Forget();
        }

        public void LevelCompleted()
        {
            AudioManager.Instance.Play("OpenChest");
            LoadNextLevel();
            LevelUIManager.Instance.ShowLevelCompletedMenu();
            Debug.Log("Gewonnen!");
        }
    }
}
