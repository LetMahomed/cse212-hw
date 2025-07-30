/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private Dictionary<(int, int), bool[]> maze;
    private (int x, int y) currentLocation;

    public Maze(Dictionary<(int, int), bool[]> maze)
    {
        this.maze = maze;
        this.currentLocation = (0, 0);
    }

    public (int, int) GetCurrentLocation()
    {
        return currentLocation;
    }

    public void MoveLeft()
    {
        if (!maze.TryGetValue(currentLocation, out bool[] moves))
            throw new InvalidOperationException("Current location is invalid.");
        var newLocation = (currentLocation.x - 1, currentLocation.y);

        if (moves.Length < 4 || !moves[0] || !maze.ContainsKey(newLocation))
            throw new InvalidOperationException("Invalid left move.");

        currentLocation = newLocation;
    }

    public void MoveRight()
    {
        if (!maze.TryGetValue(currentLocation, out bool[] moves))
            throw new InvalidOperationException("Current location is invalid.");
        var newLocation = (currentLocation.x + 1, currentLocation.y);

        if (moves.Length < 4 || !moves[1] || !maze.ContainsKey(newLocation))
            throw new InvalidOperationException("Invalid right move.");

        currentLocation = newLocation;
    }

    public void MoveUp()
    {
        if (!maze.TryGetValue(currentLocation, out bool[] moves))
            throw new InvalidOperationException("Current location is invalid.");
        var newLocation = (currentLocation.x, currentLocation.y - 1);

        if (moves.Length < 4 || !moves[2] || !maze.ContainsKey(newLocation))
            throw new InvalidOperationException("Invalid up move.");

        currentLocation = newLocation;
    }

    public void MoveDown()
    {
        if (!maze.TryGetValue(currentLocation, out bool[] moves))
            throw new InvalidOperationException("Current location is invalid.");
        var newLocation = (currentLocation.x, currentLocation.y + 1);

        if (moves.Length < 4 || !moves[3] || !maze.ContainsKey(newLocation))
            throw new InvalidOperationException("Invalid down move.");

        currentLocation = newLocation;
    }
    public (bool left, bool right, bool up, bool down) GetStatus()
    {
        if (!maze.TryGetValue(currentLocation, out bool[] moves))
            throw new InvalidOperationException("Current location is invalid.");
            if (moves.Length < 4)
            throw new InvalidOperationException("Invalid moves array length.");
        return (moves[0], moves[1], moves[2], moves[3]);
    }
        public void Reset()
        {
            currentLocation = (0, 0);
        }
}
