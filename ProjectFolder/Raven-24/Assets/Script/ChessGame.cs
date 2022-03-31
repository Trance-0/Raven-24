using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGame : MonoBehaviour
{
    // This game is separated into 3 parts.
    // first, put the chess on the right places.
    // second, play the chess on board. if chess is not on place, drop the camera.

    // Phase I
    public GameObject gridPF;
    public Transform starter;
    public Material black;
    public Material white;
    public float gridSize;
    public List<GameObject> grid;
    // order of placement: bb bk bp bq bt wk wp wq wt
    public List<Item> chessPiece;
    public List<int> indexOfPiece;


    // Phase II
    // Start is called before the first frame update
    void Start()
    {
        //generate grid    
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        // code for testing, comment them in real game
        if (Input.GetKey(KeyCode.R)) {
            GenerateGrid();
        }
        // code for testing, comment them in real game
    }
    private void GenerateGrid() {
        string f = "abcdefgh";
        bool checker = true;
        for (int i = 0; i<8; i++)
        {
            for (int j = 7; j >=0; j--)
            {
                GameObject newGrid = Instantiate(gridPF, new Vector3(starter.position.x, starter.position.y, starter.position.z), Quaternion.Euler(-90f, 55.21f, 0), transform);
                newGrid.transform.localScale = new Vector3(3f,3f,3f);
                newGrid.name = f[j] + (i+1).ToString()+" with code "+(i*8+7-j).ToString();
                if (checker)
                {
                    newGrid.GetComponent<MeshRenderer>().material = black;
                }
                else {
                    newGrid.GetComponent<MeshRenderer>().material = white;
                }
                grid.Add(newGrid);
                checker = !checker;
                starter.Translate(new Vector3(gridSize, 0f, 0f));
            }
            checker = !checker;
            starter.Translate(new Vector3(-gridSize * 8, 0f, gridSize));
        }
        if (chessPiece.Count != indexOfPiece.Count) {
            throw new UnityException("index of chess piece and indexs mismatch!");
        } 
        for (int i=0;i<chessPiece.Count;i++) {
            grid[indexOfPiece[i]].GetComponent<ItemHandle>().key = chessPiece[i]._key;
        }
    }
}
