using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject groundLeft;
    public GameObject groundMiddle;
    public GameObject groundRight;
    public Transform player;

    public int platformWidth;
    [SerializeField] private int xGen;

    [SerializeField] private int minGapWidth = 2;
    [SerializeField] private int maxGapWidth = 8;
    [SerializeField] private int numGroundBlocks = 8;
    [SerializeField] private int maxHeightDelta;

    private int reliefWidth = 80;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        platformWidth = Random.Range(5, 15);
        maxHeightDelta = (int)Camera.main.orthographicSize;
        xGen = (int)player.position.x;
        
        GenerateTerrain();
        GenerateRelief();
        
    }

    void Update()
    {
        
    }

    private void GenerateTerrain()
    {
        for (int j = 0; j < numGroundBlocks; j++)
        {
            // Generate a randomly sized terrain block
            GenerateTerrainBlock(platformWidth);
        }
    }

    private void GenerateRelief()
    {
        //Geenrate a relief between block sets.
        GenerateTerrainBlock(reliefWidth);
    }

    private void GenerateTerrainBlock(int width)
    {
        float heightDelta = Random.Range(0, maxHeightDelta);

        Instantiate(groundLeft, new Vector3 (xGen, heightDelta, 0), Quaternion.identity);
        xGen++;
        for (int i = xGen; i < (xGen + width); i++)
        {
            Instantiate(groundMiddle, new Vector3(i, heightDelta, 0), Quaternion.identity);
            if (i == xGen + width - 1)
            {
                xGen = i + 1;
                break;
            }
        }
        Instantiate(groundRight, new Vector3 (xGen, heightDelta, 0), Quaternion.identity);

        //Generate a gap after
        xGen += Random.Range(minGapWidth, maxGapWidth);
    }
}
