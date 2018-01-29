package com.company;

public class TerrainMapTester
{
    public static void main(String[] args)
    {
        // Create a new 4x4 TerrainMap.
        TerrainMap terrain = new TerrainMap(4);

        // Heights of terrain points in the grid.
        int heights[][] = {
                {9, 9, 3, 7},
                {6, 3, 9, 9},
                {11, 23, 12, 11},
                {5, 7, 0, 10}
        };

        // Set the grid of terrain heights.
        terrain.setTerrain(heights);

        // Print the flood map for the given terrain.
        terrain.printFloodMap(System.out, 5);

        // Expected flood map for waterLevel = 5.
        String floodMap =
                "- - * -\n" +
                        "- * - -\n" +
                        "- - - -\n" +
                        "- - * -\n";

        // Print the expected flood map when waterLevel = 5.
        System.out.println("Expected flood map: ");
        System.out.print(floodMap);
    }
}
