using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;

public class Restart : MonoBehaviour
{
    public bool gameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    //Codigo para gameover
    void GameOver()
    {
        if (gameOver)
        {
            gameOver = true;
            Debug.Log("Colidiu! Obstáculos pararam.");
            StartCoroutine(Restart_delay());
            return; // não move mais
        }
    }

    IEnumerator Restart_delay()
    {
        yield return new WaitForSeconds(1f);

        // Reinicia a cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOver = false;
    }
}
