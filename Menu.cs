using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string nomeDoJogo;
    [SerializeField] private string nomeDoMenu;
    [SerializeField] private string nomeDasOpcoes;
    [SerializeField] private string nomeDosCreditos;
    [SerializeField] private GameObject ui;
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoJogo);
    }


    public void Opcoes()
    {
        SceneManager.LoadScene(nomeDasOpcoes);
    }

    public void MenuInicial()
    {
        SceneManager.LoadScene(nomeDoMenu);
    }

    public void Creditos()
    {
        SceneManager.LoadScene(nomeDosCreditos);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
