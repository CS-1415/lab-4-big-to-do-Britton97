public class Task
{
    private string title = "empty";
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    private CompletionStatus _status;
    public CompletionStatus Status
    {
        get { return _status; }
        set { _status = value; }
    }

    public Task(string title)
    {
        this.title = title;
        _status = CompletionStatus.NotDone;
    }

    public void SetTitle(string title)
    {
        this.title = title;
    }

    public void ToggleStatus()
    {
        if (_status == CompletionStatus.NotDone)
        {
            _status = CompletionStatus.Done;
        }
        else
        {
            _status = CompletionStatus.NotDone;
        }
    }
}

public enum CompletionStatus
{
    NotDone,
    Done
}