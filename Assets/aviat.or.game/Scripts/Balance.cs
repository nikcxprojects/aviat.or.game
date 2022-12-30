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

        Product.OnBuyItem += (price) =>
        {
            if(price > Count)
            {
                return false;
            }

            Count -= price;
            return true;
        };

        textComponent.text = $"{Count}";
    }
}
