using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SOO;

public class Title : MonoBehaviour
{
    [SerializeField] TMP_Text bestScore;
    private void Awake()
    {
        bestScore.text = Util.StringBuilder("Best:-", PlayerPrefs.GetFloat("depth").ToString("#.##"), "m");
    }

    private void Start()
    {
        Time.timeScale = 1;
    }
}
