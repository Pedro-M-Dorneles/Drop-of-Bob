using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ContadorFinal : MonoBehaviour
{
    public float segundos = 0f;
    public int metros = 0;
    public TMP_Text contadorMetros;
    public int recordeMetros = 0;
    public TMP_Text recordeContadorMetros;
    public Restart restart;

    void Start()
    {
        restart = GetComponent<Restart>();
        
        recordeMetros = PlayerPrefs.GetInt("RecordeMetros", 0);
        recordeContadorMetros.text = "Recorde: " + recordeMetros + "m";
    }
    void Update()
    {
        segundos += Time.deltaTime;
        metros = Mathf.FloorToInt(segundos * 10);
        contadorMetros.text = "Metros: " + metros + "m";

        if (restart.gameOver == true) 
        {
            PararContador();
        }

    }

    public void PararContador()
    {
        contadorMetros.text = "Metros: " + metros + "m";
        SalvarRecorde();
    }

    public void SalvarRecorde()
    {
        if (restart.gameOver == true && metros > recordeMetros)
        {
            recordeMetros = metros;
            PlayerPrefs.SetInt("RecordeMetros", recordeMetros);
            PlayerPrefs.Save();

            recordeContadorMetros.text = "Recorde: " + recordeMetros + "m";
        }
    }
}






