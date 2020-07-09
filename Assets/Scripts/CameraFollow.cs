using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private float vertExtent;
    private float horizExtent;
    [SerializeField] private float screenOffsetPercent = 0.85f;

    // Start is called before the first frame update
    void Start()
    {
        vertExtent = Camera.main.orthographicSize;
        horizExtent = vertExtent * Screen.width / Screen.height;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + horizExtent * screenOffsetPercent, player.position.y, -10f);
    }
}
