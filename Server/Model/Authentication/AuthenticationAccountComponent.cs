using Fantasy.Entitas;

namespace Model.Authentication
{
	public class AuthenticationAccountComponent : Entity
	{
		public readonly Dictionary<int, Account> accountCache = new Dictionary<int, Account>();

	}
}