using UnityEngine;

public static class PlayerPrefsUtility
{
    public static Sprite GetAirplaneplaneSprite
    {
        get => Resources.Load<Sprite>($"Airplanes/{PlayerPrefs.GetInt("airplane")}");
    }

    public static void SetAirplaneSprite(int id)
    {
        PlayerPrefs.SetInt("airplane", id);
    }

    public static Sprite GetBackgroundSprite
    {
        get => Resources.Load<Sprite>($"Backgrounds/{PlayerPrefs.GetInt("background")}");
    }

    public static void SetBackgroundSprite(int id)
    {
        PlayerPrefs.SetInt("background", id);
    }
}
