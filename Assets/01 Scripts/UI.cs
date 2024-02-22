using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SOO;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    [SerializeField] TMP_Text backgroundTextComponent;
    [SerializeField] Slider timeSlider;

    private void Awake()
    {
        textComponent.text = "0m";
        timeSlider.maxValue = timeSlider.value = PlayManager.Instance.Timer;
    }

    private void Start()
    {
        PlayManager.Instance.player.playerMoveAction +=
            () => textComponent.text = Util.StringBuilder("-", PlayManager.Instance.depth.ToString("#.##"), "m");
    }

    private void Update()
    {
        timeSlider.value = PlayManager.Instance.Timer;
    }

    public void ChangeBackgroundText(string str)
    {
        backgroundTextComponent.text = str;
    }
}
