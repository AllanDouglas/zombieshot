
using System.Collections.Generic;

namespace Src.Extensions
{
    public static class ListFunctions
    {

        public static T First<T>(this T[] list)
        {
            return list[0];
        }

        public static T Last<T>(this T[] list)
        {
            return list[list.Length - 1];
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
