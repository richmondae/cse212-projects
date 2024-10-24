public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
       // If the value is less than the current node's data, insert it to the left subtree
        if (value < Data)
        {
            if (Left is null) 
                Left = new Node(value); // No left child, insert here
            else 
                Left.Insert(value); // Recur down the left subtree
        }
        // Otherwise, insert it to the right subtree
        else if (value > Data)
        {
            if (Right is null) 
                Right = new Node(value); // No right child, insert here
            else 
                Right.Insert(value); // Recur down the right subtree
        }
        // If value is equal, we do nothing (no duplicates allowed)
    }


    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true; // Found it!
        }
        else if (value < Data && Left is not null)
        {
            return Left.Contains(value); // Go left to search
        }
        else if (value > Data && Right is not null)
        {
            return Right.Contains(value); // Go right to search
        }
        return false; // Value not found
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // return 0; // Replace this line with the correct return statement(s)
        if (this == null) 
        {
            return 0; // Empty tree, height is zero
        }

        int leftHeight = (Left == null) ? 0 : Left.GetHeight();
        int rightHeight = (Right == null) ? 0 : Right.GetHeight();

        // Return height of the current node
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}