using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerScore.playerScore = 0;
            GameOver.isPlayerDead = false;
            Time.timeScale = 1;

            SceneManager.LoadScene("Scene_001");
        }
        
    }
}
