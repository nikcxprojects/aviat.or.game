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
}
