using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string nomeDoJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelCreditos;
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoJogo);
    }


    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void AbrirCreditos()
    {
        painelMenuInicial.SetActive(false);
        painelCreditos.SetActive(true);
    }

    public void FecharCreditos()
    {
        painelMenuInicial.SetActive(true);
        painelCreditos.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
