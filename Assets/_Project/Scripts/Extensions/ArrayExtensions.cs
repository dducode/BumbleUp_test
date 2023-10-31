namespace BumbleUp.Extensions {

    public static class ArrayExtensions {

        /// <summary>
        /// Moves all array elements forward
        /// </summary>
        public static void MoveForward<T> (this T[] array) {
            T first = array[0];
            for (var i = 0; i < array.Length - 1; i++)
                array[i] = array[i + 1];
            array[array.Length - 1] = first;
        }

    }

}