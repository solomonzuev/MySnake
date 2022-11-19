namespace StructuresLibrary
{
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public DoublyNode<T> Next { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public T Data { get; set; }
    }
}