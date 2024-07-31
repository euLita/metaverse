using UnityEngine;

public class Wall : MonoBehaviour
{

    public bool backWall;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter (Collider other)
    {
        if (other.name.Contains ("Ball"))
        {
            if (backWall) GameController.Instance.CountPins();
            Destroy(other.gameObject);
            GameController.Instance.Spawn();
        }
    }
}
