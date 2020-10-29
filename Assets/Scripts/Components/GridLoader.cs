using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLoader : MonoBehaviour
{
    [Header("Component")]
    public GameConfiguration gameConfiguration;

    public Text title;

    public GridLayoutGroup grid;

    void Start()
    {
        if (gameConfiguration == null) GameObject.FindObjectOfType<GameConfiguration>();

        gameConfiguration.OnStartLoading += StartLoading;

        gameConfiguration.OnLoad += LoadGrid;

        gameConfiguration.OnFileNotFoundException += FileNotFound;

    }

    public void StartLoading()
    {

        title.text = "Loading..";

        Reset();

    }

    public void FileNotFound()
    {
        title.text = "ERROR: File not found.";

        Reset();
    }

    public void LoadGrid(DataModel dataModel)
    {

        title.text = dataModel.tittle;

        //Seting the numbers of row based on data items quantity.
        grid.constraintCount = dataModel.data.Count + 1;


        //Fixing the spacing cells.
        ReSizeGrid(grid.constraintCount);

        //First we add the headers.
        dataModel.columnHeaders.ForEach(header =>
        {
            AddHeader(header);
        });


        //Then we load the matrix.

        for (int i = 0; i < dataModel.data.Count; i++)
        {
            for (int x = 0; x < dataModel.columnHeaders.Count; x++)
            {
                string value;

                if (dataModel.data[i]
                    .columnsWithValue
                    .TryGetValue(dataModel.columnHeaders[x], out value))
                {
                    AddElement(value);
                } else
                {
                    Debug.Log(dataModel.columnHeaders[x] + "Not Found");
                }

            }
        }



    }

    private void Reset()
    {

        for (int i = 0; i < grid.transform.childCount; i++)
        {
            Destroy(grid.transform.GetChild(i).gameObject);
        }
    }

    //The elements add from the left to the right.

    void AddHeader(string header)
    {

        GameObject text = TextPool.GetOneText();

        text.transform.parent = grid.transform;

        text.GetComponent<Text>().fontStyle = FontStyle.Bold;

        text.GetComponent<Text>().text = header;

    }

    void AddElement(string element)
    {

        GameObject text = TextPool.GetOneText();

        text.transform.parent = grid.transform;


        text.GetComponent<Text>().text = element;

    }

    void ReSizeGrid(int rows)
    {
        switch (rows)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                grid.spacing = new Vector2(50, 50);
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                grid.spacing = new Vector2(50, 25);
                break;
            default:
                grid.spacing = new Vector2(50, 10);
                break;
        }
    }

}
