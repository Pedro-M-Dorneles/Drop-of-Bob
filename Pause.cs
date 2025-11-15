using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Pause : MonoBehaviour
{
    public string nomeDoMenu;
    public GameObject painelPausar;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            Pausar();
        }
    }

    public void Pausar()
    {
        painelPausar.SetActive(true);
        Time.timeScale = 0f;

    }

    public void ContinuarJogando()
    {
        painelPausar.SetActive(false);
        Time.timeScale = 1.3f;
    }

    public void AbrirMenu()
    {
        SceneManager.LoadScene(nomeDoMenu);
    }
}
