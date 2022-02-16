using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public PlayerMovement player;
    // Public Weapon 
    public FloatingTextManager floatingTextManager;

    // Logic
    public int pesos;
    public int experience;

    // Floating Text
    public void ShowText(string msg, int fontSize, Color color, Vector3 motion, Vector3 mention, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, motion, mention, duration);
    }

    //Save State
    /*
     * INT preferredSkin
     * INT pesos
     * INT experiences
     * INT weaponLevel
     */
    public void SaveState()
    {
        string s = " ";

        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change Player Skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[1]);
        //Change the weapon level

        Debug.Log("LoadState");
    }

}
