using Fantasy.Network.Interface;
using Model.Authentication;
using Hotfix.System.Authentication;
using Fantasy;
using Fantasy.Async;
using Fantasy.Network;

namespace Hotfix
{
	public class RegistAccountHanlder : MessageRPC<RegistAccountRequest, RegistAccountResponse>
	{
		protected override async FTask Run(Session session, RegistAccountRequest request, RegistAccountResponse response, Action reply)
		{
			var accComp = session.Scene.GetComponent<AuthenticationAccountComponent>();
			var errCode = await accComp.RegistAccount(request.account, request.passward);
			if (errCode == 0)
			{
				response.account = request.account;
				response.passward = request.passward;
			}
			response.ErrorCode = errCode;
			Log.Info($"注册账号完成 结果：{errCode}");
			await FTask.CompletedTask;
		}
	}
}