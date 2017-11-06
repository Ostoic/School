package com.company;

import java.util.Scanner;

public class TicTacToeTester
{
    public static void main(String[] args)
    {
        Scanner in = new Scanner(System.in);
        TicTacToe game = new TicTacToe('O', 'X');

        // Loop while all game over conditions are not true.
        while (!game.gameOver())
        {
            // Redraw the game board
            game.drawGame(System.out);

            // Get point to mark on the game board for the current player.
            System.out.println("Player " + game.getCurrentPlayer() + "'s turn.");
            System.out.print("Enter row to mark: ");
            int row = in.nextInt();

            System.out.print("Enter column to mark: ");
            int col = in.nextInt();

            // Mark the point on the game board.
            if (!game.playerMark(row, col))
            {
                // If the point is already marked, try again.
                System.out.println("Error: Position already marked!");
                continue;
            }
        }

        // Display the winner of the game.
        System.out.println("Game over.");
        if (game.hasPlayerWon('O'))
            System.out.println("Player 1 has won with O's!");
        else if (game.hasPlayerWon('X'))
            System.out.println("Player 2 has won with X's!");
    }
}
