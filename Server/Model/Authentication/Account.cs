using Fantasy;
using Fantasy.Entitas;
using Fantasy.Entitas.Interface;
namespace Model.Authentication
{
	public class Account:Entity,ISupportedDataBase
	{
		public string account;
		public string password;
		public long loginTime;
		public long createTime;
	}
}