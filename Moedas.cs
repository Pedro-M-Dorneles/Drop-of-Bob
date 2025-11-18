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
        pontuacaoTotalMoedas.text = "Moedas: " + moedas;

    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moedas++;
            PontuacaoMoedas();
            contadorMoedas.text = "Moedas: " + moedas;
            Destroy(gameObject);            
        }
    }

    public void PontuacaoMoedas()
    {
        pontuacaoMoedas = moedas;
        PlayerPrefs.SetInt("PontuacaoMoedas", pontuacaoMoedas);
        PlayerPrefs.Save();

    }
}
