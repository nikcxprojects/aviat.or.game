using System;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] ProductType productType;

    public static Func<int, bool> OnBuyItem { get; set; }
    public static Func<ProductType, bool> OnProductSelected { get; set; }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if(OnBuyItem.Invoke(price))
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);
            }
        });

        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() =>
        {
            OnProductSelected?.Invoke(productType);
        });
    }
}
