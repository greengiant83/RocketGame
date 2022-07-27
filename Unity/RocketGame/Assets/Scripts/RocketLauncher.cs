using Autohand;
using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private Hand Hand;
    [SerializeField] private string RocketPrefabName = "Rocket";
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float FireSpeed;

    void Start()
    {
        Hand.OnSqueezed += Hand_OnSqueezed;
    }

    private void OnDestroy()
    {
        Hand.OnSqueezed -= Hand_OnSqueezed;
    }

    private void Hand_OnSqueezed(Hand hand, Grabbable grabbable)
    {
        fireRocket();
    }

    private void fireRocket()
    {
        var rocket = Realtime.Instantiate("Rocket", Realtime.InstantiateOptions.defaults);
        rocket.GetComponent<RealtimeTransform>().RequestOwnership();
        var rocketBody = rocket.GetComponent<Rigidbody>();
        rocket.transform.position = FirePoint.position;
        rocket.transform.rotation = FirePoint.rotation;
        rocketBody.velocity = rocket.transform.forward * FireSpeed;
    }
}
