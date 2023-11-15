using System.Collections;
using System.Collections.Generic;

public class PauseManager
{
    public bool paused;
    private static PauseManager _instance;
    public static PauseManager Instance()
    {
        if (_instance == null)
        {
            _instance = new PauseManager();
            _instance.paused = false;
        }
        return _instance;
    }
}
