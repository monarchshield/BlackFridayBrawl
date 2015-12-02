﻿using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
    

    public GameObject _P1Prefab;
    public GameObject _P2Prefab;
    public GameObject _P3Prefab;
    public GameObject _P4Prefab;

    [Tooltip("Is player 1 Active in the game")]
    private bool _P1Active;

    [Tooltip("Is player 2 Active in the game")]
    private bool _P2Active;

    [Tooltip("Is player 3 Active in the game")]
    private bool _P3Active;

    [Tooltip("Is player 4 Active in the game")]
    private bool _P4Active;

    [Tooltip("How many players are participating in match, this determines active status")]
    private int _amountOfPlayers;

    Player _P1Component;
    Player _P2Component;
    Player _P3Component;
    Player _P4Component;

	// Use this for initialization
	void Start ()
    {
        _amountOfPlayers = PlayerPrefs.GetInt("PlayerAmount");
        Debug.Log("The Amount of players in the scene" + _amountOfPlayers.ToString());
        SetActivePlayers();

        _P1Component = _P1Prefab.GetComponent<Player>();
        _P2Component = _P2Prefab.GetComponent<Player>();
        _P3Component = _P3Prefab.GetComponent<Player>();
        _P4Component = _P4Prefab.GetComponent<Player>();

	}
	
	// Update is called once per frame
	void Update () 
    {  
       
        Player1Input();
        Player2Input();
        Player3Input();
        Player4Input();
	}

    private void Player1Input()
    {
        if(_P1Active)
        {
           
                //P1MoveXaxis

            Vector3 Direction = new Vector3(Input.GetAxis("P1MoveXaxis"), 0, Input.GetAxis("P1MoveYaxis"));
            _P1Component.MoveInDirection(Direction);


            if (Input.GetButtonDown("P1Attack"))
                _P1Component.UseAttack();

            if (Input.GetButtonDown("P1IteamPickup"))
                _P1Component.PickUpIteam(0, 0);
        }

    }

    private void Player2Input()
    {
        if (_P2Active)
        {
            Vector3 Direction = new Vector3(Input.GetAxis("P2MoveXaxis"), 0, Input.GetAxis("P2MoveYaxis"));
            _P2Component.MoveInDirection(Direction);


            if (Input.GetButtonDown("P2Attack"))
                _P2Component.UseAttack();

            if (Input.GetButtonDown("P2IteamPickup"))
                _P2Component.PickUpIteam(0, 0);
        }

    }

    private void Player3Input()
    {
        if (_P3Active)
        {
            Vector3 Direction = new Vector3(Input.GetAxis("P3MoveXaxis"), 0, Input.GetAxis("P3MoveYaxis"));
            _P3Component.MoveInDirection(Direction);


            if (Input.GetButtonDown("P3Attack"))
                _P3Component.UseAttack();

            if (Input.GetButtonDown("P3IteamPickup"))
                _P3Component.PickUpIteam(0, 0);
        }

    }

    private void Player4Input()
    {
        if (_P4Active)
        {
            Vector3 Direction = new Vector3(Input.GetAxis("P4MoveXaxis"), 0, Input.GetAxis("P4MoveYaxis"));
            _P4Component.MoveInDirection(Direction);


            if (Input.GetButtonDown("P4Attack"))
                _P4Component.UseAttack();

            if (Input.GetButtonDown("P4IteamPickup"))
                _P4Component.PickUpIteam(0, 0);
        }

    }

    /// <Set Active Players, Called During Initialisation>
    /// This is a function that gets called at initalisation
    /// it sets which players will be playing this game
    /// </summary>
    private void SetActivePlayers()
    {
        _P1Active = true;
        _P2Active = true;
        _P1Prefab.SetActive(true);

        switch (_amountOfPlayers)
        {
            case 1:
                _P3Active = false;
                _P3Prefab.SetActive(false);

                _P4Active = false;
                _P4Prefab.SetActive(false);
                break;

            case 2:
                _P3Active = true;

                _P4Active = false;
                _P4Prefab.SetActive(false);
                break;

            case 3:
                _P3Active = true;
                _P4Active = true;
                break;

            default:
                break;
        }
    }

}
