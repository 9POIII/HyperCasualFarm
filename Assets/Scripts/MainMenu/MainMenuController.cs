using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        private void Start()
        {
            Application.targetFrameRate = Screen.currentResolution.refreshRate < 120 ? 60 : 120;
        }

        public void LoadLevel(int level)
        {
            SceneManager.LoadScene(level);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(1);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
