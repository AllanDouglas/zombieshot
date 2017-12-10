
using System.Collections.Generic;

namespace Src.Extensions
{
    public static class ListFunctions
    {

        public static IList<T> Shuffle<T>(this IList<T> list)
        {

            T[] newArray = new T[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                int index = UnityEngine.Random.Range(0, list.Count);
                T tmp = list[i];
                newArray[i] = list[index];
                newArray[index] = tmp;

            }
            List<T> newList = new List<T>();
            newList.AddRange(newArray);
            return newList;
        }

        public static T[] Shuffle<T>(this T[] array)
        {
            T[] newArray = new T[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int index = UnityEngine.Random.Range(0, array.Length);
                T tmp = array[i];
                newArray[i] = array[index];
                newArray[index] = tmp;

            }

            return newArray;

        }

    }
}
