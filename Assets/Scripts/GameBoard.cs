using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;

    public void GenerateGrid(int width, int height)
    {
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                var position = new Vector3(x, 0.1f,y); 
                Instantiate(_cellPrefab, position, Quaternion.identity);
            }
        }
    }
}
