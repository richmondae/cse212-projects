using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them to ensure correct ordering.
    // Expected Result: Items should be dequeued and removed in the order of their priorities.
    // Defect(s) Found: None
    public void TestPriorityQueue_EnqueueDifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        
        Console.WriteLine("Test 1: Enqueue items with different priorities and dequeue them");
        
        // Enqueue items with different priorities
        Console.WriteLine("Enqueuing Task A with priority 3");
        priorityQueue.Enqueue("Task A", 3);
        Console.WriteLine("Enqueuing Task B with priority 1");
        priorityQueue.Enqueue("Task B", 1);
        Console.WriteLine("Enqueuing Task C with priority 2");
        priorityQueue.Enqueue("Task C", 2);
        
        // Check the dequeue order based on priority
        Console.WriteLine("Dequeuing Task...");
        Assert.AreEqual("Task A", priorityQueue.Dequeue(), "Expected 'Task A' (priority 3) to be dequeued first.");
        Console.WriteLine("Dequeued Task A");
        
        Console.WriteLine("Dequeuing Task...");
        Assert.AreEqual("Task C", priorityQueue.Dequeue(), "Expected 'Task C' (priority 2) to be dequeued second.");
        Console.WriteLine("Dequeued Task C");
        
        Console.WriteLine("Dequeuing Task...");
        Assert.AreEqual("Task B", priorityQueue.Dequeue(), "Expected 'Task B' (priority 1) to be dequeued last.");
        Console.WriteLine("Dequeued Task B");
        
        // Check dequeue from an empty queue
        Console.WriteLine("Dequeuing from an empty queue...");
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "Expected an exception when dequeuing from an empty queue.");
        Console.WriteLine("Expected exception thrown.");
        
        Console.WriteLine("---------");
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority and dequeue them to verify FIFO behavior for items with equal priorities.
    // Expected Result: Items should be dequeued in the order they were enqueued (FIFO).
    // Defect(s) Found: None
    public void TestPriorityQueue_EnqueueSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        
        Console.WriteLine("Test 2: Enqueue items with the same priority and dequeue them");

        // Enqueue items with the same priority
        Console.WriteLine("Enqueuing Task 1 with priority 2");
        priorityQueue.Enqueue("Task 1", 2);
        Console.WriteLine("Enqueuing Task 2 with priority 2");
        priorityQueue.Enqueue("Task 2", 2);
        Console.WriteLine("Enqueuing Task 3 with priority 2");
        priorityQueue.Enqueue("Task 3", 2);
        
        // Check that items are dequeued in the order they were enqueued (FIFO)
        Console.WriteLine("Dequeuing Task...");
        Assert.AreEqual("Task 1", priorityQueue.Dequeue(), "Expected 'Task 1' to be dequeued first.");
        Console.WriteLine("Dequeued Task 1");

        Console.WriteLine("Dequeuing Task...");
        Assert.AreEqual("Task 2", priorityQueue.Dequeue(), "Expected 'Task 2' to be dequeued second.");
        Console.WriteLine("Dequeued Task 2");

        Console.WriteLine("Dequeuing Task...");
        Assert.AreEqual("Task 3", priorityQueue.Dequeue(), "Expected 'Task 3' to be dequeued last.");
        Console.WriteLine("Dequeued Task 3");
        
        // Check dequeue from an empty queue
        Console.WriteLine("Dequeuing from an empty queue...");
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "Expected an exception when dequeuing from an empty queue.");
        Console.WriteLine("Expected exception thrown.");
        
        Console.WriteLine("---------");
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException.
    // Defect(s) Found: None
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        
        Console.WriteLine("Test 3: Attempt to dequeue from an empty queue");

        // Expect an exception when trying to dequeue from an empty queue
        Console.WriteLine("Attempting to dequeue...");
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "Expected an exception when dequeuing from an empty queue.");
        Console.WriteLine("Expected exception thrown.");
        
        Console.WriteLine("---------");
    }
}
