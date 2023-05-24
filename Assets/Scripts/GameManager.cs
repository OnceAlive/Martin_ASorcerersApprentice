using System.IO;

class GameManager : MonoBehaviour
{
    public GameManager INSTANCE;

    private static const string PATH = "";
    
    private void Awake()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
        }
    }

    public bool Load()
    {
        using(StreamReader sr = new StreamReader(PATH))
        {

        }
        return true;
    }

    public bool Save()
    {
        using(StreamWriter sw = new StreamWriter(PATH))
        {

        }
        return true;
    }
}