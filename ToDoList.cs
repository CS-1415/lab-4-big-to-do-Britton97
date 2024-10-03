public class TodoList
{
    public List<Task> _tasks = new List<Task>();
    public int _selectedTaskIndex = 0;

    public Task CurrentTask
    {
        get
        {
            return _tasks[_selectedTaskIndex];
        }
    }

    public int Length
    {
        get { return _tasks.Count; }
    }

    public void SwapTasksAt(int i, int j)
    { //given two ints, swaps the tasks at those indices
        //no need to check if i or j are out of bounds, since they are only called from other methods that do the bounds checking
        Task temp = _tasks[i];
        _tasks[i] = _tasks[j];
        _tasks[j] = temp;
    }

    public void WrappedIndex(int i)
    {
        //simple method to wrap the index around the list if the index is out of bounds
        //either negative or greater than the length of the list
        if (i < 0)
        {
            _selectedTaskIndex = _tasks.Count - 1;
        }
        else if (i >= _tasks.Count)
        {
            _selectedTaskIndex = 0;
        }
        else
        {
            _selectedTaskIndex = i;
        }
    }

    public int PreviousIndex()
    {
        return _selectedTaskIndex - 1;
    }

    public int NextIndex()
    {
        return _selectedTaskIndex + 1;
    }

    public void SelectPrevious()
    {
        WrappedIndex(PreviousIndex());
    }

    public void SelectNext()
    {
        WrappedIndex(NextIndex());
    }

    public void SwapWithPrevious()
    {
        if (_selectedTaskIndex > 0)
        {
            SwapTasksAt(_selectedTaskIndex, PreviousIndex());
            SelectPrevious();
        }
    }

    public void SwapWithNext()
    {
        //this doesnt quite work. I would like to store the task i want to switch
        //right now it just switches the selected task with the next one
        //the user shouldn't see the option to push a direction that will not work
        //i.e. if you are on the last task and you press right it does nothing
        //you would have to keep swapping tasks one by one until you get to the one you want to switch
        //I would have to add a variable to store the task I selected.
        //then be in a state where the script is waiting for a new index to swap with
        //then swap the selected task with the task at the index I selected
        //I'm not sure I want to add this right now but it would make the app more user friendly
        //I would have to add some boolean variables to keep track of the state of the app
        //but that would add bloat to the script
        //to make it work well I would need to make some state classes.
        //those could handle input. I would have to make a class for each state
        //it would also clean up the ProcessUserInput method by letting the ToDoList class
        //not care about inputs. It would just call the state class to handle the input
        //that seems like a lot of work though and i'm tired
        if (_selectedTaskIndex < _tasks.Count - 1)
        {
            SwapTasksAt(_selectedTaskIndex, NextIndex());
            SelectNext();
        }
    }

    public void Insert(string title)
    {
        _tasks.Add(new Task(title));
    }

    //this is never called enough the design doc says to use this method
    public void UpdateSelectedTitle(string title)
    {
        _tasks[_selectedTaskIndex].SetTitle(title);
    }

    public void DeleteSelected()
    {
        if (_tasks.Count > 0)
        {
            _tasks.RemoveAt(_selectedTaskIndex);
            if (_selectedTaskIndex >= _tasks.Count)
            {
                _selectedTaskIndex = _tasks.Count - 1;
            }
        }
    }

    public Task GetTask(int i)
    {
        return _tasks[i];
    }
}