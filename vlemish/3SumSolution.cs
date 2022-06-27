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

            Array.Sort(nums);

            List<Tripple> tripples = new List<Tripple>();

            // create dictionary with elements to search
            Dictionary<int, int> numsDictionary = new();

            // use pointers to decrease number of iterations
            // take the first element and add it to dictionary and then use this element to find couple of elements which will give us 0
            for (int i = 1; i < nums.Length - 1; i++)
            {
                var k = i - 1;
                if (!numsDictionary.ContainsKey(nums[k]))
                {
                    numsDictionary.Add(nums[k], k);
                }

                for (int j = i + 1; j < nums.Length; j++)
                {
                    // get a sum of addition i + j and change sign, so we can find an element that will give us 0 as a result
                    int sum = (nums[i] + nums[j]) * -1;
                    // if dictionary contains the element than 3sum is found
                    if (numsDictionary.ContainsKey(sum))
                    {
                        var tripple = new Tripple(nums[i], nums[j], sum);
                        // verify the element isn't a duplicate and that the condition i!=j && i!=k && j!=k is valid
                        if (i != numsDictionary[sum] && j != numsDictionary[sum] && !tripples.Contains(tripple))
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
            this.I == other.I && this.J == other.J && this.K == other.K;


        public override string ToString()
        {
            return $"[{this.I}, {this.J}, {this.K}]";
        }
    }
}
