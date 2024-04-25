using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    private TMP_Text score_txt;
    private void Awake()
    {
        score_txt = GetComponent<TMP_Text>();
    }

    // Actualizar valor en pantalla
    public void UpdateScore(int score)
    {
        score_txt.text = "Peces comidos: " + score.ToString();
    }
}
