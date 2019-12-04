using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day4
    {
        public object PasswordMeetsCriteria(string password)
        {
            return Is6Digits(password);
        }

        public (int start, int end) GetRange(string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> AsNumbers(string password)
        {
            return password.Select(x => int.Parse(x.ToString()));
        }

        public object Is6Digits(string password)
        {
            return password.Length == 6;
        }

        public object IsWithinRange(string password, (int start, int end) range)
        {
            var passwordAsNumber = int.Parse(password);

            return (passwordAsNumber >= range.start && passwordAsNumber <= range.end);
        }

        public object TwoAdjacentDigitsAreSame(string password)
        {
            throw new NotImplementedException();
        }

        public object DigitsNeverDecrease(string password)
        {
            throw new NotImplementedException();
        }

    }
}
