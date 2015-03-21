#region License

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

using System;
using System.Runtime.Serialization;

namespace DevDefined.OAuth.Framework
{
	public class OAuthException : Exception
	{
		public OAuthException()
		{
		}

		public OAuthException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public OAuthException(IOAuthContext context, string problem, string advice) : base(advice)
		{
			Context = context;
			Report = new OAuthProblemReport {Problem = problem, ProblemAdvice = advice};
		}

		public OAuthException(IOAuthContext context, string problem, string advice, Exception innerException)
			: base(advice, innerException)
		{
			Context = context;
			Report = new OAuthProblemReport {Problem = problem, ProblemAdvice = advice};
		}

		public OAuthException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public OAuthProblemReport Report { get; set; }
		public IOAuthContext Context { get; set; }
	}
}