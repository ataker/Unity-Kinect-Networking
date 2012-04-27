using UnityEngine;
using System.Collections;

public class SendSkelData : MonoBehaviour {

    public OpenNISkeleton Skel1;
    public OpenNISkeleton Skel2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	    try{
            object[] param = new object[8];
            param[0] = Network.player;
            param[1] = Skel1.Head.position;
            param[2] = Skel1.RightHand.position;
            param[3] = Skel1.LeftHand.position;
            param[4] = Skel2.Head.position;
            param[5] = Skel2.RightHand.position;
            param[6] = Skel2.LeftHand.position;
            param[7] = Time.deltaTime;
            if (Network.isServer)
            {
                RecSkelData rec = this.GetComponent<RecSkelData>();
                rec.recSkelData(Network.player, Skel1.Head.position, Skel1.RightHand.position, Skel1.LeftHand.position, Skel2.Head.position, Skel2.RightHand.position, Skel2.LeftHand.position, Time.deltaTime);
            }
            else
            {
                //networkView.RPC("recSkelData", RPCMode.Server, param);
            }
        }catch{
            //Debug.Log("Couldn't send Data");
        }
	}
}
