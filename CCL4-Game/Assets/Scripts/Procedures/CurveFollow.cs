using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveFollow : MonoBehaviour
{
    [SerializeField] private Transform[] routes; // Input for the routes (curves) the object should follow
    [SerializeField] private float movementSpeed = 0.1f;

    [SerializeField] GameObject mapTrail;

    private Vector3 objectPosition;
    private int routeToGo = 0;
    private float tParam = 0.0f;
    private bool coroutineAllowed = true;
    private bool chestOpened = false;
    private WoodenChest chest;

    private void Start()
    {
        chest = GetComponentInParent<WoodenChest>();
    }

    // Update is called once per frame
    void Update()
    {
        chestOpened = chest.Open;
        
        // Start coroutine only if it isn't running already and the chest has opened
        if (coroutineAllowed && chestOpened)
        {
            ActivatePlayVFX();
            PlaySound();
            StartCoroutine(FollowBezierCurve(routeToGo));
        }
    }

    // Move the object along the bezier curve
    private IEnumerator FollowBezierCurve(int routeNumber)
    {
        coroutineAllowed = false;

        // Get positions of the control points
        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += movementSpeed * Time.deltaTime;

            // Use bezier formula to calculate the object position on the curve
            objectPosition = (Mathf.Pow(1 - tParam, 3) * p0 +
                               3 * tParam * Mathf.Pow(1 - tParam, 2) * p1 +
                               3 * Mathf.Pow(tParam, 2) * (1 - tParam) * p2 +
                               Mathf.Pow(tParam, 3) * p3);

            transform.position = objectPosition; // Set object position
            yield return new WaitForEndOfFrame();
        }

        tParam = 0.0f;
        routeToGo += 1;

        // If the object has followed all routes, reset it
        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }
    }


    private void ActivatePlayVFX()
    {
        mapTrail.gameObject.SetActive(true);

    }

    private void PlaySound()
    {
        AkSoundEngine.PostEvent("Play_MapGlitterEffect", gameObject);
    }
}