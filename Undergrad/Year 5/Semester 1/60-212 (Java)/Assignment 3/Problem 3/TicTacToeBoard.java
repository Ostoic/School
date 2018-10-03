package com.company;

import java.io.PrintStream;

/**
 * Class representing the game board for TicTacToe.
 */
public class TicTacToeBoard
{
    /**
     * The Game board
     */
    private Character board[][];

    /**
     * Default construct an instance of the TicTacToe game.
     * Sets up game grid.
     */
    TicTacToeBoard()
    {
        this.board = new Character[3][3];
        this.fillBoard(' ');
    }

    /**
     * Fill the game board with a given character.
     * @param x the character to fill with.
     */
    private void fillBoard(Character x)
    {
        for (int i = 0; i < this.board.length; i++)
            for (int j = 0; j < this.board.length; j++)
                this.board[i][j] = x;
    }

    /**
     * Get the size of the game board
     * @return the length of the dimensions of the game board (square 3x3).
     */
    public int length()
    {
        return this.board.length;
    }

    /**
     * Mark the game piece on the game grid for the given coordinates.
     * @param row the row to mark.
     * @param col the column to mark.
     * @param gamePiece the game piece to mark.
     */
    public void mark(int row, int col, Character gamePiece)
    {
        this.board[row][col] = gamePiece;
    }

    /**
     * Check if the point on the game board is marked with the given game piece.
     * @param row the row to check.
     * @param col the column to check.
     * @param gamePiece the game piece to check.
     * @return true if the game piece is marked at the given row and column, false otherwise.
     */
    public boolean hasMark(int row, int col, Character gamePiece)
    {
        return this.board[row][col] == gamePiece;
    }

    public boolean hasMark(int row, int col)
    {
        return !this.hasMark(row, col, ' ');
    }

    /**
     * Determine if the game board is full.
     * @return true if the game  board is full, false otherwise.
     */
    public boolean full()
    {
        for (int i = 0; i < board.length; i++)
            for (int j = 0; j < board.length; j++)
                if (!this.hasMark(i, j))
                    return false;

        return true;
    }

    private void drawRowSeparator(PrintStream p, int length)
    {
        for (int i = 0; i < length; i++)
            p.print('-');

        p.println();
    }

    public void drawBoard(PrintStream p)
    {
        for (int i = 0; i < board.length; i++)
        {
            for (int j = 0; j < board.length; j++)
                p.print("| " + board[i][j]);

            p.println();
            drawRowSeparator(p, 11);
        }
    }
}
