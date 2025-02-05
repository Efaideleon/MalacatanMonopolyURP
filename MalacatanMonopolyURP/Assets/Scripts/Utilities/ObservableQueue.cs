using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;

public class ObservableQueue<T> : INotifyCollectionChanged
{
    private readonly Queue<T> _queue = new Queue<T>();

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    public int Count => _queue.Count;

    public void Enqueue(T element)
    {
        _queue.Enqueue(element); 
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, element));
    }

    public T Dequeue()
    {
        T element = _queue.Dequeue();
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, element, 0));
        return element;
    }

    public void Clear()
    {
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    public T Peek()
    {
        return _queue.Peek();
    }

    public IEnumerator<T> GetEnumerator() => _queue.GetEnumerator();
}
