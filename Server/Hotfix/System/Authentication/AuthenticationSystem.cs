using Fantasy.Async;
using Fantasy.DataBase;
using Fantasy.Entitas;
using Fantasy.Helper;
using Model.Authentication;

namespace Hotfix.System.Authentication
{
	public static class AuthenticationSystem
	{
		public static async FTask<uint> RegistAccount(this AuthenticationAccountComponent self, string account, string password)
		{
			if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
			{
				return 1000;
			}
			int accountHashCode = account.GetHashCode();
			if (self.accountCache.ContainsKey(accountHashCode))
			{
				return 1001;
			}
			IDataBase db = self.Scene.World.DataBase;
			bool isExist = await db.Exist<Account>(d=>d.account==account);
			if (isExist)
			{
				return 1002;
			}
			Account accountData = Entity.Create<Account>(self.Scene,true,true);
			accountData.account = account;
			accountData.password = password;
			accountData.createTime = TimeHelper.Now;
			self.accountCache.Add(accountHashCode, accountData);
			await db.Save(accountData);
			return 0;
		}
	}
}