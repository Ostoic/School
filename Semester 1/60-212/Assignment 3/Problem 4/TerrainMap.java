package com.company;


import java.awt.*;
import java.io.PrintStream;

/**
 * TerrainMap represents the height map of a terrain.
 */
public class TerrainMap
{
    // Grid of terrain levels.
    int[][] grid;

    /**
     * Construct a TerrainMap object whose grid is 'size'x'size'.
     * @param size the length and width of the terrain grid.
     */
    TerrainMap(int size)
    {
        this.grid = new int[size][size];
    }

    /**
     * Get the height of the lowest point in the terrain
     * @return height of the lowest point.
     */
    public int getLowestHeight()
    {
        int lowest = this.grid[0][0];
        for (int i = 0; i < this.grid.length; i++)
        {
            for (int j = 0; j < this.grid.length; j++)
            {
                if (this.grid[i][j] <= lowest)
                    lowest = this.grid[i][j];
            }
        }

        return lowest;
    }

    /**
     * Get the height of the highest point in the terrain
     * @return height of the highest point.
     */
    public int getHighestHeight()
    {
        int highest = this.grid[0][0];
        for (int i = 0; i < this.grid.length; i++)
        {
            for (int j = 0; j < this.grid.length; j++)
            {
                if (this.grid[i][j] >= highest)
                    highest = this.grid[i][j];
            }
        }

        return highest;
    }

    /**
     * Set the terrain.
     * @param terrain the array of water levels to set as our terrain.
     */
    public void setTerrain(int[][] terrain)
    {
        this.grid = terrain;
    }

    /**
     * Determine if the given point is flooded or not.
     * @param x the row of the terrain point.
     * @param y the column of the terrain point.
     * @param waterLevel the level of water to consider.
     * @return true if the terrain point is flooded, false otherwise.
     */
    private boolean isTerrainPointFlooded(int x, int y, int waterLevel)
    {
        return this.grid[x][y] < waterLevel;
    }

    /**
     * Converts the given terrain point to a character representing its point on the flood map.
     * @param x the row of the point.
     * @param y the column of the point.
     * @param waterLevel the level of water to consider.
     * @return its Character representation of whether it is flooded or not.
     */
    private Character getFloodPointChar(int x, int y, int waterLevel)
    {
        if (isTerrainPointFlooded(x, y, waterLevel))
            return '*';
        else
            return '-';
    }

    /**
     * Print out a floodmap to the given PrintStream
     * @param p the PrintStream object to write to.
     * @param waterLevel the level of water to consider.
     */
    public void printFloodMap(PrintStream p, int waterLevel)
    {
        for (int i = 0; i < this.grid.length; i++)
        {
            for (int j = 0; j < this.grid.length; j++)
            {
                p.print(getFloodPointChar(i, j, waterLevel) + " " );
            }

            p.println();
        }
    }

}
