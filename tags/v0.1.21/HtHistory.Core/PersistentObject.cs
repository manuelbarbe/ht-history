using System;
using System.Text;

namespace HtHistory.Core
{
	/// <summary>
	/// The base class of all persistent objects.
	/// </summary>
	/// <typeparam name="TKeyType">The type of the key type.</typeparam>
	public abstract class PersistentObject<TKeyType>
		where TKeyType : IEquatable<TKeyType>
	{
		#region Fields

		/// <summary>
		/// Holds the database primary key value.
		/// </summary>
		private TKeyType _dbKey;
		private int _dbRevision;

		private Guid _guid;

		private DateTime _lastChange;
		private Auth.User _lastuser;

		private DateTime _created;
		private Auth.User _creator;

		private Auth.User _editingUser;

		#endregion

		#region ctor

		/// <summary>
		/// Initializes a new instance of the <see cref="DbObject&lt;TKeyType&gt;"/> class.
		/// </summary>
		/// <param name="initialDbKey">The initial db key.</param>
		protected PersistentObject(TKeyType initialDbKey)
		{
			_dbKey = initialDbKey;
			_created = DateTime.Now.ToUniversalTime();
			_lastChange = _created;
			_guid = Guid.NewGuid();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the identifier of object in repository.
		/// </summary>
		/// <value>The db key.</value>
		public virtual TKeyType DbKey
		{
			get
			{
				return _dbKey;
			}

			protected set
			{
				_dbKey = value;
			}
		}

		/// <summary>
		/// Gets or sets the db version.
		/// </summary>
		/// <value>The db version.</value>
		public virtual int DbRevision
		{
			get
			{
				return _dbRevision;
			}

			protected set
			{
				_dbRevision = value;
			}
		}

		/// <summary>
		/// Gets or sets the user who created the object.
		/// </summary>
		/// <value>The user who created the object.</value>
		public virtual Auth.User EditingUser
		{
			get
			{
				return _editingUser;
			}

			set
			{
				_editingUser = value;
			}
		}

		/// <summary>
		/// Gets or sets the date/time of the last change in UTC.
		/// </summary>
		/// <value>The last change of this instance in UTC.</value>
		public virtual DateTime LastChange
		{
			get
			{
				return _lastChange;
			}

			set
			{
				if (value.Kind != DateTimeKind.Utc)
				{
					_lastChange = DateTime.SpecifyKind(value, DateTimeKind.Utc);
				}
				else
				{
					_lastChange = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the user who made the last change.
		/// </summary>
		/// <value>The user who made the last change.</value>
		public virtual Auth.User LastUser
		{
			get
			{
				return _lastuser;
			}

			set
			{
				_lastuser = value;

				// setting the user who last changed the object is implicitly the creator
				// of an object that was just created
				if (ReferenceEquals(null, Creator))
				{
					Creator = _lastuser;
				}
			}
		}

		/// <summary>
		/// Gets or sets the date/time of the creation in UTC.
		/// </summary>
		/// <value>The creation time of this object in UTC.</value>
		public virtual DateTime Created
		{
			get
			{
				return _created;
			}

			set
			{
				if (value.Kind != DateTimeKind.Utc)
				{
					_created = DateTime.SpecifyKind(value, DateTimeKind.Utc);
				}
				else
				{
					_created = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the user who created the object.
		/// </summary>
		/// <value>The user who created the object.</value>
		public virtual Auth.User Creator
		{
			get
			{
				return _creator;
			}

			set
			{
				_creator = value;
			}
		}

		/// <summary>
		/// Gets or sets the GUID.
		/// </summary>
		/// <value>The GUID of the transient object.</value>
		public virtual Guid Guid
		{
			get
			{
				return _guid;
			}

			protected set
			{
				_guid = value;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is transient.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is transient; otherwise, <c>false</c>.
		/// </value>
		protected internal virtual bool IsTransient
		{
			get
			{
				return _dbKey.Equals(DefaultKey);
			}
		}

		/// <summary>
		/// Gets the default key.
		/// </summary>
		/// <value>The default key.</value>
		protected abstract TKeyType DefaultKey
		{
			get;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			StringBuilder builder = new StringBuilder(GetType().ToString());
			builder.Append(": ");
			builder.Append("DbKey: ");
			builder.Append(DbKey.ToString());
			builder.Append(", ");
			builder.Append("Guid: ");
			builder.Append(Guid);
			return builder.ToString();
		}

		/// <summary>
		/// Bestimmt, ob das angegebene <see cref="T:System.Object"></see> und das aktuelle <see cref="T:System.Object"></see> gleich sind.
		/// </summary>
		/// <param name="obj">Das <see cref="T:System.Object"></see>, das mit dem aktuellen <see cref="T:System.Object"></see> verglichen werden soll.</param>
		/// <returns>
		/// true, wenn das angegebene <see cref="T:System.Object"></see> gleich dem aktuellen <see cref="T:System.Object"></see> ist, andernfalls false.
		/// </returns>
		public override bool Equals(object obj)
		{
			// performance:
			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			PersistentObject<TKeyType> value = obj as PersistentObject<TKeyType>;
			return value != null && Guid.Equals(value.Guid);
		}

		/// <summary>
		/// Fungiert als Hashfunktion für einen bestimmten Typ. <see cref="M:System.Object.GetHashCode"></see> eignet sich für die Verwendung in Hashalgorithmen und Hashdatenstrukturen, z. B. in einer Hashtabelle.
		/// </summary>
		/// <returns>
		/// Ein Hashcode für das aktuelle <see cref="T:System.Object"></see>.
		/// </returns>
		public override int GetHashCode()
		{
			return Guid.GetHashCode();
		}

		#endregion
	}
}
