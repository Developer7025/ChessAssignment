using System;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int row, column;
        public Manager gameManager;
        private void Start() {
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;

            gameManager = GameObject.Find("GameManager").GetComponent<Manager>();
            gameManager.SetPosition(gameObject,row,column);
            
        }
        public int GetXPosition()
        {
            return row;
        }
        public int GetYPosition()
        {
            return column;
        }
        public void OnMouseUp()
        {
            DestroyHighlight();
            InitializeHighlight();
        }
        void DestroyHighlight()
        {
            ChessBoardPlacementHandler.Instance.ClearHighlights();
        }
        public void InitializeHighlight() 
        {
            switch (this.name) 
            {
                case "Knight":
                    KnightMove();
                    break;
                case "King":
                    SurroundMove();
                    break;
                case "Queen":
                    LineMove(1, 0);
                    LineMove(0, 1);
                    LineMove(-1, 0);
                    LineMove(0, -1);
                    LineMove(1, 1);
                    LineMove(-1, 1);
                    LineMove(1, -1);
                    LineMove(-1, -1);
                    break;
                case "Rook":
                    LineMove(1, 0);
                    LineMove(0, 1);
                    LineMove(-1, 0);
                    LineMove(0, -1);
                    break;
                case "Bishop":
                    LineMove(1, 1);
                    LineMove(-1, 1);
                    LineMove(1, -1);
                    LineMove(-1, -1);
                    break;

                case "Pawn":
                    PawnMove(row + 1 , column );
                    break;

            }

        }

        void LineMove(int xIncrement , int yIncrement) 
        {
            
            int x = this.row + xIncrement;
            int y = this.column + yIncrement;
            while (ChessBoardPlacementHandler.Instance.GetTile(x,y) != null && gameManager.GetPosition(x,y) == null)
            {
                ChessBoardPlacementHandler.Instance.Highlight(x,y,false);
                x += xIncrement;
                y += yIncrement;
            }
            if (ChessBoardPlacementHandler.Instance.GetTile(x, y) != null && gameManager.GetPosition(x,y).gameObject.layer != gameObject.layer) 
            {
                ChessBoardPlacementHandler.Instance.Highlight(x, y, true);
            }
        }
        void SurroundMove() 
        {
            PointMove(row, column + 1);
            PointMove(row + 1, column);
            PointMove(row, column - 1);
            PointMove(row - 1, column);
            PointMove(row + 1, column + 1);
            PointMove(row - 1, column + 1);
            PointMove(row + 1, column - 1);
            PointMove(row - 1, column - 1);
        }
        void KnightMove() 
        {
            PointMove(row +2, column + 1);
            PointMove(row +2, column - 1);
            PointMove(row -2, column + 1);
            PointMove(row -2, column - 1);
            PointMove(row +1, column + 2);
            PointMove(row +1, column - 2);
            PointMove(row -1, column + 2);
            PointMove(row -1, column - 2);
        }

        void PointMove(int x , int y)
        {
            if (ChessBoardPlacementHandler.Instance.GetTile(x, y) != null && gameManager.GetPosition(x, y) == null)
            {
                ChessBoardPlacementHandler.Instance.Highlight(x, y, false);
            }
            else if (ChessBoardPlacementHandler.Instance.GetTile(x, y) != null && gameManager.GetPosition(x, y).gameObject.layer != gameObject.layer)
            {
                ChessBoardPlacementHandler.Instance.Highlight(x, y, true);
            }
        }
        void PawnMove(int x , int y) 
        {
            if (ChessBoardPlacementHandler.Instance.GetTile(x, y) != null && gameManager.GetPosition(x, y) == null)
            {
                ChessBoardPlacementHandler.Instance.Highlight(x, y, false);
            }
            if (ChessBoardPlacementHandler.Instance.GetTile(x , 1+y) != null && gameManager.GetPosition( x, y + 1).gameObject.layer != gameObject.layer)
            {
                ChessBoardPlacementHandler.Instance.Highlight(x , y + 1, true);
            }
            if (ChessBoardPlacementHandler.Instance.GetTile(x ,  y -1 ) != null && gameManager.GetPosition(x , y - 1).gameObject.layer != gameObject.layer)
            {
                ChessBoardPlacementHandler.Instance.Highlight(x , y - 1, true);
            }
        }
    }
    


}