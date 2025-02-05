using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private BlockController blockController;
    [SerializeField] private PanelManager panelManager;
    [SerializeField] private GameUIController gameUIController;

    // 강사님과 다른 내 코드
    [SerializeField] private TMP_Text tempText; // 테스트
    
    
    public enum PlayerType { None, A, B }
    private PlayerType[,] board;
    
    public enum TurnType { PlayerA, PlayerB }

    private enum GameResult
    {
        None, // 게임 진행 중
        Win, // 플래이어 승
        Draw, // 비김
        Lose // 플레이어 패
    }


    void Start()
    {
        // 게임 초기화
        InitGame();
        
    }
    
    /// <summary>
    /// 게임 초기화 함수
    /// </summary>
    public void InitGame()
    {
        // board 초기화
        board = new PlayerType[3, 3];
        
        // 블록 초기화
        blockController.InitBlocks();
        
        // 게임 UI 초기화
        gameUIController.SetUIMode(GameUIController.GameUIMode.Init);
        
        // 게임 스타트
        StartGame();
    }

    public void StartGame()
    {
        SetTurn(TurnType.PlayerA);
        panelManager.ShowPanel(PanelManager.PanelType.InGamePanel);
    }

    /// <summary>
    /// 게임 오버시 호출되는 함수
    /// gameResult에 따라 결과 출력
    /// </summary>
    /// <param name="gameResult">Win, Lose, Draw</param>
    private void EndGame(GameResult gameResult)
    {
        // TODO: 추후 구현!
        switch (gameResult)
        {
            case GameResult.Win:
                break;
            case GameResult.Draw:
                break;
            case GameResult.Lose:
                break;
        }
    }

    /// <summary>
    /// board에 새로운 값을 할당하는 함수
    /// </summary>
    /// <param name="playerType">할당하고자 하는 플레이어 타입</param>
    /// <param name="row">Row</param>
    /// <param name="col">Col</param>
    /// <returns>False 반환 시 할당 X, True는 할당이 완료됨</returns>
    private bool SetNewBoardValue(PlayerType playerType, int row, int col)
    {
        if (playerType == PlayerType.A)
        {
            board[row, col] = playerType;
            blockController.PlaceMarker(Block.MarkerType.O, row, col);
            return true;
        }
        
        else if (playerType == PlayerType.B)
        {
            board[row, col] = playerType;
            blockController.PlaceMarker(Block.MarkerType.X, row, col);
            return true;
        }

        return false;
    }
    
    private void SetTurn(TurnType turnType)
    {
        switch (turnType)
        {
            case TurnType.PlayerA:
                gameUIController.SetUIMode(GameUIController.GameUIMode.TurnA);
                blockController.onBlockClickedDelegate = (row, col) =>
                {
                    // TODO: 1. board에 내용 반영
                    // TODO: 2. 화면에 마커 표시
                    if (SetNewBoardValue(PlayerType.A, row, col))
                    {
                        var gameResult = CheckGameResult();
                        if (gameResult == GameResult.None)
                            SetTurn(TurnType.PlayerB);
                        else
                        {
                            gameUIController.SetUIMode(GameUIController.GameUIMode.GameOver);
                            EndGame(gameResult);
                        }
                    }
                    else
                    {
                        // TODO: 이미 있는 곳을 터치했을 때 처리
                    }
                };
                break;
            
            case TurnType.PlayerB:
                gameUIController.SetUIMode(GameUIController.GameUIMode.TurnB);
                blockController.onBlockClickedDelegate = (row, col) =>
                {
                    if (SetNewBoardValue(PlayerType.B, row, col))
                    {
                        var gameResult = CheckGameResult();
                        if(gameResult == GameResult.None)
                            SetTurn(TurnType.PlayerA);
                        else
                        {
                            gameUIController.SetUIMode(GameUIController.GameUIMode.GameOver);
                            EndGame(gameResult);
                        }
                    }
                };
                // TODO: AI에게 입력 받기
                
                break;
        }
    }

    /// <summary>
    /// 게임 결과 확인 함수
    /// </summary>
    /// <returns>플레이어 기준 게임 결과</returns>
    private GameResult CheckGameResult()
    {
        if (CheckGameWin(PlayerType.A))
        {
            tempText.text = "Player1 Win";
            return GameResult.Win;
        }

        if (CheckGameWin(PlayerType.B))
        {
            tempText.text = "Player2 Win";
            return GameResult.Lose;
        }

        if (IsAllBlocksPlaced())
        {
            tempText.text = "Draw";
            return GameResult.Draw;
        }
        return GameResult.None;
    }
    
    /// <summary>
    /// 모든 마커가 보드에 배치 되었는지 확인하는 함수
    /// </summary>
    /// <returns> True : 모두 배치 </returns>
    private bool IsAllBlocksPlaced()
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == PlayerType.None)
                    return false;
            }
        }
        return true;
    }
    
    // 게임의 승/패 판단하는 함수
    private bool CheckGameWin(PlayerType playerType)
    {
        // 가로로 마커가 일치하는지 확인
        for (var row = 0; row < board.GetLength(0); row++)
        {
            if (board[row, 0] == playerType && board[row, 1] == playerType && board[row, 2] == playerType)
            {
                (int, int)[] blocks = {(row, 0), (row, 1), (row, 2)};
                blockController.SetBlockColor(playerType, blocks);
                return true;
            }
        }

        // 세로로 마커가 일치하는지 확인
        for (var col = 0; col < board.GetLength(1); col++)
        {
            if (board[0, col] == playerType && board[1, col] == playerType && board[2, col] == playerType)
            {
                (int, int)[] blocks = {(0, col), (1, col), (2, col)};
                blockController.SetBlockColor(playerType, blocks);
                return true;
            }
        }
        
        // 대각선 마커 일치하는지 확인
        if (board[0, 0] == playerType && board[1, 1] == playerType && board[2, 2] == playerType)
        {
            (int, int)[] blocks = {(0, 0), (1, 1), (2, 2)};
            blockController.SetBlockColor(playerType, blocks);
            return true;
        }

        if (board[2, 0] == playerType && board[1, 1] == playerType && board[0, 2] == playerType)
        {
            (int, int)[] blocks = {(2, 0), (1, 1), (0, 2)};
            blockController.SetBlockColor(playerType, blocks);
            return true;
        }
        
        // 하나도 포함되지 않는다면 리턴 flase
        return false;
    }
}
