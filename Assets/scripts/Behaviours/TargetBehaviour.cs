using UnityEngine;
using Src.Game;
using Src.Interfaces;

public class TargetBehaviour : MonoBehaviour
{
    #region Inspector
    [SerializeField]
    private int speed;
    [SerializeField]
    private int range;
    #endregion
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector2.zero, Vector3.forward, speed * Time.deltaTime);
        Debug.Log(this.GetLookPosition());
    }

    int GetLookPosition()
    {

        int angle = Mathf.RoundToInt(Vector2.Angle(transform.right, Vector2.right));

        if (transform.position.y < 0)
        {
            angle = 360 - angle;
        }

        return angle;

    }
}
