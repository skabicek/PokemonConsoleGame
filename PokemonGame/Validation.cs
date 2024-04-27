
namespace HW01_2024
{
    public class Validation
    {
        public static bool SelectionIsValid(string[] userInput, int pokemonCount)
        {
            if (userInput.Length != 3)
                return false;

            var uniqueSet = new HashSet<int>();

            foreach (var index in userInput)
            {
                if (!(int.TryParse(index, out int idx) && idx > 0 && idx <= pokemonCount) ||
                    uniqueSet.Contains(idx))
                {
                    return false;
                }
                uniqueSet.Add(idx);
            }
            return true;
        }
    }
}
