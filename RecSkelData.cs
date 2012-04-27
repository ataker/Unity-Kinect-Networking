using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RecSkelData : MonoBehaviour {

    private DummyLevel2 level2;
    private _Player player1;
    private _Player player2;
    private _Player player3;
    private _Player player4;
    private _Player player5;
    private _Player player6;

    // Use this for initialization
	void Start () {
        level2 = this.GetComponent<DummyLevel2>();
        try
        {
            player1 = level2.players[1];
            player2 = level2.players[2];
            player3 = level2.players[3];
            player4 = level2.players[4];
            player5 = level2.players[5];
            player6 = level2.players[6];
        }catch
        {
            
        }
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/



    [RPC]
    public void recSkelData(NetworkPlayer player, Vector3 skel1Head, Vector3 skel1Right, Vector3 skel1Left, Vector3 skel2Head, Vector3 skel2Right, Vector3 skel2Left, float timeSent)
    {
        //int playerIndex = (Convert.ToInt16(player.ToString()) * 2 )+ 1;
        _Player playerSendingData1;
        _Player playerSendingData2;

        player1 = level2.players[1];
        player2 = level2.players[2];
        switch (player.ToString())
        {
            case "0":
                playerSendingData1 = player1;
                playerSendingData2 = player2;
                break;
            case "1":
                
                playerSendingData1 = player3;
                playerSendingData2 = player4;
                break;
            case "2":
                
                playerSendingData1 = player5;
                playerSendingData2 = player6;
                break;
            default:

                break;
        }


        player1.head.Add(skel1Head);
        player1.rightHand.Add(skel1Right);
        player1.leftHand.Add(skel1Left);
        player1.times.Add(timeSent);

        player2.head.Add(skel2Head);
        player2.rightHand.Add(skel2Right);
        player2.leftHand.Add(skel2Left);
        player2.times.Add(timeSent);


    }

}
