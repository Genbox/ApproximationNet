# Approximation.NET - An implementation of approximations to common trigonometric functions

### Features

* Sine and cosine approximations using polynominals with both low and high precisions.
* Sine approximation using Taylor series
* Fast inverse square root (1/sqrt()) function using smart bitshifting
* All written in C#

### Examples

```csharp
static void Main(string[] args)
{
	float realInvSqrt = (float)(1 / Math.Sqrt(5));
	float approxInvSqrt = Approximation.InvSqrt(5);

	Console.WriteLine("Real: " + realInvSqrt);
	Console.WriteLine("Approximated: " + approxInvSqrt);
}
```

Output:
```
Real: 0.4472136
Approximated: 0.447141
```

For more examples, take a look at the Approximation.NET Client included in the proejct.