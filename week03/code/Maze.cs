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
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
         // Check if the current position exists in the map and whether we can move left
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[0])
        {
            throw new InvalidOperationException("Can't go that way!"); // Error if we hit a wall
        }
        _currX -= 1; // Move left by decreasing X position
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
           // Check if the current position exists in the map and whether we can move right
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[1])
        {
            throw new InvalidOperationException("Can't go that way!"); // Error if we hit a wall
        }
        _currX += 1; // Move right by increasing X position
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        // Check if the current position exists in the map and whether we can move up
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[2])
        {
            throw new InvalidOperationException("Can't go that way!"); // Error if we hit a wall
        }
        _currY -= 1; // Move up by decreasing Y position
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
         // Check if the current position exists in the map and whether we can move down
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[3])
        {
            throw new InvalidOperationException("Can't go that way!"); // Error if we hit a wall
        }
        _currY += 1; // Move down by increasing Y position
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}