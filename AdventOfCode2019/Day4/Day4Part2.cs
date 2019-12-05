namespace AdventOfCode2019.Day4
{
    public class Day4Part2 : Day4Part1
    {
        public override bool PasswordMeetsCriteria(string password)
        {
            return this.Is6Digits(password)
                   && this.DigitsNeverDecrease(password)
                   && this.TwoAdjacentDigitsAreSameButNotPartOfALargerGroup(password);
        }

        public bool TwoAdjacentDigitsAreSameButNotPartOfALargerGroup(string password)
        {
            var passwordAsNumbers = this.AsNumbers(password);

            int currentNumber = 0;
            bool twoAdjacentDigitsAreSameButNotPartOfALargerGroup = false;

            foreach (var number in passwordAsNumbers)
            {
                if (number == currentNumber && !password.Contains($"{number}{number}{number}"))
                {
                    twoAdjacentDigitsAreSameButNotPartOfALargerGroup = true;
                    break;
                }

                currentNumber = number;
            }

            return twoAdjacentDigitsAreSameButNotPartOfALargerGroup;
        }
    }
}
