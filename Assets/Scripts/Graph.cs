﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab = default;

    [SerializeField, Range(10,100) ]
    int resolution = 10;

    Transform[] points;

    void Awake ()
    {
        float step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++) {
            Transform point = Instantiate(pointPrefab);
            point.SetParent(transform, false);
            ///point.localPosition = Vector3.right * ((i + 5f) / 5f - 1f);
            position.x = (i + 0.5f) * step - 1f;
            //position.y = position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
            points[i] = point;
        }
        //point = Instantiate(pointPrefab);
        //point.localPosition = Vector3.right * 2f;
   
    }
    void Update () 
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++){
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            point.localPosition = position;
        }
    }
}