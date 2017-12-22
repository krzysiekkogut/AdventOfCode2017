using System.Linq;

namespace Day21_FractalArt
{
    internal static class Transformations
    {
        public static string FlipVertical(this string ruleInput)
        {
            return string.Join("/", ruleInput.Split('/').Reverse());
        }

        public static string Rotate(this string ruleInput)
        {
            var rows = ruleInput.Split('/');
            var newRows = new char[rows.Length][];
            for (int i = 0; i < newRows.Length; i++)
            {
                newRows[i] = new char[rows.Length];
            }

            for (int i = 0; i < newRows.Length; i++)
            {
                for (int j = 0; j < newRows.Length; j++)
                {
                    newRows[i][j] = rows[j][newRows.Length - 1 - i];
                }
            }

            return string.Join("/", newRows.Select(row => string.Concat(row)));
        }
    }
}
