using UnityEngine;

namespace MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        public void LoadLevel(int level)
        {
            Application.LoadLevel(level);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
