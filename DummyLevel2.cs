using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DummyLevel2 : MonoBehaviour {

    public Dictionary<int, _Player> players { get; set; }

	// Use this for initialization
	void Start () {
        players = new Dictionary<int, _Player>();

        for (int i = 1; i <= 6; i++)
        {
            Debug.Log("ahhhhhhhh");
            _Player newPlayer = new _Player();
            newPlayer.Start();

            newPlayer.player_slot = i;

            players.Add(i, newPlayer);
        }
	}

    // Update is called once per frame
    void Update()
    {
        try
        {
            Debug.Log(players[1].head[players[1].head.Count-1].ToString() + "!!!");
        }
        catch(Exception e)
        {
            //Debug.Log("C'monnnn  " + e);
        }
	}
}
