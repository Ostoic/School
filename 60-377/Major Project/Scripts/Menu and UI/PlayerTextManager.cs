using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTextManager : MonoBehaviour
{
    public Vector3 pos;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Camera camera;

    private Vector3 roboPos;
    private RectTransform rt;
    private RectTransform canvasRT;
    private Vector3 roboScreenPos;

    // Use this for initialization
    void Start()
    {
        roboPos = player.transform.position;

        rt = GetComponent<RectTransform>();
        canvasRT = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        roboScreenPos = camera.WorldToViewportPoint(player.transform.TransformPoint(roboPos));
        rt.anchorMax = roboScreenPos;
        rt.anchorMin = roboScreenPos;
    }

    // Update is called once per frame
    void Update()
    {
        roboScreenPos = camera.WorldToViewportPoint(player.transform.TransformPoint(roboPos));
        rt.anchorMax = roboScreenPos;
        rt.anchorMin = roboScreenPos;
    }
}
