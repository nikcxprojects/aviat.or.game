using System;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    private bool WasBought
    {
        get => PlayerPrefs.HasKey($"{productType}({price})");
    }

    [SerializeField] int price;
    [SerializeField] ProductType productType;

    public static Func<int, bool> OnBuyItem { get; set; }
    public static Action<ProductType> OnProductSelected { get; set; }

    private void Start()
    {
        if (WasBought)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            return;
        }

        GetComponent<Button>().onClick.AddListener(() =>
        {
            if(OnBuyItem.Invoke(price))
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);

                PlayerPrefs.SetInt($"{productType}({price})", 1);
                PlayerPrefs.Save();
            }
        });

        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() =>
        {
            OnProductSelected.Invoke(productType);

            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
        });
    }
}
