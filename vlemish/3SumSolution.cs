namespace _3Sum
{
    public class _3SumSolution
    {
        // The easiest way to solve the problem is to decrease problem to 2Sum problem
        // we can do it by creating a dictionary with elements for which we're going to search further.
        public IList<IList<int>> FindTriples(int[] nums)
        {
            // if length is less than 3 -> no triples can be found
            if (nums.Length < 3)
            {
                return new List<IList<int>>();
            }

            List<Tripple> tripples = new List<Tripple>();

            // create dictionary with elements to search
            Dictionary<int, int> numsDictionary = new();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!numsDictionary.ContainsKey(nums[i]))
                {
                    numsDictionary.Add(nums[i], i);
                }
            }

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    // get a sum of addition i + j and change sign, so we can find an element that will give us 0 as a result
                    int sum = (nums[i] + nums[j]) * -1;
                    // if dictionary contains the element than 3sum is found
                    if (numsDictionary.ContainsKey(sum))
                    {
                        var tripple = new Tripple(nums[i], nums[j], sum);
                        // verify the element isn't a duplicate and that the condition i!=j && i!=k && j!=k is valid
                        if (!tripples.Contains(tripple) && i != numsDictionary[sum] && j != numsDictionary[sum])
                        {
                            tripples.Add(tripple);
                        }
                    }
                }
            }

            return tripples.Select(t => t.ToList()).ToList();
        }
    }

    public struct Tripple : IEquatable<Tripple>
    {
        public int I { get; }

        public int J { get; }

        public int K { get; }

        public Tripple(int i, int j, int k)
        {
            I = i;
            J = j;
            K = k;
        }

        public IList<int> ToList() =>
            new List<int> { I, J, K };

        public bool Equals(Tripple other) =>
            (this.I == other.I || this.I == other.J || this.I == other.K)
            && (this.J == other.J || this.J == other.K || this.J == other.I)
            && (this.K == other.K || this.K == other.J || this.K == other.I);

        public override string ToString()
        {
            return $"[{this.I}, {this.J}, {this.K}]";
        }
    }
}
