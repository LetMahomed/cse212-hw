using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities, then dequeue all.
    // Expected Result: Dequeue returns items in order of highest priority first, 
    // and among same priority, first inserted item first (FIFO).
    // Defect(s) Found: 0
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("medium1", 5);
        priorityQueue.Enqueue("medium2", 5);
        priorityQueue.Enqueue("high", 10);

        Assert.AreEqual("high", priorityQueue.Dequeue());     
        Assert.AreEqual("medium1", priorityQueue.Dequeue());  
        Assert.AreEqual("medium2", priorityQueue.Dequeue());  
        Assert.AreEqual("low", priorityQueue.Dequeue());     

        // Check exception on empty queue
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with same priority, then dequeue all.
    // Expected Result: Dequeue returns items in FIFO order as priorities are equal.
    // Defect(s) Found: 0
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("1", 3);
        priorityQueue.Enqueue("2", 3);
        priorityQueue.Enqueue("3", 3);

        Assert.AreEqual("1", priorityQueue.Dequeue());
        Assert.AreEqual("2", priorityQueue.Dequeue());
        Assert.AreEqual("3", priorityQueue.Dequeue());
        

        // check exception on empty queue
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

}
