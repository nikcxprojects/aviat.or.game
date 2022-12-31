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
    public static Func<ProductType, bool> OnProductSelected { get; set; }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if(WasBought)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);
                return;
            }

            if(OnBuyItem.Invoke(price))
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);

                PlayerPrefs.SetInt("${productType}({price})", 1);
                PlayerPrefs.Save();
            }
        });

        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() =>
        {
            OnProductSelected?.Invoke(productType);
        });
    }
}
