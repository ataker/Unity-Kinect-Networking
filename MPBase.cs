using UnityEngine;
using System.Collections;
using System;

public class MPBase : MonoBehaviour {


    public string connectToIp = "127.0.0.1";
    public int connectPort = 25000;
    public bool useNAT = false;
    public string ipAddress = "";
    public string port = "";



    void OnGUI()
    {
        
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            if (GUILayout.Button("Connect"))
            {
                
                Network.Connect(connectToIp, connectPort);
                
            }

            if (GUILayout.Button("Start Server"))
            {
               
                Network.InitializeServer(32, connectPort, useNAT);


                foreach (GameObject go in FindObjectsOfType(typeof(GameObject)))
                {
                    go.SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
                }



                

            }

            connectToIp = GUILayout.TextField(connectToIp);
            connectPort = Convert.ToInt32(GUILayout.TextField(connectPort.ToString()));
        }
        else
        {
            if(Network.peerType == NetworkPeerType.Connecting)
            {
                GUILayout.Label("Connect status: Connecting");
            }else if(Network.peerType == NetworkPeerType.Client)
            {
                GUILayout.Label("Connect status: Client");
                GUILayout.Label("Ping to server: " + Network.GetAveragePing(Network.connections[0]));
            }else if(Network.peerType == NetworkPeerType.Server)
            {
                GUILayout.Label("Connect status: Server");
                GUILayout.Label("Connections: " + Network.connections.Length);
                if (Network.connections.Length >= 1)
                {
                    GUILayout.Label("Ping to server: " + Network.GetAveragePing(Network.connections[0]));
                }
            }


            if(GUILayout.Button("Disonnect"))
            {
                Network.Disconnect(200);
            }
            ipAddress = Network.player.ipAddress;
            port = Network.player.port.ToString();
            GUILayout.Label("IP Address: "+ ipAddress + " : " + port);
        }
    }

    /*
    void OnPlayerConnected(NetworkPlayer netPlayer)
    {
        networkView.RPC("initClientPlayers", netPlayer, Network.connections.Length);
    }

    [RPC]
    void initClientPlayers(int connections)
    {
        //GameObject openNI = GameObject.Find("OpenNI");
        //openNI.GetComponent<OpenNISplitScreenSkeletonController>().initClientPlayers(connections);
    }

    void OnConnectedToServer()
    {
        foreach (GameObject go in FindObjectsOfType(typeof(GameObject)))
        {
            go.SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
        }


    }
    */
}
