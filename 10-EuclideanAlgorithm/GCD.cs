namespace Codility
{
	// Different methods to find the GCD (Greatest
	// Common Divisor) of two numbers. From
	// least to most efficient

	public class Gcd
	{
		public int GcdSubstract(int a, int b)
		{
		    if (a == b) {
			    return a;
			}

		    return a > b ? 
                this.GcdSubstract(a - b, b) :
                this.GcdSubstract(a, b - a);
		}

	    public int GcdModulo(int a, int b)
	    {
	        if (a % b == 0) {
				return b;
			}

	        return this.GcdModulo(b, a % b);
	    }

	    public	int GcdBinary(int a, int b, int res)
	    {
	        if (a == b) {
				return a * res;
			}

	        if (a % 2 == 0 && b % 2 == 0) {
	            return this.GcdBinary(a / 2, b / 2, 2 * res);
	        }

	        if (a % 2 == 0) {
	            return this.GcdBinary(a / 2, b, res);
	        }

	        if (b % 2 == 0) {
	            return this.GcdBinary(a, b / 2, res);
	        }

	        return a > b ? 
                this.GcdBinary(a - b, b, res) : 
                this.GcdBinary(a, b - a, res);
	    }
	}
}

