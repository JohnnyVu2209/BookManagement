
namespace BookManagement.Server.DL.ValueObjects
{
	public class Author: IEquatable<Author>
	{
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public Author(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public override bool Equals(object? obj)
		{
			return Equals(obj as Author);
		}

		public bool Equals(Author? other)
		{
			if(other == null)
			{
				return false;
			}

			return FirstName == other.FirstName && LastName == other.LastName;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(FirstName, LastName);
		}
	}
}
