using TMPro;
using UnityEngine;

public class ContadorRecorde : MonoBehaviour
{
    public TMP_Text textoRecorde;

    void Start()
    {
        int recorde = PlayerPrefs.GetInt("RecordeMetros", 0);
        textoRecorde.text = "Recorde: " + recorde + "m";
    }

    
    void Update()
    {
        
    }
}
