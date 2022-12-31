using UnityEngine.UI;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    private Image Image { get; set; }
    private void Awake()
    {
        Image = GetComponent<Image>();

        Product.OnProductSelected += (type, id) =>
        {
            if(type == ProductType.Background)
            {
                return;
            }

            PlayerPrefsUtility.SetAirplaneSprite(id);

            Image.sprite = PlayerPrefsUtility.GetAirplaneplaneSprite;
            Image.SetNativeSize();
        };
    }

    private void OnEnable()
    {
        Image.sprite = PlayerPrefsUtility.GetAirplaneplaneSprite;
        Image.SetNativeSize();
    }
}
