using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveFollow : MonoBehaviour
{
    [SerializeField] private Transform[] routes; // Input for the routes (curves) the object should follow
    [SerializeField] private float movementSpeed = 0.1f;

    private Vector3 _objectPosition;
    private int _routeToGo = 0;
    private float _tParam = 0.0f;
    private bool _coroutineAllowed = true;
    private bool chestOpened = false;
    private WoodenChest chest;

    private void Start()
    {
        chest = GetComponentInParent<WoodenChest>();
        // StartCoroutine(FollowBezierCurve(_routeToGo));
    }

    // Update is called once per frame
    void Update()
    {
        chestOpened = chest.Open;
        
        // Start coroutine if it isn't running already
        if (_coroutineAllowed && chestOpened)
        {
            StartCoroutine(FollowBezierCurve(_routeToGo));
        }
    }

    // Move the object along the bezier curve
    private IEnumerator FollowBezierCurve(int routeNumber)
    {
        _coroutineAllowed = false;

        // Get positions of the control points
        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

        while (_tParam < 1)
        {
            _tParam += movementSpeed * Time.deltaTime;

            // Use bezier formula to calculate the object position on the curve
            _objectPosition = (Mathf.Pow(1 - _tParam, 3) * p0 +
                               3 * _tParam * Mathf.Pow(1 - _tParam, 2) * p1 +
                               3 * Mathf.Pow(_tParam, 2) * (1 - _tParam) * p2 +
                               Mathf.Pow(_tParam, 3) * p3);

            transform.position = _objectPosition; // Set object position
            yield return new WaitForEndOfFrame();
        }

        _tParam = 0.0f;
        _routeToGo += 1;

        // If the object has followed all routes, reset it to start again
        if (_routeToGo > routes.Length - 1)
        {
            _routeToGo = 0;
        }

        // _coroutineAllowed = true;
    }
}