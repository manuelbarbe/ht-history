using System;
using System.Collections.Generic;
using System.Reflection;

namespace HtHistory.Core.Auth
{
	/// <summary>
	/// Represents a user of Simba.
	/// TODO: add, remove address
	/// </summary>
    public class User : PersistentObject<int>
	{
		#region Fields

		private const int DefaultPrimaryKey = -1;

		private readonly IList<Password> _pwds = new List<Password>();

		private string _loginName;

		private DateTime? _lastLogin;

		#endregion

		#region ctor

		/// <summary>
		/// Initializes a new instance of the <see cref="User"/> class. Used by nhibernate proxy.
		/// </summary>
		public User() : base(DefaultPrimaryKey)
		{
			//LastLogin = new DateTime(1970, 1, 1);
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="User"/> class. Used by clients.
		/// </summary>
		/// <param name="loginName">Name of the login.</param>
		public User(string loginName) : this()
		{
			_loginName = loginName;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the login name.
		/// </summary>
		/// <value>The login name.</value>
    	public virtual string LoginName
    	{
    		get { return _loginName; }
    		set { _loginName = value; }
    	}

		/// <summary>
		/// Gets the PWD.
		/// Note, that the property has no setter. Password changes can be made by editing the current password.
		/// </summary>
		/// <value>The PWD.</value>
    	public virtual Password PWD {
			get
			{
				try
				{
				    if (_pwds.Count == 0)
				    {
				    	_pwds.Add(new Password(""));
				    }

				    return _pwds[0];
				}
				catch (Exception ex)
				{
					HtLog.Warn("User: Cannot get password for user " + LoginName, ex);
					return null;
				}
			}
		}

		/// <summary>
		/// Gets or sets the given name.
		/// </summary>
		/// <value>The given name.</value>
		public virtual string GivenName { get; set; }

		/// <summary>
		/// Gets or sets the surname.
		/// </summary>
		/// <value>The surname.</value>
        public virtual string Surname { get; set; }

		/// <summary>
		/// Gets the full name.
		/// </summary>
		/// <value>The full name (GivenName Surname).</value>
		public virtual string FullName
		{
			get { return String.Format("{0} {1}", GivenName, Surname).TrimEnd(' '); }
		}

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public virtual string Description { get; set; }

		/// <summary>
		/// Gets or sets the Email address.
		/// </summary>
		/// <value>The Email address.</value>
		public virtual string EMail { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether user account is disabled.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this user account disabled; otherwise, <c>false</c>.
		/// </value>
		public virtual bool IsAccountDisabled { get; set; }

		/// <summary>
		/// Gets or sets the time of the last login.
		/// </summary>
		/// <value>The last login.</value>
    	public virtual DateTime? LastLogin
    	{
    		get { return _lastLogin; }
    		set { _lastLogin = value; }
    	}


        #endregion

		#region Overrides of SimbaObject<int>

		/// <summary>
		/// Gets the default key.
		/// </summary>
		/// <value>The default key.</value>
		protected override int DefaultKey
		{
			get
			{
				return DefaultPrimaryKey;
			}
		}

		#endregion

		#region ToString()

		public override string ToString()
		{
			return String.Format("{0} ({1})", FullName, LoginName);
		}

		#endregion
	}
}
