using UnityEngine.UI;
using UnityEngine;

public class Balance : MonoBehaviour
{
    private const string key = "balance";

    private int Count
    {
        get => PlayerPrefs.GetInt(key, 250);
        set => PlayerPrefs.SetInt(key, value);
    }

    private void Awake()
    {
        Text textComponent = transform.GetChild(0).GetComponent<Text>();
        //WheelSpinner.OnEndRolling += (value) =>
        //{
        //    Count += value;
        //    textComponent.text = $"{Count}";
        //};

        //Manager.OnEndRolling += (value) =>
        //{
        //    Count += value;
        //    textComponent.text = $"{Count}";
        //};

        textComponent.text = $"{Count}";
    }
}
