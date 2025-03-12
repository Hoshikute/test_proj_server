using Fantasy;
using Model.Authentication;
using Fantasy.Async;
using Fantasy.Event;
using Fantasy.Platform.Net;
using System.Threading.Tasks;

namespace Hotfix;

public class OnSceneCreateCfg : AsyncEventSystem<OnCreateScene>
{
	protected override async FTask Handler(OnCreateScene self)
	{
		switch (self.Scene.SceneType)
		{
			case SceneType.Authentication:
				self.Scene.AddComponent<AuthenticationAccountComponent>();
				break;
		}
		await FTask.CompletedTask;
	}
}
