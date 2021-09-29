using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    private string keyToSave = "KeyHighscore";

    [Header("References")]
    public TextMeshProUGUI uiTextHighscore;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateTex();
    }

    private void UpdateTex()
    {
        uiTextHighscore.text = PlayerPrefs.GetString(keyToSave, "");
    }

    public void SalvePlayerWin(Player p)
    {
        if (p.playerName == "") return;
        PlayerPrefs.SetString(keyToSave, p.playerName);
        UpdateTex();
    }

    /*public void Reset()
    {
        PlayerPrefs.DeleteKey(keyToSave);
    }*/

}
