using System;
using System.Collections;
using System.Collections.Generic;

public class Cell
{
    //{left, right, top, bottom};
    //false is closed, true is open
    public bool[] sides = { false, false, false, false };
    public int rowIndex;
    public int colIndex;
    public bool visited;
    public Cell(int x, int y)
    {
        rowIndex = x;
        colIndex = y;
        visited = false;
    }
    public void openSide(int sideIndex)
    {
        sides[sideIndex] = true;

    }
}

class Maze
{
    private Random randy = new Random();
    private Stack<Cell> cellPath = new Stack<Cell>();
    private Cell[,] mazeCells;
    private int numOfRows;
    private int numOfCols;
    private int currRow; //current row index of generator
    private int currCol; //current col index of generator

    public Maze(int rowCount, int colCount)
    {
        //Initializes maze size and picks random location
        numOfRows = rowCount;
        numOfCols = colCount;
        mazeCells = new Cell[numOfRows, numOfCols];
        currRow = 0;
        currCol = 0;

        //Generates cell in maze and add onto stack
        mazeCells[currRow, currCol] = new Cell(currRow, currCol);
        cellPath.Push(mazeCells[currRow, currCol]);
    }

    void generateNextCell()
    {
        List<int> validDirections = new List<int>();
        mazeCells[currRow, currCol].visited = true;
        if (currCol + 1 < numOfRows && mazeCells[currRow, currCol + 1].visited == false)
        {
            validDirections.Add(1);
        } //col + 1

        if (currRow + 1 < numOfCols && mazeCells[currRow + 1, currCol].visited == false) //row + 1
            validDirections.Add(3);

        if (validDirections.Count != 0)
        {
            switch (validDirections[randy.Next(validDirections.Count)])
            {
                case 1:
                    mazeCells[currRow, currCol].openSide(1);
                    cellPath.Push(mazeCells[currRow, currCol]);
                    currCol++;//col + 1
                    mazeCells[currRow, currCol] = new Cell(currRow, currCol);
                    mazeCells[currRow, currCol].openSide(0);
                    mazeCells[currRow, currCol].visited = true;
                    break;
                case 3:
                    mazeCells[currRow, currCol].openSide(3);
                    cellPath.Push(mazeCells[currRow, currCol]);
                    currRow++; //row + 1
                    mazeCells[currRow, currCol] = new Cell(currRow, currCol);
                    mazeCells[currRow, currCol].openSide(2);
                    mazeCells[currRow, currCol].visited = true;
                    break;

                default:
                    break;
            }
            generateNextCell();
        }
    }

    public void generateMaze()
    {
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfCols; j++)
            {
                mazeCells[i, j] = new Cell(i, j);
            }
        }
        generateNextCell();
    }

    public override string ToString()
    {
        String mazeString = "+";
        for (int i = 0; i < numOfCols; i++)
        { //upper line
            mazeString += "--+";
        }
        mazeString += "\n|";

        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfCols; j++)
            {
                mazeString += "  ";
                if (mazeCells[i, j].sides[1] == false)
                {
                    mazeString += "|"; //wall
                }
                else
                {
                    mazeString += " "; //no wall
                }
            }
            mazeString += "\n+";

            for (int j = 0; j < numOfCols; j++)
            {
                if (mazeCells[i, j].sides[3] == false)
                {
                    mazeString += "--"; //wall
                }
                else
                {
                    mazeString += "  "; //no wall
                }
                mazeString += "+";
            }

            if (i < numOfRows - 1)
                mazeString += " \n|";

        }
        return mazeString;
    }

}

class Controller
{
    static void returnIntInput(string errorMessage, out int number)
    {
        string input = Console.ReadLine();

        //Repeat error message if input is invalid, if input is valid, TryParse changes number
        while (!(Int32.TryParse(input, out number)))
        {
            Console.WriteLine(errorMessage);
            input = Console.ReadLine();
        }
    }

    static void Main()
    {
        int numOfRowsAndCols;
        Console.Write("Insert number of rows and columns: ");
        returnIntInput("Invalid input. Please enter an integer.", out numOfRowsAndCols);
        Console.WriteLine();

        //Creates empty maze

        Maze maze = new Maze(numOfRowsAndCols, numOfRowsAndCols);
        maze.generateMaze();
        Console.WriteLine(maze);
    }
}