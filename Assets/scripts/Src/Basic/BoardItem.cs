using Src.Interfaces;

namespace Src.Basic
{
    public abstract class BoardItem : IItem
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
