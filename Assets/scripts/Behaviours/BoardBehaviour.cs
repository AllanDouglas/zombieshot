using Src.Game;
using Src.Interfaces;
using UnityEngine;

namespace Behavious
{

    public class BoardBehaviour : MonoBehaviour
    {

        private IBoard<IItem, int> board = new CircleBoard();

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}