using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameHasEnded = false;

    public GameObject Enemy;

    public GameObject MiniBoss;

    private void Update()
    {
        WonGame(); 
    }

    public void WonGame()
    {
        if(GameHasEnded == false)
        {
            if (!Enemy && !MiniBoss)
            {
                GameHasEnded = true;
                Invoke("Victory", 2f);
            }
        }
        
    }
    void Victory ()
    {
        SceneManager.LoadScene("VictoryScreen");
    }


    public void EndGame()
    {
        if (GameHasEnded == false)
        {
            GameHasEnded = true;
            Invoke("Restart", 2f);
        }
        
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
