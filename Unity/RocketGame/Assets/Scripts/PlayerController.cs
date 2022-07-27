using Autohand;
using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Hand RightHand;
    [SerializeField] private Hand LeftHand;
    [SerializeField] private Rigidbody Body;
    [SerializeField] private Transform Head;
    [SerializeField] private float JumpSpeed = 1;
    [SerializeField] private AutoHandPlayer Player;

    void Start()
    {
        RightHand.OnSqueezed += RightHand_OnSqueezed; //Trigger button
        RightHand.OnTriggerGrab += RightHand_OnTriggerGrab; //Grip button
    }

    private void OnDestroy()
    {
        RightHand.OnSqueezed -= RightHand_OnSqueezed; //Trigger button
        RightHand.OnTriggerGrab -= RightHand_OnTriggerGrab; //Grip button
    }

    private void jump()
    {
        Debug.Log("Jump");
        Player.body.AddForce(Vector3.up * JumpSpeed);
        Debug.Log(Player.body == Body);
    }


    private void RightHand_OnTriggerGrab(Hand hand, Grabbable grabbable) //Execute when Grip button is pressed
    {
        jump();
    }

    private void RightHand_OnSqueezed(Hand hand, Grabbable grabbable) //Executed when Trigger button is pressed
    {
    }
}
