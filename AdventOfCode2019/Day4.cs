using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day4
    {
        public bool PasswordMeetsCriteria(string password)
        {
            return this.Is6Digits(password)
                   && this.DigitsNeverDecrease(password)
                   && this.TwoAdjacentDigitsAreSame(password);
        }

        public (int start, int end) GetRange(string rangeInput)
        {
            var rangeParts = rangeInput
                .Split("-")
                .Select(Int32.Parse)
                .ToArray();

            return (start: rangeParts[0], end: rangeParts[1]);
        }

        public IEnumerable<int> AsNumbers(string password)
        {
            return password.Select(x => int.Parse(x.ToString()));
        }

        public bool Is6Digits(string password)
        {
            return password.Length == 6;
        }

        public object IsWithinRange(string password, (int start, int end) range)
        {
            var passwordAsNumber = int.Parse(password);

            return (passwordAsNumber >= range.start && passwordAsNumber <= range.end);
        }

        public bool TwoAdjacentDigitsAreSame(string password)
        {
            // TODO: Implement
            return true;
        }

        public bool DigitsNeverDecrease(string password)
        {
            // TODO: Implement
            return true;
        }

        public IEnumerable<string> GetPossiblePasswords(string puzzleInput)
        {
            var range = this.GetRange(puzzleInput);
            return this.GetPossiblePasswords(range);
        }

        public IEnumerable<string> GetPossiblePasswords((int start, int end) range)
        {
            for (int i = range.start; i < range.end; i++)
            {
                var password = i.ToString();

                var isValid = this.PasswordMeetsCriteria(password);

                if (isValid)
                {
                    yield return password;
                }
            }
        }
    }
}
