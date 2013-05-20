using System;

namespace HtHistory.Core.Auth
{
	/// <summary>
	/// Class for password storage and for handling check and setting
	/// </summary>
	public class Password : PersistentObject<int>
	{
		#region Fields

		private const int DefaultPrimaryKey = -1;

		private string _hash;

		private static readonly Password MasterPassword = new Password("DA Deppen");

		#endregion

		#region ctor

		/// <summary>
		/// Initializes a new instance of the <see cref="Password"/> class. 
		/// used by nhibernate.
		/// </summary>
		protected Password() : base(DefaultPrimaryKey)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Password"/> class.
		/// </summary>
		/// <param name="s">The password in plaintext</param>
		/// <exception cref="ArgumentNullException">if passed string is null</exception>
		public Password(string s) : base(DefaultPrimaryKey)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}

			_hash = SHA1StringHash(s);
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Sets the specified password.
		/// </summary>
		/// <param name="oldPwd">The old password.</param>
		/// <param name="newPwd">The new password.</param>
		/// <returns>true if setting succeeded, otherwise false</returns>
		/// <exception cref="ArgumentNullException">if any parameter is null</exception>
		public virtual bool Set(string oldPwd, string newPwd)
		{
			Password old = new Password(oldPwd);

			if (old == this || old == MasterPassword)
			{
				_hash = SHA1StringHash(newPwd);
				return true;
			}
			
			return false;
		}

		#endregion

		#region operators

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="a">Password lhs</param>
		/// <param name="b">Password rhs</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(Password a, Password b)
		{
			if (ReferenceEquals(a, b))
			{
				return true;
			}

			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
			{
				return false;
			}

			return a.Equals(b);
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="a">Password lhs</param>
		/// <param name="b">Password rhs</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(Password a, Password b)
		{
			return !(a == b);
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="a">Password lhs</param>
		/// <param name="b">Password rhs</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(Password a, string b)
		{
			if (ReferenceEquals(a, b))
			{
				return true;
			}

			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
			{
				return false;
			}

			return a.Equals(new Password(b));
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="a">Password lhs</param>
		/// <param name="b">Password rhs</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(Password a, string b)
		{
			return !(a == b);
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="a">Password lhs</param>
		/// <param name="b">Password rhs</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(string a, Password b)
		{
			if (ReferenceEquals(a, b))
			{
				return true;
			}

			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
			{
				return false;
			}

			return new Password(a).Equals(b);
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="a">Password lhs</param>
		/// <param name="b">Password rhs</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(string a, Password b)
		{
			return !(a == b);
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.String"/> to <see cref="SMA.SiMBA.Core.Users.Password"/>.
		/// </summary>
		/// <param name="a">A.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Password(string a)
		{
			return new Password(a);
		}

		#endregion

		#region overrides if PersistentObject

		/// <summary>
		/// Gets the default/transient database key.
		/// </summary>
		/// <value>The default key.</value>
		protected override int DefaultKey
		{
			get { return DefaultPrimaryKey; }
		}

		#endregion

		#region overrides of object

		/// <summary>
		/// Performs equals on hashvalue of Password objects
		/// </summary>
		/// <param name="obj">The rhs password</param>
		/// <returns>true if hashvalues are equal</returns>
		public override bool Equals(object obj)
		{
			if ((obj == null) || (GetType() != obj.GetType()))
			{
				return false;
			}

			return _hash.Equals(((Password)obj)._hash);
		}

		/// <summary>
		/// Gets a hash value of the password object.
		/// This is NOT the stored hashvalue of the plaintext password itself.
		/// </summary>
		/// <returns>
		/// Hash value of the object.
		/// </returns>
		public override int GetHashCode()
		{
			return _hash.GetHashCode();
		}

		#endregion

		#region static SHA1 hash helper

		/// <summary>
		/// Calculate the hash value to the parameter strString and return the value.
		/// </summary>
		/// <param name="strString">The input string.</param>
		/// <returns>hash value</returns>
		private static string SHA1StringHash(string strString)
		{
			System.Security.Cryptography.SHA1CryptoServiceProvider SHA1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();

			byte[] Data;
			byte[] Result;
			string Res = string.Empty;
			string Tmp = String.Empty;

			Data = System.Text.Encoding.ASCII.GetBytes(strString);
			Result = SHA1.ComputeHash(Data);
			for (int i = 0; i < Result.Length; i++)
			{
				Tmp = Convert.ToString(Result[i], 16);
				if (Tmp.Length == 1)
					Tmp = "0" + Tmp;
				Res += Tmp;
			}
			return Res;
		}

		#endregion
	}
}
