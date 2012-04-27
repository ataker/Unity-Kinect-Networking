using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class _Player : object  {

    public int player_slot { get; set; } //Keeps track of the "slot" I am in

    public List<Vector3> head { get; set; }
    public List<Vector3> leftHand { get; set; }
    public List<Vector3> rightHand { get; set; }
    public List<float> times { get; set; }

    // Use this for initialization
    public void Start()
    {
        Debug.Log("asdsadasdasdsad");
        head = new List<Vector3>();
        leftHand = new List<Vector3>();
        rightHand = new List<Vector3>();
        times = new List<float>();
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log(head[1].ToString());
    }
}
