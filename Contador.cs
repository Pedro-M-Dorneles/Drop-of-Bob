using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public float segundos = 0f;
    public int metros = 0;
    public TMP_Text contadorSegundos;
    public TMP_Text contadorMetros;
    public float recordeSegundos = 0f;
    public int recordeMetros = 0;
    public TMP_Text recordeContadorSegundos;
    public TMP_Text recordeContadorMetros;
    void Start()
    {
        recordeMetros = PlayerPrefs.GetInt("RecordeMetros", 0);
        recordeContadorMetros.text = "Recorde: " + recordeMetros + "m";

        recordeSegundos = PlayerPrefs.GetInt("RecordeSegundos", 0f);
        recordeContadorSegundos.text = "Recorde: " + recordeSegundos + "s";
    }
    void Update()
    {
        segundos += Time.deltaTime;
        metros = Mathf.FloorToInt(segundos * 10);

        contadorSegundos.text = "Tempo: " + segundos.ToString("F1") + "s";
        contadorMetros.text = "Metros: " + metros + "m";

    }

    public void ReiniciarContador()
    {
        segundos = 0f;
        metros = 0;
        contadorSegundos.text = "Tempo: 0.0s";
        contadorMetros.text = "Metros: 0m";
    }

    public void SalvarRecorde()
    {
        if (metros > recordeMetros)
        {
            recordeMetros = metros;
            PlayerPrefs.SetInt("RecordeMetros", recordeMetros);
            PlayerPrefs.Save();

            recordeContadorMetros.text = "Recorde: " + recordeMetros + "m";
        }

        if (segundos > recordeSegundos)
        {
            recordeSegundos = segundos;
            PlayerPrefs.SetInt("RecordeSegundos", recordeSegundos);
            PlayerPrefs.Save();

            recordeContadorSegundos.text = "Recorde: " + recordeSegundos + "s";
        }
    }
}
