using TMPro;
using UnityEngine;

public class Moedas : MonoBehaviour
{
    public int moedas = 0;
    public TMP_Text contadorMoedas;
    public int pontuacaoMoedas = 0;
    public TMP_Text pontuacaoTotalMoedas;

    void Start()
    {
        pontuacaoMoedas = PlayerPrefs.GetInt("PontuacaoMoedas", 0);
        pontuacaoTotalMoedas.text = "Moedas: " + pontuacaoMoedas;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            moedas++;
            PontuacaoMoedas();
        }
    }

    public void PontuacaoMoedas()
    {
        if (moedas > pontuacaoMoedas)
        {
            pontuacaoMoedas = moedas;
            PlayerPrefs.SetInt("PontuacaoMoedas", moedas);
            PlayerPrefs.Save();
        }
    }
}

