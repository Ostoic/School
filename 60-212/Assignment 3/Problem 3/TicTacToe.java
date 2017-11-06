package com.company;

import java.io.PrintStream;

/**
 * Class for playing TicTacToe.
 */
public class TicTacToe
{
    private TicTacToeBoard gameBoard;
    private Character player1Piece;
    private Character player2Piece;

    private int currentPlayer;

    /**
     * Create an instance of TicTacToe.
     * @param player1Piece the game piece player 1 has chosen.
     * @param player2Piece the game piece player 2 has chosen.
     */
    TicTacToe(Character player1Piece, Character player2Piece)
    {
        gameBoard = new TicTacToeBoard();
        this.player1Piece = player1Piece;
        this.player2Piece = player2Piece;
        this.currentPlayer = 1;
    }

    /**
     * Mark the point on the game board for player 1.
     * @param row the row to mark.
     * @param col the column to mark.
     */
    private void player1Mark(int row, int col)
    {
        this.gameBoard.mark(row, col, this.player1Piece);
    }

    /**
     * Mark the point on the game board for player 2.
     * @param row the row to mark.
     * @param col the column to mark.
     */
    private void player2Mark(int row, int col)
    {
        this.gameBoard.mark(row, col, this.player2Piece);
    }

    /**
     * Mark the location on the game board for the current player.
     * @param row the row to mark.
     * @param col the column to mark.
     * @return true if the mark was applied, false if there was already a mark there.
     */
    public boolean playerMark(int row, int col)
    {
        if (gameBoard.hasMark(row - 1, col - 1))
            return false;

        if (this.currentPlayer == 1)
        {
            this.player1Mark(row - 1, col - 1);
            this.currentPlayer = 2;
        }

        else if (this.currentPlayer == 2)
        {
            this.player2Mark(row - 1, col - 1);
            this.currentPlayer = 1;
        }

        return true;
    }

    /**
     * Get the player who is currently going.
     * @return the number of the player.
     */
    public int getCurrentPlayer()
    {
        return this.currentPlayer;
    }

    /**
     * Determine if the player has made 3 marks along the diagonal of the game board.
     * @param gamePiece the player's game piece to compare with.
     * @return true if a diagonal has been marked by the player, false otherwise.
     */
    private boolean checkDiagonalWin(Character gamePiece)
    {
        boolean diagonal1 =
                this.gameBoard.hasMark(0, 0, gamePiece) &&
                this.gameBoard.hasMark(1, 1, gamePiece) &&
                this.gameBoard.hasMark(2, 2, gamePiece);

        boolean diagonal2 =
                this.gameBoard.hasMark(0, 2, gamePiece) &&
                this.gameBoard.hasMark(1, 1, gamePiece) &&
                this.gameBoard.hasMark(2, 0, gamePiece);

        return diagonal1 || diagonal2;
    }

    /**
     * Check the given column for 3-in-a-row marks by the player.
     * @param column the column to check.
     * @param gamePiece the player's game piece to compare with.
     * @return true if the player made 3-in-a-row marks, false otherwise.
     */
    private boolean checkColumn(int column, Character gamePiece)
    {
        for (int i = 0; i < gameBoard.length(); i++)
            if (!gameBoard.hasMark(i, column, gamePiece))
                return false;

        return true;
    }

    /**
     * Check the given row for 3-in-a-row marks by the player.
     * @param row the row to check.
     * @param gamePiece the player's game piece to compare with.
     * @return true if the player made 3-in-a-row marks, false otherwise.
     */
    private boolean checkRow(int row, Character gamePiece)
    {
        for (int i = 0; i < gameBoard.length(); i++)
            if (!gameBoard.hasMark(row, i, gamePiece))
                return false;

        return true;
    }

    /**
     * Check all rows to see if player has won.
     * @param gamePiece the player's game piece to check.
     * @return true if the player has won, false otherwise.
     */
    private boolean checkHorizontalWin(Character gamePiece)
    {
        for (int i = 0; i < gameBoard.length(); i++)
        {
            if (checkRow(i, gamePiece))
                return true;
        }

        return false;
    }

    /**
     * Check all columns to see if player has won.
     * @param gamePiece the player's game piece to check.
     * @return true if the player has won, false otherwise.
     */
    private boolean checkVerticalWin(Character gamePiece)
    {
        for (int i = 0; i < gameBoard.length(); i++)
        {
            if (checkColumn(i, gamePiece))
                return true;
        }

        return false;
    }

    /**
     * Check if the player has won.
     * @param gamePiece the player's game piece.
     * @return true if the player has won, false otherwise.
     */
    public boolean hasPlayerWon(Character gamePiece)
    {
        return  this.checkDiagonalWin(gamePiece) ||
                this.checkVerticalWin(gamePiece) ||
                this.checkHorizontalWin(gamePiece);
    }

    /**
     * Check if the game is over.
     * @return true if a player has won, or if a tie has occurred (full game board), false otherwise.
     */
    public boolean gameOver()
    {
        return  this.hasPlayerWon(this.player1Piece) ||
                this.hasPlayerWon(this.player2Piece) ||
                this.gameBoard.full();
    }

    /**
     * Draw the game board
     * @param p the print stream to draw to.
     */
    public void drawGame(PrintStream p)
    {
        this.gameBoard.drawBoard(p);
    }
}
