using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public GameObject waterPrefab;
    public GameObject goalPrefab;
    public GameObject deepPrefab;
    public GameObject coinPrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            int column = 0;
            char[] letters = currentLine.ToCharArray();
            foreach (var letter in letters)
            {
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                var rocks = Instantiate(rockPrefab);
                var Qblock = Instantiate(questionBoxPrefab);
                var Bricks = Instantiate(brickPrefab);
                var Stones = Instantiate(stonePrefab);
                var water = Instantiate(waterPrefab);
                var goal = Instantiate(goalPrefab);
                var deepWater = Instantiate(deepPrefab);
                var coin = Instantiate(coinPrefab);

                if (letter == 'x')
                {
                    rocks.transform.position = new Vector3(column, row, 0);
                }

                if (letter == '?')
                {
                    Qblock.transform.position = new Vector3(column, row, 0);
                }

                if (letter == 'b')
                {
                    Bricks.transform.position = new Vector3(column, row, 0);
                }

                if (letter == 's')
                {
                    Stones.transform.position = new Vector3(column, row, 0);
                }
                if (letter == 'w')
                {
                    water.transform.position = new Vector3(column, row, 0);
                }
                if (letter == 'g')
                {
                    goal.transform.position = new Vector3(column, row, 0);
                }
                if (letter == 'd')
                {
                    deepWater.transform.position = new Vector3(column, row, 0);
                }
                if (letter == 'c')
                {
                    coin.transform.position = new Vector3(column, row, 0);
                }
                
                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
                column++;
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
