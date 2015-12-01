using UnityEngine;
using System.Collections;

public class OptionButton : MonoBehaviour
{

    GameObject _lobby;
    GameObject _frontscreen;
   
	// Use this for initialization
	void Start () 
    {
        _lobby = GameObject.Find("Lobby");
        _lobby.SetActive(false);
        _frontscreen = GameObject.Find("Front Screen");
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void LaunchLobby()
    {
        _lobby.SetActive(true);
        _frontscreen.SetActive(false);
    }

    public void ReturnToMenu()
    {
        _lobby.SetActive(false);
        _frontscreen.SetActive(true);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }


    public void TwoPlayerMatch()
    {
        int amountOfPlayers = PlayerPrefs.GetInt("PlayerAmount");
        PlayerPrefs.SetInt("PlayerAmount", 2);
        Application.LoadLevel(1);

        return;
    }

    public void ThreePlayerMatch()
    {
        int amountOfPlayers = PlayerPrefs.GetInt("PlayerAmount");
        PlayerPrefs.SetInt("PlayerAmount", 3);
        Application.LoadLevel(1);
        return;
    }

    public void FourPlayerMatch()
    {
        int amountOfPlayers = PlayerPrefs.GetInt("PlayerAmount");
        PlayerPrefs.SetInt("PlayerAmount", 4);
        Application.LoadLevel(1);
        return;
    }


}
