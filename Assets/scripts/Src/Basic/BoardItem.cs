using Src.Interfaces;

namespace Src.Basic
{
    public class BoardItem : IItem
    {

        public int Range
        {
            get;
            private set;
        }


        public BoardItem(int range)
        {
            this.Range = range;
        }


    }
}
