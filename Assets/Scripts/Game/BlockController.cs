using UnityEngine;


public class BlockController : MonoBehaviour
{
    [SerializeField] private Block[] blocks;
    
    public delegate void OnBlockClicked(int row, int column);
    public OnBlockClicked onBlockClickedDelegate;

    public void InitBlocks()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].InitMarker(i, blockIndex =>
            {
                var clickedRow = blockIndex / 3;
                var clickedCol = blockIndex % 3;
                
                onBlockClickedDelegate?.Invoke(clickedRow, clickedCol);
            });
        }
    }
    
    /// <summary>
    /// 특정 Block에 마커 표시 함수
    /// </summary>
    /// <param name="markerType">마커 타입</param>
    /// <param name="row">Row</param>
    /// <param name="col">Col</param>
    public void PlaceMarker(Block.MarkerType markerType, int row, int col)
    {
        // row, col을 index로 변환
        var markerIndex = row * 3 + col;
        
        // Block에게 마커 표시
        blocks[markerIndex].SetMarker(markerType);
    }

    public void SetBlockColor(GameManager.PlayerType playerType,
                                (int row, int col)[] blocksPositions ) // 튜플 배열 block 포지션 매개변수로 받기
    {
        if (playerType == GameManager.PlayerType.None)
            return;

        foreach (var blockPosition in blocksPositions)
        {
            var blockIndex = blockPosition.row * 3 + blockPosition.col;
            Color markerColor;
            if(playerType == GameManager.PlayerType.A)
                markerColor = new Color32(0, 255, 125, 255);
            
            else if (playerType == GameManager.PlayerType.B)
            {
                markerColor = Color.red;
            }
            else
            {
                markerColor = Color.black;
            }
            blocks[blockIndex].SetColor(markerColor);
        }
    }
}

// 구조체를 활용해 매개 변수를 담아도 된다.
public struct BlockPosition
{
    public int row;
    public int col;
        
}
