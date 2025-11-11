using TMPro;
using UnityEngine;


public class ContadorFinal : MonoBehaviour
{
    public float segundos = 0f;
    public float profundidade = 0f;
    public int metros = 0;
    public TMP_Text contadorMetros;
    public int recordeMetros = 0;
    public TMP_Text recordeContadorMetros;
    public Restart restart;

    void Start()
    {   
        recordeMetros = PlayerPrefs.GetInt("RecordeMetros", 0);
        recordeContadorMetros.text = "Recorde: " + recordeMetros + "m";
    }
    void Update()
    {
        if (restart != null && restart.gameOver == false)
        {
            segundos += Time.deltaTime;
            metros = Mathf.FloorToInt(profundidade);
            contadorMetros.text = "Metros: " + metros + "m";
        }

        if (restart != null && restart.gameOver == true) 
        {
            SalvarRecorde();  
            return;
        }

    }

    public void SalvarRecorde()
    {
        if (metros > recordeMetros)
        {
            recordeMetros = metros;
            PlayerPrefs.SetInt("RecordeMetros", recordeMetros);
            PlayerPrefs.Save();
        }
    }
}










