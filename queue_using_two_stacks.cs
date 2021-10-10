class QueueUsingTwoStacks {
    private readonly Stack<int> enqueueStack;
    private readonly Stack<int> dequeueStack;
    
    public Queue() {
        enqueueStack = new Stack<int>();
        dequeueStack = new Stack<int>();
    }
    
    public void Enqueue(int data) {
        enqueueStack.Push(data);
    }
    
    public int Dequeue() {
        MoveToDequeueStack();
        return dequeueStack.Any() ? dequeueStack.Pop() : -1;
    }
    
    public int Top() {
        MoveToDequeueStack();
        return dequeueStack.Any() ? dequeueStack.Peek() : -1;
    }
    
    private void MoveToDequeueStack() {
        if(!dequeueStack.Any()) {
            while(enqueueStack.Any()) {
                dequeueStack.Push(enqueueStack.Pop());
            }    
        }
    }
}