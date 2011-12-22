﻿#region License

// The MIT License
//
// Copyright (c) 2006-2008 DevDefined Limited.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#endregion

using System.Diagnostics;
using System.Linq;
using DevDefined.OAuth.Utility;
using Xunit;
using Xunit.Extensions;

namespace DevDefined.OAuth.Tests.Utility
{
	public class StringUtilityTests
	{
		[Fact]
		public void EqualsInConstantTime_ComparesInConstantTimeRegardlessOfPercentMatch_ToWithinMarginOfError()
		{
			const int length = 10*1024; // 10K characters - big enough to avoid wild fluctuations in timing

			const int numberOfTimestoCompare = 10000;

			string value = GenerateTestString(1.0, length);

			long[] rangesOfTime = Enumerable.Range(0, 100)
				.Select(range => GenerateTestString((range/100.0), length)).ToArray()
				.Select(other => TimeCompareValuesOverIterationsConstantTime(value, other, numberOfTimestoCompare))
				.ToArray();

			long[] stringEqualsRangesOfTime = Enumerable.Range(0, 100)
				.Select(range => GenerateTestString((range/100.0), length)).ToArray()
				.Select(other => TimeCompareValuesOverIterationsStringEquals(value, other, numberOfTimestoCompare))
				.ToArray();

			decimal percentDifference = CalculatePercentageDifference(rangesOfTime);

			decimal percentDifferenceStringEquals = CalculatePercentageDifference(stringEqualsRangesOfTime);

			Assert.True(percentDifference < 0.50m, string.Format("Difference in time when calculating is never greater then 50%, but was: {0:0.00%}", percentDifference));

			// if you break here and check values, you should see that percentDifferenceStringEquals is dramatically wider i.e. maximum time to compare may be 100 times greater
			// then minimum time to compare.

			Assert.True(percentDifferenceStringEquals > percentDifference);
		}

		[Theory]
		[InlineData("XY", "XY")]
		[InlineData("42", "42")]
		[InlineData("YX", "XY")]
		[InlineData("Y", "Y")]
		[InlineData("Y", "X")]
		[InlineData("X", "Y")]
		[InlineData("Xy", "XY")]
		[InlineData("yX", "yX")]
		[InlineData("XY", "Y")]
		[InlineData("X", "XY")]
		[InlineData("X", "")]
		[InlineData("", "X")]
		[InlineData(null, "XY")]
		[InlineData("XY", null)]
		[InlineData(null, null)]
		[InlineData("", null)]
		[InlineData(null, "")]
		[InlineData("", "")]
		public void EqualsInConstantTime_ReturnsSameResults_AsStringEquals(string value, string other)
		{
			bool expected = string.Equals(value, other);
			Assert.Equal(expected, value.EqualsInConstantTime(other));
		}

		static string GenerateTestString(double percentMatch, int length)
		{
			var matchLength = (int) (percentMatch*length);
			int nonMatchLength = length - matchLength;

			if (nonMatchLength == 0) return new string('X', length);

			return new string('X', matchLength) + new string('Y', nonMatchLength);
		}

		static decimal CalculatePercentageDifference(long[] rangesOfTime)
		{
			long maxTime = rangesOfTime.Max();

			long minTime = rangesOfTime.Min();

			return 1.0m - ((1.0m/maxTime)*minTime);
		}

		public long TimeCompareValuesOverIterationsConstantTime(string value, string other, int iterations)
		{
			Stopwatch stopWatch = Stopwatch.StartNew();

			for (int i = 0; i < iterations; i++)
			{
				value.EqualsInConstantTime(other);
			}

			return stopWatch.ElapsedTicks;
		}

		public long TimeCompareValuesOverIterationsStringEquals(string value, string other, int iterations)
		{
			Stopwatch stopWatch = Stopwatch.StartNew();

			for (int i = 0; i < iterations; i++)
			{
				value.Equals(other);
			}

			return stopWatch.ElapsedTicks;
		}
	}
}