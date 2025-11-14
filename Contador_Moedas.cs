using TMPro;
using UnityEngine;

public class Contador_Moedas : MonoBehaviour
{
    public TMP_Text textoPontuacao;

    void Start()
    {
        int pontuacao = PlayerPrefs.GetInt("PontuacaoMoedas", 0);
        textoPontuacao.text = "Moedas: " + pontuacao;
    }


    void Update()
    {

    }
}
